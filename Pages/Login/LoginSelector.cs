using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemeterGift_Aelf.Pages.Login
{
    public partial class LoginSelector : UserControl
    {
        public LoginSelector()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoginForm()
        {
            Form1 MainForm = (Form1)((Guna.UI2.WinForms.Guna2Panel)((TableLayoutPanel)this.Parent).Parent).Parent;
            MainForm.PnlContainer.Controls.Clear();
            TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.00000F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.00000F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.00000F));
            tableLayoutPanel1.Location = new System.Drawing.Point(66, 41);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.58064F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.41936F));
            tableLayoutPanel1.Size = new System.Drawing.Size(519, 248);
            tableLayoutPanel1.TabIndex = 3;
            tableLayoutPanel1.Controls.Add(new Pages.Login.LoginForm(), 1, 0);
            tableLayoutPanel1.Controls[0].Dock = DockStyle.Fill;

            MainForm.PnlContainer.Controls.Add(tableLayoutPanel1);
            MainForm.PnlContainer.Controls[0].Dock = DockStyle.Fill;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.userType = "manager";
            LoginForm();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.userType = "user";
            LoginForm();
        }
    }
}
