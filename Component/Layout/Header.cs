using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemeterGift_Aelf.Component.Layout
{
    public partial class Header : UserControl
    {
        public Header()
        {
            InitializeComponent();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Form1 MainForm = (Form1)this.Parent;
            MainForm.PnlContainer.Controls.Clear();
            MainForm.PnlContainer.Controls.Add(new Pages.Home());
            MainForm.PnlContainer.Controls[0].Dock = DockStyle.Top;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }
    }
}
