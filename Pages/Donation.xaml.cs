using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AElf.Client.MultiToken;
using DemeterGift_Aelf.Classes;

namespace DemeterGift_Aelf.Pages
{
    /// <summary>
    /// Interaction logic for Donation.xaml
    /// </summary>
    public partial class Donation : Page
    {
        contract contract = new contract();
        public Donation()
        {
            InitializeComponent();
            GetContract();
        }
        private async void GetContract()
        {
          Console.WriteLine(  await contract.Testing());

        }
    }
}
