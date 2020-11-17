using Auth.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auth
{
    public interface IWatchList
    {
        Task<List<CompaniesDTO>> SearchCompanyBySymbol(string symbol);
    }
}
