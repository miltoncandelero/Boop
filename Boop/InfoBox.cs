using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boop
{
    partial class InfoBox : Form
    {
        public InfoBox()
        {
            InitializeComponent();
        }



        private void InfoBox_Load(object sender, EventArgs e)
        {
            this.Text = "Boop " + Utils.GetCurrentVersion();
            label1.Text = Utils.GetCurrentVersion();
        }
    }
}
