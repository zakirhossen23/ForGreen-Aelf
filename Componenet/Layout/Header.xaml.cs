using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
using AElf.Client.Service;
using Newtonsoft.Json.Linq;

namespace ForGreen_Aelf.Componenet.Layout
{
    /// <summary>
    /// Interaction logic for Header.xaml
    /// </summary>
    public partial class Header : UserControl
    {
        public Header()
        {
            InitializeComponent();
            LoginBTNShow();
        }

        public async void LoginBTNShow()
        {
            Properties.Settings.Default.Reload();
            if (Properties.Settings.Default.LoggedIn == true)
            {
                AddressPanel.Visibility = Visibility.Visible;
                LoginPanel.Visibility = Visibility.Hidden;
                System.Timers.Timer timer = new System.Timers.Timer();
                timer.Elapsed += Timer_Elapsed;
                timer.Interval = 1000;
                timer.Start();
                loadAddressAndBalance();
            }
            else
            {
                AddressPanel.Visibility = Visibility.Hidden;
                LoginPanel.Visibility = Visibility.Visible;
            }
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Dispatcher.InvokeAsync(new Action(() =>
            {
                loadAddressAndBalance();
            }));

        }

        AElfClient client = new AElfClient("https://aelf-test-node.aelf.io");

        private async void loadAddressAndBalance()
        {
            try
            {
                string address = client.GetAddressFromPrivateKey(Properties.Settings.Default.PrivateKey);
                AddressTXT.Text = address.Substring(0, 15) + "...";
                var url = "https://explorer-test-side02.aelf.io/api/viewer/balances?address=" + address;

                var httpRequest = (HttpWebRequest)WebRequest.Create(url);


                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    JToken root = JObject.Parse(result);
                    JToken data = root.Last();
                    JToken dataBalance = JToken.Parse(data.Last.ToString());
                    var balance = ((JValue)((JProperty)((JContainer)((JContainer)dataBalance).First).Last).Value).Value;
                    BalanceTXT.Text = (float.Parse(balance.ToString())).ToString() + " ELF";
                }

            }
            catch (Exception)
            {
      }
          
        }

        public void homeBTN_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Pages.Home home = new Pages.Home();
            MainWindow mainWindow = (MainWindow)Application.Current.Windows[0];
            mainWindow.MainFrame.Navigate(home);

        }

        private void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
            Pages.Login.LoginSelector login = new Pages.Login.LoginSelector();
            MainWindow mainWindow = (MainWindow)Application.Current.Windows[0];
            mainWindow.MainFrame.Navigate(login);
        }

        private void LogoutBTN_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.LoggedIn = false;
            Properties.Settings.Default.PrivateKey = "";
            Properties.Settings.Default.Password = "";
            Properties.Settings.Default.userType = "";
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            LoginBTNShow();
        }

        private void donationBTN_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            Pages.Donation donation = new Pages.Donation();
            MainWindow mainWindow = (MainWindow)Application.Current.Windows[0];
            mainWindow.MainFrame.Navigate(donation);
        }


        private void CreateEventsBTN_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Pages.CreateEvents CreateEvents = new Pages.CreateEvents();
            MainWindow mainWindow = (MainWindow)Application.Current.Windows[0];
            mainWindow.MainFrame.Navigate(CreateEvents);
        }
    }
}
