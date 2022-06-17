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

namespace ForGreen_Aelf.Componenet.Modal
{
    /// <summary>
    /// Interaction logic for BidNFT.xaml
    /// </summary>
    public partial class BidNFT : UserControl
    {
        public BidNFT()
        {
            InitializeComponent();
        }
        public int id;
        public int Eventid;
        public string title;
        public float price;
        public string wallet;
        ShortViews.NFTdetails nFTdetails;
        public string nftinJSON;
        Classes.contract contract = new Classes.contract();
        public void clearTextBoxes(List<TextBox> allControls)
        {
            foreach (var control in allControls)
            {
                control.Clear();
            }
        }
        public void setBidNFT(int id,int Eventid, float price, string wallet, string title, string nftinJSON)
        {
            this.id = id;
            this.Eventid = Eventid;
            this.price = price;
            this.wallet = wallet;
            this.title = title; 
            this.nftinJSON = nftinJSON;
            nFTdetails = new ShortViews.NFTdetails(nftinJSON, id);

        }
        private void CloseBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
        private void Alert(string AlertText)
        {
            this.SizeBox.Height = SizeBox.MaxHeight;
            this.AlertBox.Visibility = Visibility.Visible;
            this.AlertMessage.Text = AlertText;
        }

        private async void BidBTN_Click(object sender, RoutedEventArgs e)
        {
            BidBTN.IsEnabled = false;
            if (this.price < float.Parse(amountTXT.Text))
            {
                double amount = double.Parse(amountTXT.Text);
                Alert($"A moment please");
                await contract.sendMoney(await contract.GetWalletAddress(), amount, $"Bid for {this.title}");
                nFTdetails.price = float.Parse(amountTXT.Text);
                Dictionary<string, string> InputOBJ = new Dictionary<string, string>();
                InputOBJ.Add("Wallet", await contract.GetWalletAddress());
                InputOBJ.Add("Amount", amountTXT.Text);
                InputOBJ.Add("Date", DateTime.Now.ToShortDateString());
                var output = await contract.CreateBid(this.id, this.Eventid, InputOBJ, nFTdetails.ToString());
                clearTextBoxes(new List<TextBox>() { amountTXT });
                this.Visibility = Visibility.Collapsed;
                MainWindow mainWindow = (MainWindow)Application.Current.Windows[0];
                Pages.Auction auction =  (Pages.Auction)mainWindow.MainFrame.Content;
                auction.getAllNFTs();
               }
            else
            {
                Alert($"Amount should be above {this.price}");
            }

            BidBTN.IsEnabled = true;
        }
    }
}
