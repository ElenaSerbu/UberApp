using Auth.Models;
using System.Threading.Tasks;

namespace Auth.Interfaces
{
    public interface IWatchlistService
    {
        Task<CompaniesModel> GetCompanies(string symbol);
        Task<CompanyOverviewModel> GetCompanyOverview(string symbol);
    }
}
