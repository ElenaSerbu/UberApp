using Newtonsoft.Json;

namespace Auth.Interfaces
{
    public class CompanyOverviewDTO
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("PERatio")]
        public double PERatio { get; set; }
        [JsonProperty("DividendPerShare")]
        public double DividendPerShare { get; set; }
    }
}