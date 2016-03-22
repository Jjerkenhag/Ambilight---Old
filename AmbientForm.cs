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
    public partial class AmbientForm : Form
    {
        Settings con;

        public AmbientForm(Settings config)
        {
            InitializeComponent();
            this.con = config;
        }

        private void AmbientForm_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }
    }
}
