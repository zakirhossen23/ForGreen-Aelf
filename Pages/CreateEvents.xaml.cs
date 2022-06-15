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
        }
        Classes.contract contract = new Classes.contract();

        public void clearTextBoxes(List<TextBox> allControls)
        {
            foreach (var control in allControls)
            {
                control.Clear();
            }
        }

        private async void CreatEventBTN_Click(object sender, RoutedEventArgs e)
        {
            CreatEventBTN.IsEnabled = false;
            Dictionary<string, string> InputOBJ = new Dictionary<string, string>();
            InputOBJ.Add("Title", EventTitleTXT.Text);
            InputOBJ.Add("End Date", EventEndDateTXT.Text);
            InputOBJ.Add("Goal", EventGoalTXT.Text);
            InputOBJ.Add("Logo Link", EventLogoLinkTXT.Text);
            InputOBJ.Add("Wallet", await contract.GetWalletAddress());


            var output =  await contract.CreateEvent(InputOBJ);

            Console.WriteLine(output);
            clearTextBoxes(new List<TextBox>() { EventTitleTXT, EventGoalTXT, EventLogoLinkTXT });
            EventEndDateTXT.Text ="";
            CreatEventBTN.IsEnabled = true;
        }
    }
}
