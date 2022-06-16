using System;
using System.Collections.Generic;
using System.Data;
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

namespace ForGreen_Aelf.Componenet.Modal
{
    /// <summary>
    /// Interaction logic for ViewBidModal.xaml
    /// </summary>
    public partial class ViewBidModal : UserControl
    {
        public ViewBidModal()
        {
            InitializeComponent();
        }
        public int tokenID;
        Classes.contract contract = new Classes.contract();
        public void setViewBidModal(int tokenID)
        {
            this.tokenID = tokenID;
            loadHistroy();
        }
        private void CloseBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        public async void loadHistroy()
        {
            var allList = await contract.GetAllBidByTokenID(tokenID);
            for (int i = 0; i < allList.Count; i++)
            {
                HistoryGrid.Items.Add(new DataItem { Date = allList[i].Date, UserName = allList[i].Wallet, Bid = $"{allList[i].Amount} AELF" });
            }
        }

        private class DataItem
        {
            public string Date { get; set; }
            public string UserName { get; set; }
            public string Bid { get; set; }
        }
    }
}
