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
    /// Interaction logic for CreateEvents.xaml
    /// </summary>
    public partial class CreateEvents : Page
    {
        public CreateEvents()
        {
            InitializeComponent();
            LoadButton();
        }
        Classes.contract contract = new Classes.contract();
        public void LoadButton()
        {
            if (Properties.Settings.Default.userType != "manager")
            {
                CreatEventBTN.Content = "Login as Event Manager";
            }
            else
            {
                CreatEventBTN.Content = "Create Event";
            }
        }
        public void clearTextBoxes(List<TextBox> allControls)
        {
            foreach (var control in allControls)
            {
                control.Clear();
            }
        }

        private async void CreatEventBTN_Click(object sender, RoutedEventArgs e)
        {

            if (Properties.Settings.Default.userType != "manager")
            {
                Pages.Login.LoginSelector login = new Pages.Login.LoginSelector();
                MainWindow mainWindow = (MainWindow)Application.Current.Windows[0];
                mainWindow.MainFrame.Navigate(login);
            }
            else
            {
                CreatEventBTN.IsEnabled = false;
                Dictionary<string, string> InputOBJ = new Dictionary<string, string>();
                InputOBJ.Add("Title", EventTitleTXT.Text);
                InputOBJ.Add("End Date", EventEndDateTXT.Text);
                InputOBJ.Add("Goal", EventGoalTXT.Text);
                InputOBJ.Add("Logo Link", EventLogoLinkTXT.Text);
                InputOBJ.Add("Wallet", await contract.GetWalletAddress());


                var output = await contract.CreateEvent(InputOBJ);

                Console.WriteLine(output);
                clearTextBoxes(new List<TextBox>() { EventTitleTXT, EventGoalTXT, EventLogoLinkTXT });
                EventEndDateTXT.Text = "";
                CreatEventBTN.IsEnabled = true;
            }
          
        }
    }
}
