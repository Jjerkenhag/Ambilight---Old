using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO.Ports;
using System.IO;
using System.Threading;

namespace Ambilight
{
    public partial class Ambilight : Form
    {
        Settings config = new Settings();

        SerialPort port;

        VideoForm videoForm;
        ColorForm colorForm;

        //UPS : Updates Per Second
        DateTime lastTime = DateTime.Now;
        int loop = 0;

        byte[] packageData = new byte[256]; //3 * LEDs + 1 (256 just to make room for 85 + 'a')
        bool readyToSendData = false;
        int placeAt = 0;

        bool formOpen = true;

        //For the color data and calculations
        Color sendColor = new Color();
        int red, green, blue, counter; //This if for calculating the average color.

        int videoCaptureHeight = 1;
        int videoCaptureWidth = Screen.PrimaryScreen.Bounds.Width;
        int videoCaptureLEDWidth = 1;

        byte lastRed = 0, lastGreen = 0, lastBlue = 0;

        Form currentForm;

        public Ambilight()
        {
            InitializeComponent();
        }

        private void Ambilight_Load(object sender, EventArgs e)
        {
            //All the control windows
            videoForm = new VideoForm(config);
            colorForm = new ColorForm(config);
            
            //Makes our life easier with the multithreading
            Control.CheckForIllegalCrossThreadCalls = false;

            config.setDefaultConfiguration();
            LoadConfig();

            packageData = new byte[config.numberOfLeds * 3 + 1];

            port = new SerialPort(config.port, config.baud, Parity.None, 8, StopBits.One);
            try
            {
                port.Open();
            }
            catch
            {
                MessageBox.Show("Could not open port, check config or arduino.");
                exitApplication();
            }

            backgroundWorkerDataSender.RunWorkerAsync();
            backgroundWorkerVideo.RunWorkerAsync();
            backgroundWorkerColor.RunWorkerAsync();

            //Initiate all child forms
            this.IsMdiContainer = true;

            videoForm.MdiParent = this;
            colorForm.MdiParent = this;

            colorForm.BackColor = Color.FromArgb(config.redAmount, config.greenAmount, config.blueAmount);

            if (config.currentMode == Settings.mode.color)
            {
                currentForm = colorForm;
                colorForm.Show();
            }
            if (config.currentMode == Settings.mode.video)
            {
                currentForm = videoForm;
                videoForm.Show();
            }
        }
        private void Ambilight_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                notifyIconAmbilight.BalloonTipTitle = "Minimized";
                notifyIconAmbilight.BalloonTipText = "Ambilight is still running. Click to open.";
                notifyIconAmbilight.ShowBalloonTip(500);
                this.Hide();
                formOpen = false;
                minimizeToolStripMenuIconItem.Text = "Open";
                e.Cancel = true;
            }
            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                exitApplication();
            }
        }

        #region Configuration read and write
        private void LoadConfig()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("config.xml");

                try
                {
                    foreach (XmlNode node in doc.DocumentElement)
                    {
                        string port = node["Port"].InnerText;
                        int baud = int.Parse(node["Baud"].InnerText);
                        int numberOfLeds = int.Parse(node["Leds"].InnerText);
                        int offset = int.Parse(node["Offset"].InnerText);
                        int height = int.Parse(node["Height"].InnerText);
                        int pixelPerX = int.Parse(node["PixelPerX"].InnerText);
                        int pixelPerY = int.Parse(node["PixelPerY"].InnerText);
                        int brightness = int.Parse(node["Brightness"].InnerText);
                        int extant = int.Parse(node["Extant"].InnerText);
                        bool linearCapture = bool.Parse(node["LinearCapture"].InnerText);
                        bool turnOffWhenClosed = bool.Parse(node["TurnOffWhenClosed"].InnerText);
                        string currentMode = node["Mode"].InnerText;
                        byte red = byte.Parse(node["Red"].InnerText);
                        byte green = byte.Parse(node["Green"].InnerText);
                        byte blue = byte.Parse(node["Blue"].InnerText);
                        bool running = bool.Parse(node["Running"].InnerText);

                        config.setConfiguration(port, baud, numberOfLeds, offset, height, pixelPerX, pixelPerY, brightness, extant, linearCapture, turnOffWhenClosed, currentMode, red, green, blue, running);
                    }
                }
                catch
                {
                    config.setDefaultConfiguration();
                }
            }
            catch
            {
                config.setDefaultConfiguration();
                exitApplication();
            }
        }
        private void SaveConfig()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("config.xml");

                foreach (XmlNode node in doc.DocumentElement)
                {
                    node["Port"].InnerText = config.port.ToString();
                    node["Baud"].InnerText = config.baud.ToString();
                    node["Leds"].InnerText = config.numberOfLeds.ToString();
                    node["Offset"].InnerText = config.offset.ToString();
                    node["Height"].InnerText = config.height.ToString();
                    node["PixelPerX"].InnerText = config.pixelPerX.ToString();
                    node["PixelPerY"].InnerText = config.pixelPerY.ToString();
                    node["Brightness"].InnerText = config.brightness.ToString();
                    node["Extant"].InnerText = config.extant.ToString();
                    node["LinearCapture"].InnerText = config.linearCapture.ToString();
                    node["TurnOffWhenClosed"].InnerText = config.turnOffWhenClosed.ToString();
                    node["Mode"].InnerText = config.currentMode.ToString();
                    node["Red"].InnerText = config.redAmount.ToString();
                    node["Green"].InnerText = config.greenAmount.ToString();
                    node["Blue"].InnerText = config.blueAmount.ToString();
                    node["Running"].InnerText = config.running.ToString();
                }

                doc.Save("config.xml");
            }
            catch
            {
                MessageBox.Show("Failed to save config.");
            }
        }
        #endregion

        #region Menu
        private void videoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentForm.Hide();
            videoForm.Show();
            currentForm = videoForm;
            config.currentMode = Settings.mode.video;
        }
        private void audioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Does nothing right now
        }
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentForm.Hide();
            colorForm.Show();
            currentForm = colorForm;
            lastRed--;
            config.currentMode = Settings.mode.color;
        }
        private void ambientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Does nothing right now
        }
        private void startStopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (config.running == true)
            {
                config.running = false;
                startStopToolStripMenuItem.Text = "Start";
                startStopToolStripMenuIconItem.Text = "Start";
            }
            else
            {
                config.running = true;
                startStopToolStripMenuItem.Text = "Stop";
                startStopToolStripMenuIconItem.Text = "Stop";
            }
        }
        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            exitApplication();
        }
        #endregion

        #region Icon Menu
        private void notifyIconAmbilight_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            minimizeToolStripMenuIconItem.PerformClick();
        }
        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formOpen)
            {
                notifyIconAmbilight.BalloonTipTitle = "Minimized";
                notifyIconAmbilight.BalloonTipText = "Ambilight is still running. Click to open.";
                notifyIconAmbilight.ShowBalloonTip(500);
                this.Hide();
                formOpen = false;
                minimizeToolStripMenuIconItem.Text = "Open";
            }
            else
            {
                this.Show();
                formOpen = true;
                minimizeToolStripMenuIconItem.Text = "Minimize";
            }
        }
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (config.running == true)
            {
                config.running = false;
                startStopToolStripMenuItem.Text = "Start";
                startStopToolStripMenuIconItem.Text = "Start";
            }
            else
            {
                config.running = true;
                startStopToolStripMenuItem.Text = "Stop";
                startStopToolStripMenuIconItem.Text = "Stop";
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exitApplication();
        }
        #endregion

        #region Sender code
        private void backgroundWorkerDataSender_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (backgroundWorkerDataSender.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    if (port.IsOpen && readyToSendData && config.running)
                    {
                        port.Write(packageData, 0, (config.numberOfLeds * 3 + 1));
                        readyToSendData = false;
                        loop++;

                        if ((DateTime.Now - lastTime).Seconds > 1)
                        {
                            lastTime = DateTime.Now;
                            labelSenderSpeed.Text = loop.ToString();
                            loop = 0;
                        }

                        //Dispose garbage to prevent "momory leakage"
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(1);
                    }
                }
            }
        }
        #endregion

        #region Color code
        private void backgroundWorkerColor_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (backgroundWorkerColor.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    if (config.currentMode == Settings.mode.color && config.running == true)
                    {
                        System.Threading.Thread.Sleep(100);

                        if (lastRed != config.redAmount || lastGreen != config.greenAmount || lastBlue != config.blueAmount)
                        {
                            colorForm.BackColor = Color.FromArgb(config.redAmount, config.greenAmount, config.blueAmount);

                            lastRed = config.redAmount;
                            lastGreen = config.greenAmount;
                            lastBlue = config.blueAmount;

                            if (readyToSendData == false)
                            {
                                packageData[placeAt++] = Convert.ToByte('a');

                                for (int i = 0; i < config.numberOfLeds; i++)
                                {
                                    packageData[placeAt++] = lastRed;
                                    packageData[placeAt++] = lastGreen;
                                    packageData[placeAt++] = lastBlue;
                                }

                                placeAt = 0;
                                readyToSendData = true;
                            }
                        }
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(500);
                    }
                }
            }
        }
        #endregion

        #region Video code
        private void backgroundWorkerVideo_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (backgroundWorkerVideo.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    if (config.currentMode == Settings.mode.video && config.running == true)
                    {
                        if (readyToSendData == false)
                        {
                            Bitmap bmpScreenshot = Screenshot();
                            packageData[placeAt++] = Convert.ToByte('a');

                            for (int i = 0; i < config.numberOfLeds; i++)
                            {
                                if (config.linearCapture)
                                    findMeanColorLinear(i, bmpScreenshot);
                                else
                                    findMeanColorEqual(i, bmpScreenshot);

                                packageData[placeAt++] = Convert.ToByte(sendColor.R);
                                packageData[placeAt++] = Convert.ToByte(sendColor.G);
                                packageData[placeAt++] = Convert.ToByte(sendColor.B);
                            }

                            placeAt = 0;
                            readyToSendData = true;
                        }
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(500);
                    }
                }
            }
        }
        private Bitmap Screenshot()
        {
            videoCaptureHeight = Screen.PrimaryScreen.Bounds.Height / config.height; //To update the capture portion.

            Bitmap bmpScreenshot = new Bitmap(videoCaptureWidth, videoCaptureHeight);

            Graphics g = Graphics.FromImage(bmpScreenshot);

            Size s = this.Size;
            s.Width = videoCaptureWidth;
            s.Height = videoCaptureHeight;

            g.CopyFromScreen(0, config.offset, 0, 0, s);

            return bmpScreenshot;
        }
        private void findMeanColorEqual(int forLed, Bitmap fromBmp)
        {
            //Gather pixels for each LED and calculate mean color
            Color getColor = new Color();
            red = 0;
            green = 0;
            blue = 0;
            counter = 0;

            videoCaptureLEDWidth = videoCaptureWidth / config.numberOfLeds;

            int JUMP_X = videoCaptureLEDWidth / config.pixelPerX;
            int JUMP_Y = videoCaptureHeight / config.pixelPerY;

            for (int i = 0; i < videoCaptureLEDWidth; i += JUMP_X)
            {
                for (int j = 0; j < videoCaptureHeight; j += JUMP_Y)
                {
                    getColor = fromBmp.GetPixel(i + forLed * videoCaptureLEDWidth, j);

                    red += getColor.R;
                    green += getColor.G;
                    blue += getColor.B;

                    counter++;
                }
            }

            sendColor = Color.FromArgb(red / counter, green / counter, blue / counter);
        }
        private void findMeanColorLinear(int forLed, Bitmap fromBmp)
        {
            //Gather pixels for each LED and calculate mean color
            Color getColor = new Color();
            red = 0;
            green = 0;
            blue = 0;
            counter = 0;

            videoCaptureLEDWidth = videoCaptureWidth / config.numberOfLeds;

            int JUMP_X = videoCaptureLEDWidth / config.pixelPerX;
            int JUMP_Y = videoCaptureHeight / config.pixelPerY;

            for (int i = 0; i < videoCaptureLEDWidth; i += JUMP_X)
            {
                for (int j = 0; j < videoCaptureHeight; j += JUMP_Y)
                {
                    getColor = fromBmp.GetPixel(i + forLed * videoCaptureLEDWidth, j);

                    //This "algorithm" gives pixels further from the top less influence on final color
                    int log = ((videoCaptureHeight - j) * 100) / videoCaptureHeight;

                    red += getColor.R * log;
                    green += getColor.G * log;
                    blue += getColor.B * log;

                    counter += log;
                }
            }

            sendColor = Color.FromArgb(red / counter, green / counter, blue / counter);
        }
        #endregion

        //Exit code
        private void exitApplication()
        {
            //Write current settings to XML
            SaveConfig();

            //Send all black to the strip
            if (config.turnOffWhenClosed == true)
            {
                packageData[0] = Convert.ToByte('a');
                for (int i = 0; i < config.numberOfLeds * 3; i++)
                {
                    packageData[i + 1] = Convert.ToByte(0);
                }
                readyToSendData = true;
            }

            while (readyToSendData == true)
            {
                //Wait for DataSender to send last package
            }

            //Stop the background workers
            backgroundWorkerDataSender.CancelAsync();
            backgroundWorkerDataSender.Dispose();
            backgroundWorkerVideo.CancelAsync();
            backgroundWorkerVideo.Dispose();
            backgroundWorkerColor.CancelAsync();
            backgroundWorkerColor.Dispose();

            videoForm.Close();
            colorForm.Close();

            //Remove the taskbar icon
            notifyIconAmbilight.Dispose();

            //Close port
            if (port.IsOpen)
                port.Dispose();
            
            //Close the application
            Application.Exit();
        }
    }
}
