using Newtonsoft.Json;
using System.Collections.Generic;

namespace Auth.Infrastructure
{
    public class CompaniesDTO
    {
        public List<CompanyDTO> BestMatches { get; set; }
    }
    public class CompanyDTO
    {
        [JsonProperty("1. symbol")]
        public string Symbol { get; set; }
        [JsonProperty("2. name")]
        public string Name { get; set; }
        [JsonProperty("3. type")]
        public string Type { get; set; }
        [JsonProperty("4. region")]
        public string Region { get; set; }
        [JsonProperty("5. marketOpen")]
        public string MarketOpen { get; set; }
        [JsonProperty("6. marketClose")]
        public string MarketClose { get; set; }
        [JsonProperty("7. timezone")]
        public string Timezone { get; set; }
        [JsonProperty("8. currency")]
        public string Currency { get; set; }
        [JsonProperty("9. matchScore")]
        public double MatchScore { get; set; }
    }
}
