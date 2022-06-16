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

namespace ForGreen_Aelf.Pages
{
    /// <summary>
    /// Interaction logic for Auction.xaml
    /// </summary>
    public partial class Auction : Page
    {
        public Auction()
        {
            InitializeComponent();
        }
        Classes.contract contract = new Classes.contract();
        public int id;
        public string title;
        public string descrition;
        public DateTime enddate;
        public float price;
        public string logo;
        public string wallet;
        public void setAuction(int id, string title, string descrition, DateTime enddate, float price, string logo, string wallet)
        {
            this.id = id;
            this.title = title;
            this.TitleTXT.Text = title;
            this.descrition = descrition;
            this.enddate = enddate;
            this.price = price;
            this.RaisedAelf.Text = $" raised of {price} AELF goal";
            this.logo = logo;
            this.DataContext = logo;
            this.wallet = wallet;
            getAllNFTs();
        }


        public async void getAllNFTs()
        {
            float totalEarned = 0;
            List<ShortViews.NFTdetails> nftDetails = await contract.GetAllNFTbyEventID(this.id);
            NFTContainer.Children.RemoveAt(0);
            for (int i = 0; i < nftDetails.Count; i++)
            {
                var element = nftDetails[i];
                Componenet.NFTFormat nFTFormat = new Componenet.NFTFormat();
                nFTFormat.setNFTFormat(element.id, element.title, element.descrition, this.enddate, element.price, element.logo);
                nFTFormat.Margin = new Thickness(0, 0, 0, 5);
                NFTContainer.Children.Add(nFTFormat);
                totalEarned += element.price;

            }
            this.EarntAelf.Text = $"{totalEarned} Aelf";
            this.ProgressEarning.Value = 100/(this.price / totalEarned)  ;

        }

        private void DonateNFTBTN_Click(object sender, RoutedEventArgs e)
        {
            Componenet.Modal.DonateNFTModel donateNFTModel = new Componenet.Modal.DonateNFTModel();
            donateNFTModel.setDonateNFTModel(this.id, this.title);
            MainWindow mainWindow = (MainWindow)Application.Current.Windows[0];
            mainWindow.mainGrid.Children.Add(donateNFTModel);
        }
    }
}
