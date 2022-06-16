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
            JToken parsed = JObject.Parse(input);
            this.id = idno;
            this.title = parsed.SelectToken("Name").ToString();
            this.descrition = parsed.SelectToken("Description").ToString();
            this.price = float.Parse(parsed.SelectToken("Price").ToString());
            this.logo = parsed.SelectToken("Logo").ToString();
        }

        public int id;
        public string title;
        public string descrition;
        public float price;
        public string logo;
    }
}
