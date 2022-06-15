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

namespace ForGreen_Aelf.Pages.Login
{
    /// <summary>
    /// Interaction logic for LoginSelector.xaml
    /// </summary>
    public partial class LoginSelector : Page
    {
        public LoginSelector()
        {
            InitializeComponent();
        }

        private void LoginForm()
        {
            Pages.Login.LoginForm login = new Pages.Login.LoginForm();
            MainWindow mainWindow = (MainWindow)Application.Current.Windows[0];
            mainWindow.MainFrame.Navigate(login);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.userType = "manager";
            LoginForm();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.userType = "user";
            LoginForm();
        }
    }
}
