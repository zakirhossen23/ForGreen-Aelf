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
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Page
    {
        public LoginForm()
        {
            InitializeComponent();
        }


        private void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.PrivateKey = privateKeyTXT.Text;
            Properties.Settings.Default.Password = passwordTXT.Password;
            Properties.Settings.Default.LoggedIn = true;
            Properties.Settings.Default.Save();
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

            Componenet.Layout.Header header = mainWindow.HeaderLayout;
            header.LoginBTNShow();
            Pages.Home home = new Pages.Home();
            mainWindow.MainFrame.Navigate(home);
        }
    }
}
