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
using AElf.Client.MultiToken;
using ForGreen_Aelf.Classes;

namespace ForGreen_Aelf.Pages
{
    /// <summary>
    /// Interaction logic for Donation.xaml
    /// </summary>
    public partial class Donation : Page
    {
        contract contract = new contract();
        public Donation()
        {
            InitializeComponent();
            GetContract();
        }
        private async void GetContract()
        {
            
            List<ShortViews.EventDetails> eventDetails = await contract.GetAllEvent();
            EventContainer.Children.RemoveAt(0);
            for (int i = 0; i < eventDetails.Count; i++)
            {
                var element = eventDetails[i];
                Componenet.EventFormat eventFormat = new Componenet.EventFormat();
                eventFormat.setEventFormat(element.id,element.title, element.descrition, element.enddate, element.price.ToString(),element.Type,element.logo, element.wallet);
                eventFormat.Margin = new Thickness(0, 0, 0, 5);
                EventContainer.Children.Add(eventFormat);
            }

        }

    }
}
