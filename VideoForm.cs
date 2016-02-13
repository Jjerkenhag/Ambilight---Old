using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ambilight
{
    public partial class VideoForm : Form
    {
        Settings con;

        public VideoForm(Settings config)
        {
            InitializeComponent();
            this.con = config;
        }

        private void VideoForm_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

            textBoxOffset.Text = con.offset.ToString();
            labelHeight.Text = "Height: 1/" + con.height.ToString();
            labelPixelPerX.Text = "Pixels X/LED: " + con.pixelPerX.ToString();
            labelPixelPerY.Text = "Pixels Y/LED: " + con.pixelPerY.ToString();
        }

        private void buttonFindOffset_Click(object sender, EventArgs e)
        {
            Bitmap bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            Graphics g = Graphics.FromImage(bmpScreenshot);

            Size s = this.Size;
            s.Width = Screen.PrimaryScreen.Bounds.Width;
            s.Height = Screen.PrimaryScreen.Bounds.Height;

            g.CopyFromScreen(0, 0, 0, 0, s);

            float amountOfDarkness = 1.0f;
            byte red, green, blue;
            Color getColor = new Color();

            con.offset = 0;

            do
            {
                red = 0;
                green = 0;
                blue = 0;
                int blackCount = 0;

                for (int i = 0; i < Screen.PrimaryScreen.Bounds.Width; i += 10)
                {
                    getColor = bmpScreenshot.GetPixel(i, con.offset);

                    //If all values are under 100 count as black pixel
                    if (getColor.R < 10 && getColor.G < 10 && getColor.B < 10)
                        blackCount++;
                }

                //If the whole row has more than half "black" pixels of those checked the loop will exit
                amountOfDarkness = blackCount / (Screen.PrimaryScreen.Bounds.Width / 10.0f);
                if (amountOfDarkness > 0.7)
                {
                    con.offset++;
                    textBoxOffset.Text = con.offset.ToString();
                }
            } while (amountOfDarkness > 0.7 && con.offset + con.height < Screen.PrimaryScreen.Bounds.Height);

            textBoxOffset.Text = con.offset.ToString();
        }

        private void buttonCaptureMode_Click(object sender, EventArgs e)
        {
            if (con.linearCapture == true)
            {
                con.linearCapture = false;
                buttonCaptureMode.Text = "Linear";
            }
            else
            {
                con.linearCapture = true;
                buttonCaptureMode.Text = "Equal";
            }
        }

        private void textBoxOffset_TextChanged(object sender, EventArgs e)
        {
            if (textBoxOffset.Text != "")
            {
                int newOffset = 0;

                if (int.TryParse(textBoxOffset.Text, out newOffset))
                {
                    if (newOffset >= 0 && newOffset + con.height <= Screen.PrimaryScreen.Bounds.Height)
                    {
                        con.offset = newOffset;
                    }
                    else
                    {
                        textBoxOffset.Text = con.offset.ToString();
                    }
                }
                else
                {
                    textBoxOffset.Text = con.offset.ToString();
                }
            }
        }

        private void buttonAddOffset_Click(object sender, EventArgs e)
        {
            if (con.offset + con.height < Screen.PrimaryScreen.Bounds.Height)
            {
                con.offset++;
                textBoxOffset.Text = con.offset.ToString();
            }
        }

        private void buttonRemoveOffset_Click(object sender, EventArgs e)
        {
            if (con.offset > 0)
            {
                con.offset--;
                textBoxOffset.Text = con.offset.ToString();
            }
        }

        private void buttonAddHeight_Click(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen.Bounds.Height / (con.height + 1) + con.offset < Screen.PrimaryScreen.Bounds.Height)
            {
                con.height++;
                labelHeight.Text = "Height: 1/" + con.height;
            }
        }

        private void buttonRemoveHeight_Click(object sender, EventArgs e)
        {
            if (con.height > 1)
            {
                if ((Screen.PrimaryScreen.Bounds.Height / (con.height - 1)) + con.offset <= Screen.PrimaryScreen.Bounds.Height)
                {
                    con.height--;
                    labelHeight.Text = "Height: 1/" + con.height;
                }
            }
        }

        private void buttonAddPxlX_Click(object sender, EventArgs e)
        {
            if (con.pixelPerX < Screen.PrimaryScreen.Bounds.Width / con.numberOfLeds)
            {
                con.pixelPerX++;
                labelPixelPerX.Text = "Pixels X/LED: " + con.pixelPerX;
            }
        }

        private void buttonRemovePxlX_Click(object sender, EventArgs e)
        {
            if (con.pixelPerX > 1)
            {
                con.pixelPerX--;
                labelPixelPerX.Text = "Pixels X/LED: " + con.pixelPerX;
            }
        }

        private void buttonAddPxlY_Click(object sender, EventArgs e)
        {
            if (con.pixelPerY < Screen.PrimaryScreen.Bounds.Height / con.height)
            {
                con.pixelPerY++;
                labelPixelPerY.Text = "Pixels Y/LED: " + con.pixelPerY;
            }
        }

        private void buttonRemovePxlY_Click(object sender, EventArgs e)
        {
            if (con.pixelPerY > 1)
            {
                con.pixelPerY--;
                labelPixelPerY.Text = "Pixels Y/LED: " + con.pixelPerY;
            }
        }

        private void buttonAddBrightness_Click(object sender, EventArgs e)
        {
            if (con.brightness < 200)
            {
                con.brightness += 10;
                labelBrightness.Text = "Brightness: " + con.brightness;
            }
        }

        private void buttonRemoveBrightness_Click(object sender, EventArgs e)
        {
            if (con.brightness > 0)
            {
                con.brightness -= 10;
                labelBrightness.Text = "Brightness: " + con.brightness;
            }
        }
    }
}
