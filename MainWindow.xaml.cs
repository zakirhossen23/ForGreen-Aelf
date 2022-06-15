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
using AElf.Client.Service;

namespace ForGreen_Aelf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        AElfClient client = new AElfClient("https://tdvw-test-node.aelf.io");

        private void Button_Click(object sender, RoutedEventArgs e)
        {
      
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Pages.Home home = new Pages.Home();
            MainFrame.Navigate(home);
        }
    }
}
