using Auth.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth.Infrastructure
{
    public class GetCompaniesRequest : IGetCompaniesRequest
    {
        public Microsoft.Extensions.Configuration.IConfiguration configuration { get; }

        public GetCompaniesRequest(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<CompaniesDTO> GetCompanies(string symbol)
        {
            try
            {
                var getCompaniesUrl = this.configuration["GetCompaniesRequest"];
                var apikey = this.configuration["apikey"];
                var function = this.configuration["functionSymbol"];
                var url = $"{getCompaniesUrl}?function={function}&keywords={symbol}&apikey={apikey}";

                using (var httpClientRequest = new HttpRequestMessage(HttpMethod.Get, url))
                using (var httpClient = new HttpClient())
                using (var httpReponse = await httpClient.SendAsync(httpClientRequest))
                {
                    httpReponse.EnsureSuccessStatusCode();

                    var companiesJson = await httpReponse.Content.ReadAsStringAsync();
                    var companiesData = JsonConvert.DeserializeObject<CompaniesDTO>(companiesJson);
                    return companiesData;
                }

            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        public async Task<CompanyOverviewDTO> GetCompanyOverview(string symbol)
        {
            try
            {
                var getCompaniesUrl = this.configuration["GetCompaniesRequest"];
                var apikey = this.configuration["apikey"];
                var function = this.configuration["functionOverview"];
                var url = $"{getCompaniesUrl}?function={function}&symbol={symbol}&apikey={apikey}";

                using (var httpClientRequest = new HttpRequestMessage(HttpMethod.Get, url))
                using (var httpClient = new HttpClient())
                using (var httpReponse = await httpClient.SendAsync(httpClientRequest))
                {
                    httpReponse.EnsureSuccessStatusCode();

                    var companiesJson = await httpReponse.Content.ReadAsStringAsync();
                    var companiesData = JsonConvert.DeserializeObject<CompanyOverviewDTO>(companiesJson);
                    return companiesData;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
