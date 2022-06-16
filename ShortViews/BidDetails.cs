using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForGreen_Aelf.ShortViews
{
    internal class BidDetails
    {
        public BidDetails(string input)
        {
            JToken parsed =  JObject.Parse(input);
            this.Wallet = parsed.SelectToken("Wallet").ToString();
            this.Amount =  parsed.SelectToken("Amount").ToString();
            this.Date = parsed.SelectToken("Date").ToString();
        }

        public string Wallet;
        public string Amount;
        public string Date;
    }
}
