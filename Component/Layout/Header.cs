﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AElf;
using AElf.Client.Service;
using AElf.Cryptography;

namespace DemeterGift_Aelf.Component.Layout
{
    public partial class Header : UserControl
    {
        public Header()
        {
            InitializeComponent();
            LoginBTNShow();
        }

        private async void LoginBTNShow()
        {
            if (Properties.Settings.Default.LoggedIn == true)
            {
                PNLloginContainer.Visible = false;
                AddressPNL.Visible = true;
                loadAddressAndBalance();
            }
            else
            {
                PNLloginContainer.Visible = true;
                AddressPNL.Visible = false;
            }
        }

        AElfClient client = new AElfClient("https://aelf-test-node.aelf.io");

        private async void loadAddressAndBalance()
        {
            var address = client.GetAddressFromPubKey(Properties.Settings.Default.PrivateKey);
            AddressTXT.Text = address.Substring(0, 20) + "...";

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

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Form1 MainForm = (Form1)this.Parent;
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
            tableLayoutPanel1.Controls.Add(new Pages.Login.LoginSelector(), 1, 0);
            tableLayoutPanel1.Controls[0].Dock = DockStyle.Fill;

            MainForm.PnlContainer.Controls.Add(tableLayoutPanel1);
            MainForm.PnlContainer.Controls[0].Dock = DockStyle.Fill;
        }
    }
}
