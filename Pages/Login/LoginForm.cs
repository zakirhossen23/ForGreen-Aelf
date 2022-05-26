using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AElf.Client.Service;
namespace DemeterGift_Aelf.Pages.Login
{
    public partial class LoginForm : UserControl
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        AElfClient client = new AElfClient("https://tdvv-test-node.aelf.io");

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.PrivateKey = PrivateKeyTXT.Text;
            Properties.Settings.Default.Password = PasswordTXT.Text;
            Properties.Settings.Default.LoggedIn = true;
            Properties.Settings.Default.Save();
        }
    }
}
