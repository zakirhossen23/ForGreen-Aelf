using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForGreen_Aelf.ShortViews
{
    internal class EventDetails
    {
        public EventDetails(string input,int idno)
        {
            JToken parsed =  JObject.Parse(input);
            this.id = idno;
            this.title = parsed.SelectToken("Title").ToString();
            this.descrition = parsed.SelectToken("Description").ToString();
            this.enddate = DateTime.Parse( parsed.SelectToken("['End Date']").ToString());
            this.price = float.Parse(parsed.SelectToken("Goal").ToString());
            try
            {
                this.Type = parsed.SelectToken("Type").ToString();
            }
            catch (Exception) { }
            this.logo = parsed.SelectToken("['Logo Link']").ToString();            
            this.wallet = parsed.SelectToken("Wallet").ToString();
        }

        public int id;
        public string title;
        public string descrition;
        public DateTime enddate;
        public float price;
        public string logo;
        public string Type;
        public string wallet;
    }
}
