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

namespace DemeterGift_Aelf.Componenet.Layout
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
                loadAddressAndBalance();
            }
            else
            {
                AddressPanel.Visibility = Visibility.Hidden;
                LoginPanel.Visibility = Visibility.Visible;
            }
        }
        AElfClient client = new AElfClient("https://aelf-test-node.aelf.io");

        private async void loadAddressAndBalance()
        {
            string address = client.GetAddressFromPrivateKey(Properties.Settings.Default.PrivateKey);
            AddressTXT.Text = address.Substring(0,15)+"...";
            var url = "https://tdvv-explorer-test.aelf.io/api/viewer/balances?address="+ address;

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);


            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                JToken root = JObject.Parse(result);
                JToken data = root.Last();
                JToken dataBalance = JToken.Parse(data.Last.ToString());
                var balance =((JValue)((JProperty)((JContainer)((JContainer)dataBalance).First).Last).Value).Value;
                BalanceTXT.Text =  (float.Parse( balance.ToString())).ToString() + " ELF";
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
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            LoginBTNShow();
        }
    }
}
