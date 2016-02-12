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
    public partial class ColorForm : Form
    {
        Settings con;

        public ColorForm(Settings config)
        {
            InitializeComponent();
            this.con = config;
        }

        private void ColorForm_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;

            textBoxRed.Text = con.redAmount.ToString();
            textBoxGreen.Text = con.greenAmount.ToString();
            textBoxBlue.Text = con.blueAmount.ToString();
        }

        #region Red
        private void textBoxRed_TextChanged(object sender, EventArgs e)
        {
            if (textBoxRed.Text != "")
            {
                byte newColor = 0;

                if (byte.TryParse(textBoxRed.Text, out newColor))
                {
                    if (newColor >= 0 && newColor <= 255)
                    {
                        con.redAmount = newColor;
                    }
                    else
                    {
                        textBoxRed.Text = con.redAmount.ToString();
                    }
                }
                else
                {
                    textBoxRed.Text = con.redAmount.ToString();
                }
            }
        }
        private void textBoxRed_GotFocus(object sender, EventArgs e)
        {
            textBoxRed.SelectAll();
        }
        private void buttonAddRed_Click(object sender, EventArgs e)
        {
            if (con.redAmount < 255)
            {
                con.redAmount++;
                textBoxRed.Text = con.redAmount.ToString();
            }
        }
        private void buttonRemoveRed_Click(object sender, EventArgs e)
        {
            if (con.redAmount > 0)
            {
                con.redAmount--;
                textBoxRed.Text = con.redAmount.ToString();
            }
        }
        #endregion

        #region Green
        private void textBoxGreen_TextChanged(object sender, EventArgs e)
        {
            if (textBoxGreen.Text != "")
            {
                byte newColor = 0;

                if (byte.TryParse(textBoxGreen.Text, out newColor))
                {
                    if (newColor >= 0 && newColor <= 255)
                    {
                        con.greenAmount = newColor;
                    }
                    else
                    {
                        textBoxGreen.Text = con.greenAmount.ToString();
                    }
                }
                else
                {
                    textBoxGreen.Text = con.greenAmount.ToString();
                }
            }
        }
        private void textBoxGreen_GotFocus(object sender, EventArgs e)
        {
            textBoxGreen.SelectAll();
        }
        private void buttonAddGreen_Click(object sender, EventArgs e)
        {
            if (con.greenAmount < 255)
            {
                con.greenAmount++;
                textBoxGreen.Text = con.greenAmount.ToString();
            }
        }
        private void buttonRemoveGreen_Click(object sender, EventArgs e)
        {
            if (con.greenAmount > 0)
            {
                con.greenAmount--;
                textBoxGreen.Text = con.greenAmount.ToString();
            }
        }
        #endregion

        #region Blue
        private void textBoxBlue_TextChanged(object sender, EventArgs e)
        {
            if (textBoxBlue.Text != "")
            {
                byte newColor = 0;

                if (byte.TryParse(textBoxBlue.Text, out newColor))
                {
                    if (newColor >= 0 && newColor <= 255)
                    {
                        con.blueAmount = newColor;
                    }
                    else
                    {
                        textBoxBlue.Text = con.blueAmount.ToString();
                    }
                }
                else
                {
                    textBoxBlue.Text = con.blueAmount.ToString();
                }
            }
        }
        private void textBoxBlue_GotFocus(object sender, EventArgs e)
        {
            textBoxBlue.SelectAll();
        }
        private void buttonAddBlue_Click(object sender, EventArgs e)
        {
            if (con.blueAmount < 255)
            {
                con.blueAmount++;
                textBoxBlue.Text = con.blueAmount.ToString();
            }
        }
        private void buttonRemoveBlue_Click(object sender, EventArgs e)
        {
            if (con.blueAmount > 0)
            {
                con.blueAmount--;
                textBoxBlue.Text = con.blueAmount.ToString();
            }
        }
        #endregion
    }
}
