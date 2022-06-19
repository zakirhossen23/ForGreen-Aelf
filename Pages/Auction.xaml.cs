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
            LoadButton();
        }
        Classes.contract contract = new Classes.contract();
        public int id;
        public string title;
        public string descrition;
        public DateTime enddate;
        public float price;
        public string type;
        public string logo;
        public string wallet;
        public void LoadButton()
        {
            if (Properties.Settings.Default.userType != "user")
            {
                DonateNFTBTN.Visibility = Visibility.Collapsed;
            }
            else
            {
                DonateNFTBTN.Visibility = Visibility.Visible;
            }
        }
    
        private void setLink(string link, string type)
        {
            if (type == null) return;
            if (type.Contains("image"))
            {
                LogoContainer.Children.Remove(videoSHOW);
            }
            else
            {
                LogoContainer.Children.Remove(logoIMG);
                videoSHOW.Source = new Uri(link);
            }
        }
        public void setAuction(int id, string title, string descrition, DateTime enddate, float price, string type, string logo, string wallet)
        {
            this.id = id;
            this.title = title;
            this.TitleTXT.Text = title;
            this.descrition = descrition;
            this.DescriptionTXT.Text = descrition;
            this.enddate = enddate;
            this.price = price;
            this.RaisedAelf.Text = $" raised of {price} AELF goal";
            this.type = type;
            this.logo = logo;
            this.DataContext = logo;
            setLink(logo, type);
            this.wallet = wallet;
            getAllNFTs();
        }


        public  async void getAllNFTs()
        {
            float totalEarned = 0;
            List<ShortViews.NFTdetails> nftDetails = await contract.GetAllNFTbyEventID(this.id);

            int total = NFTContainer.Children.Count-1;
            for (int i = total; i!=-1; i--)
            {
                NFTContainer.Children.RemoveAt(i);
            }
            for (int i = 0; i < nftDetails.Count; i++)
            {
                var element = nftDetails[i];
                Componenet.NFTFormat nFTFormat = new Componenet.NFTFormat();
                nFTFormat.setNFTFormat(element.id, this.id, element.title, element.descrition, this.enddate, element.price, element.logo, this.wallet, element.ToString());
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

        private void videoSHOW_MediaEnded(object sender, RoutedEventArgs e)
        {
            videoSHOW.Position = TimeSpan.Zero;
        }
    }
}
