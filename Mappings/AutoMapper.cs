using AutoMapper;
using UberApp.Infrastructure;
using UberApp.Models;

namespace UberApp.Mappings
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            this.CreateMap<CarDto, CarModel>();
            this.CreateMap<CarModel, CarDto>();
            this.CreateMap<TripDto, TripModel>();
        }
    }
}
