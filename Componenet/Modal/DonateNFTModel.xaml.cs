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

namespace ForGreen_Aelf.Componenet.Modal
{
    /// <summary>
    /// Interaction logic for DonateNFTModel.xaml
    /// </summary>
    public partial class DonateNFTModel : UserControl
    {
        public DonateNFTModel()
        {
            InitializeComponent();
        }
        public void setDonateNFTModel(int eventID, string EventName)
        {
            this.EventID = eventID;
            this.HeaderTitle.Text = $"Donate NFT - {EventName}";
        }

        Classes.contract contract = new Classes.contract();
        private int EventID; 
        public void clearTextBoxes(List<TextBox> allControls)
        {
            foreach (var control in allControls)
            {
                control.Clear();
            }
        }
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private async void DonateBTN_Click(object sender, RoutedEventArgs e)
        {
            DonateBTN.IsEnabled = false;
            Dictionary<string, string> InputOBJ = new Dictionary<string, string>();
            InputOBJ.Add("Name", nameTXT.Text);
            InputOBJ.Add("Description", descriptionTXT.Text);
            InputOBJ.Add("Price", priceTXT.Text);
            InputOBJ.Add("Logo", logoTXT.Text);


            var output = await contract.CreateToken(EventID.ToString(),InputOBJ);

            Console.WriteLine(output);
            clearTextBoxes(new List<TextBox>() { nameTXT, descriptionTXT, priceTXT, logoTXT, nftAddressTXT });
            DonateBTN.IsEnabled = true;
        }
    }
}
