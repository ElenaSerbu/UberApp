using Auth.Infrastructure;
using System.Threading.Tasks;

namespace Auth.Interfaces
{
    public interface IGetCompaniesRequest
    {
        Task<CompaniesDTO> GetCompanies(string symbol);
        Task<CompanyOverviewDTO> GetCompanyOverview(string symbol);
    }
}
