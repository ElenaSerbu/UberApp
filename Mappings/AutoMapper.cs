using Auth.Infrastructure;
using Auth.Interfaces;
using Auth.Models;
using AutoMapper;

namespace Auth.Mappings
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            this.CreateMap<CompanyDTO, CompanyModel>();
            this.CreateMap<CompaniesDTO, CompaniesModel>();
            this.CreateMap<CompanyOverviewDTO, CompanyOverviewModel>();
        }
    }
}
