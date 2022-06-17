using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForGreen_Aelf.ShortViews
{
    internal class NFTdetails
    {
        public NFTdetails(string input, int idno)
        {
            try
            {
                JToken parsed = JObject.Parse(input);
                this.id = idno;
                this.title = parsed.SelectToken("Name").ToString();
                this.descrition = parsed.SelectToken("Description").ToString();
                this.price = float.Parse(parsed.SelectToken("Price").ToString());
                this.logo = parsed.SelectToken("Logo").ToString();
            }
            catch (Exception){}
     
        }

        public int id;
        public string title;
        public string descrition;
        public float price;
        public string logo;

        public override string ToString()
        {
            return "{\"Name\": \""+ title + "\",\"Description\": \""+ descrition + "\",\"Price\": \""+ price + "\",\"Logo\": \""+ logo + "\"}";
        }
    }
}
