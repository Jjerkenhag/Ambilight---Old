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
        AudioForm audioForm;
        ColorForm colorForm;
        AmbientForm ambientForm;

        Bitmap bmpScreenshot;

        //UPS : Updates Per Second
        DateTime lastTime = DateTime.Now; //Time since last update of label
        int loop = 0; //Number of updates last second

        byte[] packageData = new byte[256]; //3 * LEDs + 1 (256 just to make room for 85 + 'a')
        bool readyToSendData = false;
        bool paused = false; //This is used to let the data sender run one last time
        int placeAt = 0; //To keep track of where to put the data

        bool formOpen = true; //Keeping track if form is minimized or open

        //For the color data and calculations
        Color sendColor = new Color();
        int red, green, blue, counter; //This if for calculating the average value.

        int videoCaptureHeight = 1; //The height of which to capture video, this variable will be updated by itself
        int videoCaptureWidth = Screen.PrimaryScreen.Bounds.Width + 1100; //The width of the area of which to capture video
        int videoCaptureLEDWidth = 1; //The width of each LED, this too will update itself
        int offsetFromLeft = 0; //The offset from the left side of your screen, good if your strip is shorter than the width of your screen

        byte lastRed = 0, lastGreen = 0, lastBlue = 0; //This is used for the update of the color mode

        Color getColor = new Color(); //Put this here to avoid creating one for every LED

        Form currentForm; //Keeps track on what window/form to show

        public Ambilight()
        {
            InitializeComponent();
        }

        private void Ambilight_Load(object sender, EventArgs e)
        {
            //All the control windows
            videoForm = new VideoForm(config);
            audioForm = new AudioForm(config);
            colorForm = new ColorForm(config);
            ambientForm = new AmbientForm(config);

            //Makes our life easier with the multithreading
            Control.CheckForIllegalCrossThreadCalls = false;

            config.setDefaultConfiguration(); //Set configuration to default to avoid errors
            LoadConfig(); //Load the configuration file

            packageData = new byte[config.numberOfLeds * 3 + 1]; //Update the size of data

            port = new SerialPort(config.port, config.baud, Parity.None, 8, StopBits.One);
            try
            {
                port.Open(); //Try to open the port
            }
            catch
            {
                //If the open fails the program will quit and xml-file must be changed
                MessageBox.Show("Could not open port, check config or arduino.");
                exitApplication();
            }

            //Start all the background workers
            backgroundWorkerDataSender.RunWorkerAsync();
            backgroundWorkerVideo.RunWorkerAsync();
            backgroundWorkerAudio.RunWorkerAsync();
            backgroundWorkerColor.RunWorkerAsync();
            backgroundWorkerAmbient.RunWorkerAsync();

            //Initiate all child forms
            this.IsMdiContainer = true;
            videoForm.MdiParent = audioForm.MdiParent = colorForm.MdiParent = ambientForm.MdiParent = this;

            colorForm.BackColor = Color.FromArgb(config.redAmount, config.greenAmount, config.blueAmount);

            //Open the form corresponding to the mode
            if (config.currentMode == Settings.mode.video)
            {
                currentForm = videoForm;
                videoForm.Show();
            }
            if (config.currentMode == Settings.mode.audio)
            {
                currentForm = audioForm;
                audioForm.Show();
            }
            if (config.currentMode == Settings.mode.color)
            {
                currentForm = colorForm;
                colorForm.Show();
            }
            if (config.currentMode == Settings.mode.ambient)
            {
                currentForm = ambientForm;
                ambientForm.Show();
            }
        }
        private void Ambilight_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) //Is the close-button is pressed, this will run
            {
                notifyIconAmbilight.BalloonTipTitle = "Minimized";
                notifyIconAmbilight.BalloonTipText = "Ambilight is still running. Click to open.";
                notifyIconAmbilight.ShowBalloonTip(500);
                this.Hide();
                formOpen = false;
                minimizeToolStripMenuIconItem.Text = "Open";
                e.Cancel = true;
            }
            if (e.CloseReason == CloseReason.WindowsShutDown) //If windows is shutting down, this will be called
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
                    //Read all the tags and its content and place in variables
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

                        //Send these variables to the configuration
                        config.setConfiguration(port, baud, numberOfLeds, offset, height, pixelPerX, pixelPerY, brightness, extant, linearCapture, turnOffWhenClosed, currentMode, red, green, blue, running);
                    }
                }
                catch
                {
                    //If an error during reading is reached, the default settings will be set
                    config.setDefaultConfiguration();
                }
            }
            catch
            {
                //If an error during opening xml is reached, the default settings will be set and the application will exit
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

                //Set the xml to the current settings
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

                //Save the new settings
                doc.Save("config.xml");
            }
            catch
            {
                //Is something fails this will show
                MessageBox.Show("Failed to save config.");
            }
        }
        #endregion

        #region Menu
        private void videoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (config.currentMode != Settings.mode.video) //If current mode is same, do nothing
            {
                currentForm.Hide(); //Hide the current form
                videoForm.Show(); //Show new form
                currentForm = videoForm; //Set currentForm to the new form
                config.currentMode = Settings.mode.video; //Set current mode to new mode
            }
        }
        private void audioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (config.currentMode != Settings.mode.audio) //If current mode is same, do nothing
            {
                currentForm.Hide(); //Hide the current form
                audioForm.Show(); //Show new form
                currentForm = audioForm; //Set currentForm to the new form
                config.currentMode = Settings.mode.audio; //Set current mode to new mode
            }
        }
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (config.currentMode != Settings.mode.color) //If current mode is same, do nothing
            {
                currentForm.Hide(); //Hide the current form
                colorForm.Show(); //Show new form
                currentForm = colorForm; //Set currentForm to the new form
                lastRed--; //Change lastRed to force the color to update
                config.currentMode = Settings.mode.color; //Set current mode to new mode
            }
        }
        private void ambientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (config.currentMode != Settings.mode.ambient) //If current mode is same, do nothing
            {
                currentForm.Hide(); //Hide the current form
                ambientForm.Show(); //Show new form
                currentForm = ambientForm; //Set currentForm to the new form
                config.currentMode = Settings.mode.ambient; //Set current mode to new mode
            }
        }
        private void startStopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (config.running == true)
            {
                paused = true; //This is used to let the data sender continue without the other workers interfering
                lastRed--;
                config.running = false; //Stop all the workers
                startStopToolStripMenuItem.Text = "Start"; //Change the labels
                startStopToolStripMenuIconItem.Text = "Start";
            }
            else
            {
                paused = false;
                lastRed--;
                config.running = true; //Start the workers
                startStopToolStripMenuItem.Text = "Stop"; //Change the labels
                startStopToolStripMenuIconItem.Text = "Stop";
            }
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
                paused = true;
                lastRed--;
                config.running = false;
                startStopToolStripMenuItem.Text = "Start";
                startStopToolStripMenuIconItem.Text = "Start";
            }
            else
            {
                paused = false;
                lastRed--;
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
                    //If cancellation is activated, this will run
                    e.Cancel = true;
                    return;
                }
                else
                {
                    if (port.IsOpen && readyToSendData)
                    {
                        if (paused)
                        {
                            sendAllBlack();
                        }
                        port.Write(packageData, 0, (config.numberOfLeds * 3 + 1)); //Send all the data
                        readyToSendData = false; //Set ready to false
                        loop++; //Add to the update speed

                        if ((DateTime.Now - lastTime).Seconds > 1)
                        {
                            //Update the label when a second has passed and reset the counter
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
                        //A small add to save some CPU usage
                        System.Threading.Thread.Sleep(1);
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
                    //If cancellation is activated, this will run
                    e.Cancel = true;
                    return;
                }
                else
                {
                    if (config.currentMode == Settings.mode.video && config.running == true)
                    {
                        if (readyToSendData == false)
                        {
                            try
                            {
                                Bitmap bmpScreenshot = Screenshot(); //Take a picture of capture area
                                packageData[placeAt++] = Convert.ToByte('a'); //Set starting byte

                                for (int i = 0; i < config.numberOfLeds; i++)
                                {
                                    //Use the chosen mode of color calculation
                                    if (config.linearCapture)
                                        findMeanColorLinear(i, bmpScreenshot);
                                    else
                                        findMeanColorEqual(i, bmpScreenshot);

                                    //Add brightness to the value, convert to byte and add to the package
                                    packageData[placeAt++] = Convert.ToByte(addBrightness(sendColor.R));
                                    packageData[placeAt++] = Convert.ToByte(addBrightness(sendColor.G));
                                    packageData[placeAt++] = Convert.ToByte(addBrightness(sendColor.B));
                                }

                                placeAt = 0;
                                readyToSendData = true; //Set to true to activate data sender
                            }
                            catch { }
                        }
                    }
                    else
                    {
                        //If current mode is not color, this thread will sleep half a second
                        System.Threading.Thread.Sleep(500);
                    }
                }
            }
        }
        private Bitmap Screenshot()
        {
            videoCaptureHeight = Screen.PrimaryScreen.Bounds.Height / config.height; //To update the capture portion.

            bmpScreenshot = new Bitmap(videoCaptureWidth, videoCaptureHeight); //Create new bitmap with appropriate size

            Graphics g = Graphics.FromImage(bmpScreenshot); //Create graphics from bitmap

            Size s = new Size(videoCaptureWidth, videoCaptureHeight); //Set the size of capture area

            g.CopyFromScreen(offsetFromLeft, config.offset, 0, 0, s); //Take picture of screen and put into graphics

            return bmpScreenshot;
        }
        private void findMeanColorEqual(int forLed, Bitmap fromBmp)
        {
            //Gather pixels for each LED and calculate mean color
            red = 0;
            green = 0;
            blue = 0;
            counter = 0;

            //Update the width of each LED in pixels
            videoCaptureLEDWidth = videoCaptureWidth / config.numberOfLeds;

            //Calculate the space between each pixel in X and Y
            int JUMP_X = videoCaptureLEDWidth / config.pixelPerX;
            int JUMP_Y = videoCaptureHeight / config.pixelPerY;

            //Get the x of where to start gathering
            int beginAtX = forLed * videoCaptureLEDWidth;

            //Cather the color values of pixels
            for (int i = 0; i < videoCaptureLEDWidth; i += JUMP_X)
            {
                for (int j = 0; j < videoCaptureHeight; j += JUMP_Y)
                {
                    getColor = fromBmp.GetPixel(beginAtX + i, j);

                    red += getColor.R;
                    green += getColor.G;
                    blue += getColor.B;

                    counter++;
                }
            }

            //Assign the mean of those values
            sendColor = Color.FromArgb(red / counter, green / counter, blue / counter);
        }
        private void findMeanColorLinear(int forLed, Bitmap fromBmp)
        {
            //Gather pixels for each LED and calculate mean color
            red = 0;
            green = 0;
            blue = 0;
            counter = 0;

            //Update the width of each LED in pixels
            videoCaptureLEDWidth = videoCaptureWidth / config.numberOfLeds;

            //Calculate the space between each pixel in X and Y
            int JUMP_X = videoCaptureLEDWidth / config.pixelPerX;
            int JUMP_Y = videoCaptureHeight / config.pixelPerY;

            //Get the x of where to start gathering
            int beginAtX = forLed * videoCaptureLEDWidth;

            //Cather the color values of pixels
            for (int i = 0; i < videoCaptureLEDWidth; i += JUMP_X)
            {
                for (int j = 0; j < videoCaptureHeight; j += JUMP_Y)
                {
                    getColor = fromBmp.GetPixel(beginAtX + i, j);

                    //This "algorithm" gives pixels further from the top less influence on final color
                    int log = ((videoCaptureHeight - j) * 100) / videoCaptureHeight;

                    red += getColor.R * log;
                    green += getColor.G * log;
                    blue += getColor.B * log;

                    counter += log;
                }
            }

            //Assign the mean of those values
            sendColor = Color.FromArgb(red / counter, green / counter, blue / counter);
        }

        private int addBrightness(int value)
        {
            //Create a new variable from the input value multiplied with the brightness
            int newValue = value * config.brightness / 100;
            if (newValue > 255)
            {
                //Since a color value can't be over 255 we have to cap it
                newValue = 255;
            }
            return newValue;
        }
        #endregion

        #region Audio code
        private void backgroundWorkerAudio_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (backgroundWorkerAudio.CancellationPending)
                {
                    //If cancellation is activated, this will run
                    e.Cancel = true;
                    return;
                }
                else
                {
                    if (config.currentMode == Settings.mode.audio && config.running == true)
                    {
                        if (readyToSendData == false)
                        {
                            Bitmap bmpScreenshot = Screenshot(); //Take a picture of capture area
                            packageData[placeAt++] = Convert.ToByte('a'); //Set starting byte

                            for (int i = 0; i < config.numberOfLeds; i++)
                            {
                                //Use the chosen mode of color calculation
                                if (config.linearCapture)
                                    findMeanColorLinear(i, bmpScreenshot);
                                else
                                    findMeanColorEqual(i, bmpScreenshot);

                                //Add brightness to the value, convert to byte and add to the package
                                packageData[placeAt++] = Convert.ToByte(addBrightness(sendColor.R));
                                packageData[placeAt++] = Convert.ToByte(addBrightness(sendColor.G));
                                packageData[placeAt++] = Convert.ToByte(addBrightness(sendColor.B));
                            }

                            placeAt = 0;
                            readyToSendData = true; //Set to true to activate data sender
                        }
                    }
                    else
                    {
                        //If current mode is not color, this thread will sleep half a second
                        System.Threading.Thread.Sleep(500);
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
                    //If cancellation is activated, this will run
                    e.Cancel = true;
                    return;
                }
                else
                {
                    if (config.currentMode == Settings.mode.color && config.running == true && paused == false)
                    {
                        System.Threading.Thread.Sleep(100);

                        if (lastRed != config.redAmount || lastGreen != config.greenAmount || lastBlue != config.blueAmount)
                        {
                            //Update background color
                            colorForm.BackColor = Color.FromArgb(config.redAmount, config.greenAmount, config.blueAmount);

                            //Update all color values
                            lastRed = config.redAmount;
                            lastGreen = config.greenAmount;
                            lastBlue = config.blueAmount;

                            if (readyToSendData == false)
                            {
                                packageData[placeAt++] = Convert.ToByte('a'); //Place start byte

                                for (int i = 0; i < config.numberOfLeds; i++)
                                {
                                    //Place all color values
                                    packageData[placeAt++] = lastRed;
                                    packageData[placeAt++] = lastGreen;
                                    packageData[placeAt++] = lastBlue;
                                }

                                placeAt = 0;
                                readyToSendData = true; //Set to true to activate data sender
                            }
                        }
                    }
                    else
                    {
                        //If current mode is not color, this thread will sleep half a second
                        System.Threading.Thread.Sleep(500);
                    }
                }
            }
        }
        private void sendAllBlack()
        {
            //Set start byte and fill rest with black
            packageData[0] = Convert.ToByte('a');
            for (int i = 0; i < config.numberOfLeds * 3; i++)
            {
                packageData[i + 1] = Convert.ToByte(0);
            }
            readyToSendData = true;
        }
        #endregion

        #region Ambient code
        private void backgroundWorkerAmbient_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (backgroundWorkerAmbient.CancellationPending)
                {
                    //If cancellation is activated, this will run
                    e.Cancel = true;
                    return;
                }
                else
                {
                    if (config.currentMode == Settings.mode.ambient && config.running == true)
                    {
                        if (readyToSendData == false)
                        {
                            Bitmap bmpScreenshot = Screenshot(); //Take a picture of capture area
                            packageData[placeAt++] = Convert.ToByte('a'); //Set starting byte

                            for (int i = 0; i < config.numberOfLeds; i++)
                            {
                                //Use the chosen mode of color calculation
                                if (config.linearCapture)
                                    findMeanColorLinear(i, bmpScreenshot);
                                else
                                    findMeanColorEqual(i, bmpScreenshot);

                                //Add brightness to the value, convert to byte and add to the package
                                packageData[placeAt++] = Convert.ToByte(addBrightness(sendColor.R));
                                packageData[placeAt++] = Convert.ToByte(addBrightness(sendColor.G));
                                packageData[placeAt++] = Convert.ToByte(addBrightness(sendColor.B));
                            }

                            placeAt = 0;
                            readyToSendData = true; //Set to true to activate data sender
                        }
                    }
                    else
                    {
                        //If current mode is not color, this thread will sleep half a second
                        System.Threading.Thread.Sleep(500);
                    }
                }
            }
        }
        #endregion

        #region Exit code
        private void exitApplication()
        {
            //Write current settings to XML
            SaveConfig();

            //Send all black to the strip
            if (config.turnOffWhenClosed == true)
            {
                sendAllBlack();
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

            //Close all forms
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
        #endregion
    }
}
