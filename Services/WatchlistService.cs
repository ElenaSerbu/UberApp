using Auth.Interfaces;
using Auth.Models;
using AutoMapper;
using System.Threading.Tasks;

namespace Auth.Services
{
    public class WatchlistService : IWatchlistService
    {
        private readonly IGetCompaniesRequest companiesRequest;
        private readonly IMapper mapper;

        public WatchlistService(IGetCompaniesRequest companiesRequest, IMapper mapper)
        {
            this.companiesRequest = companiesRequest;
            this.mapper = mapper;
        }

        public async Task<CompanyOverviewModel> GetCompanyOverview(string symbol)
        {
            var companyOverviewDTO = await this.companiesRequest.GetCompanyOverview(symbol);
            var companyOverview = this.mapper.Map<CompanyOverviewModel>(companyOverviewDTO);

            return companyOverview;
        }

        public async Task<CompaniesModel> GetCompanies(string symbol)
        {
            var companiesDTO = await this.companiesRequest.GetCompanies(symbol);
            var companies = this.mapper.Map<CompaniesModel>(companiesDTO);

            return companies;
        }
    }
}
