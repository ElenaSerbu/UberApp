using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Data
{
    public class UserWatchlist
    {
        public int ID { get; set; }
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public string CompanyRegion { get; set; }
        public string MarketOpen { get; set; }
        public string MarketClose { get; set; }
        public double StockPrice { get; set; }
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
