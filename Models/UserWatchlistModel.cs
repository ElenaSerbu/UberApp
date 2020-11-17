namespace Auth.Models
{
    public class UserWatchlistModel
    {
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public string CompanyRegion { get; set; }
        public string MarketOpen { get; set; }
        public string MarketClose { get; set; }
        public double StockPrice { get; set; }
    }
}
