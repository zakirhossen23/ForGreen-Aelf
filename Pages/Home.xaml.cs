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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void CreateEventBTN_Click(object sender, RoutedEventArgs e)
        {
            Pages.CreateEvents CreateEvents = new Pages.CreateEvents();
            MainWindow mainWindow = (MainWindow)Application.Current.Windows[0];
            mainWindow.MainFrame.Navigate(CreateEvents);
        }

        private void DonateBTN_Click(object sender, RoutedEventArgs e)
        {
            Pages.Donation donation = new Pages.Donation();
            MainWindow mainWindow = (MainWindow)Application.Current.Windows[0];
            mainWindow.MainFrame.Navigate(donation);
        }
    }
}
