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


namespace DemeterGift_Aelf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        AElfClient client = new AElfClient("https://tdvv-test-node.aelf.io");

        private async void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
