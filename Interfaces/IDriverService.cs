using System.Collections.Generic;
using System.Threading.Tasks;
using UberApp.Data;
using UberApp.Infrastructure;
using UberApp.Models;

namespace UberApp.Interfaces
{
    public interface IDriverService
    {
        Task<bool> AddCar(CarDto car, ApplicationUser user);
        List<CarModel> GetRegisteredCars(string userId);
        List<TripModel> GetAvailableTrips();
        Task AddTrip(string userId);
    }
}
