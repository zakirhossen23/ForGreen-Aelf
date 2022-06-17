using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ForGreen_Aelf.Componenet
{
    /// <summary>
    /// Interaction logic for NFTFormat.xaml
    /// </summary>
    public partial class NFTFormat : UserControl
    {
        public NFTFormat()
        {
            InitializeComponent();
        }
        public int id;
        public int EventId;
        public string title;
        public string descrition;
        public DateTime enddate;
        public float price;
        public string logo;
        public string wallet;
        ShortViews.NFTdetails nFTdetails;
        public string nftinJSON;

        public void setNFTFormat(int id, int EventId, string title, string descrition, DateTime enddate, float price, string logo, string wallet, string nftinJSON )
        {
            this.id = id;
            this.EventId = EventId;
            this.title = title;
            this.TitleTXT.Text = title;
            this.descrition = descrition;
            this.DescriptionTXT.Text = descrition;
            this.enddate = enddate;
            timeLefting();
            this.price = price;
            this.PriceTXT.Text = $"{price} AELF";
            this.logo = logo;
            this.DataContext = logo;
            this.wallet = wallet;
            this.nftinJSON = nftinJSON;
            nFTdetails = new ShortViews.NFTdetails(nftinJSON, id);

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timeLefting();
        }

        private void timeLefting()
        {
            TimeSpan currentLeft = this.enddate - DateTime.Now;

            this.Dispatcher.InvokeAsync(new Action(() =>
            {
                this.leftDateTXT.Text = $"{currentLeft.Days}d {currentLeft.Hours}h {currentLeft.Minutes}m {currentLeft.Seconds}s";
            }));
        }
     

        private void BidBTN_Click(object sender, RoutedEventArgs e)
        {
            Componenet.Modal.BidNFT bidNFTModel = new Componenet.Modal.BidNFT();
            bidNFTModel.setBidNFT(this.id, this.EventId, this.price, this.wallet, this.title, this.nftinJSON);
            MainWindow mainWindow = (MainWindow)Application.Current.Windows[0];
            mainWindow.mainGrid.Children.Add(bidNFTModel);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Componenet.Modal.ViewBidModal viewNFTModel = new Componenet.Modal.ViewBidModal();
            viewNFTModel.setViewBidModal(this.id);
            MainWindow mainWindow = (MainWindow)Application.Current.Windows[0];
            mainWindow.mainGrid.Children.Add(viewNFTModel);
        }
    }
}
