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

namespace ForGreen_Aelf.Componenet
{
    /// <summary>
    /// Interaction logic for EventFormat.xaml
    /// </summary>
    public partial class EventFormat : UserControl
    {
        public EventFormat()
        {
            InitializeComponent();
        }
        int id;
        string title; DateTime enddate; string goal; string logo;  string wallet;

        public void setEventFormat(int id, string title, DateTime enddate, string goal, string logo, string wallet)
        {
            this.id = id;
            this.title = title;
            this.TitleTXT.Text = title;
            this.enddate = enddate;
            timeLefting();

            this.goal = goal;
            this.GoalTXT.Text = goal;
            this.logo = logo;
            this.DataContext = logo;

            this.wallet = wallet;
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
             timeLefting();
         }

        private void timeLefting()
        {
            TimeSpan currentLeft = this.enddate - DateTime.Now;

            this.Dispatcher.InvokeAsync(new Action(() =>
            {
                this.leftDateTXT.Text = $"{currentLeft.Days} Days {currentLeft.Hours} hours {currentLeft.Minutes} minutes {currentLeft.Seconds} seconds";
            }));
        }
    }
}
