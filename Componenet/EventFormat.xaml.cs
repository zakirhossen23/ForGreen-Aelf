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

namespace ForGreen_Aelf.Componenet
{
    /// <summary>
    /// Interaction logic for EventFormat.xaml
    /// </summary>
    public partial class EventFormat : UserControl
    {
        public EventFormat()
        {
            InitializeComponent();
            LoadAuction();
        }
        int id;
        string title; string description; DateTime enddate; string goal; string type; string logo; string wallet;
        public void LoadAuction()
        {
            if (Properties.Settings.Default.userType != "user")
            {
                DonateBTN.Visibility = Visibility.Collapsed;
            }
            else
            {
                DonateBTN.Visibility = Visibility.Visible;
            }
        }
        private void setLink(string link, string type)
        {
            if (type == null) return;
            if (type.Contains("image"))
            {
                
                videoSHOW.Visibility = Visibility.Collapsed;
            }
            else
            {
                imageSHOW.Visibility = Visibility.Collapsed;
                videoSHOW.Source = new Uri(link);
            }
        }
        public void setEventFormat(int id, string title, string description, DateTime enddate, string goal, string type, string logo, string wallet)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.TitleTXT.Text = title;
            this.enddate = enddate;
            timeLefting();

            this.goal = goal;
            this.GoalTXT.Text = $"Goal: {goal} aelf";
            this.logo = logo;
            this.DataContext = logo;
            this.type = type;
            setLink(logo, type);

            this.wallet = wallet;
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timeLefting();
        }

        private void timeLefting()
        {
            TimeSpan currentLeft = this.enddate - DateTime.Now;

            this.Dispatcher.InvokeAsync(new Action(() =>
            {
                this.leftDateTXT.Text = $"{currentLeft.Days} Days {currentLeft.Hours} hours {currentLeft.Minutes} minutes {currentLeft.Seconds} seconds";
            }));
        }


        private void DonateBTN_Click(object sender, RoutedEventArgs e)
        {
            Componenet.Modal.DonateNFTModel donateNFTModel = new Componenet.Modal.DonateNFTModel();
            donateNFTModel.setDonateNFTModel(this.id, this.title);
            MainWindow mainWindow = (MainWindow)Application.Current.Windows[0];
            mainWindow.mainGrid.Children.Add(donateNFTModel);
        }

        private void AuctionBTN_Click(object sender, RoutedEventArgs e)
        {
            Pages.Auction auction = new Pages.Auction();
            auction.setAuction(id, title, description, enddate, int.Parse(goal),type , logo, wallet);
            MainWindow mainWindow = (MainWindow)Application.Current.Windows[0];
            mainWindow.MainFrame.Navigate(auction);
        }

        private void videoSHOW_MediaEnded(object sender, RoutedEventArgs e)
        {
            videoSHOW.Position = TimeSpan.Zero;
        }
    }
}
