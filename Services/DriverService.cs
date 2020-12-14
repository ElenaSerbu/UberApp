using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UberApp.Data;
using UberApp.Infrastructure;
using UberApp.Interfaces;
using UberApp.Models;

namespace UberApp.Services
{
    public class DriverService : IDriverService
    {
        private readonly ApplicationDbContext dbContext;

        public DriverService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> AddCar(CarDto car, ApplicationUser user)
        {
            var carRegistered = this.dbContext.Car.ToList().Where(c => c.UserId == user.Id && c.IsActive);

            if (carRegistered.Count() > 0)
            {
                return false;
            }

            var carToBeAdded = new Car
            {
                Name = car.Name,
                Color = car.Color,
                RegistrationNumber = car.RegistrationNumber,
                RegisterTimestamp = car.RegisterTimestamp,
                IsActive = true,
                UserId = user.Id,
                User = user
            };

            this.dbContext.Car.Add(carToBeAdded);
            await this.dbContext.SaveChangesAsync();

            return true;
        }


        public async Task AddTrip(string userId)
        {
            var trip = this.dbContext.Trip.ToList().Where(t => t.UserId == userId).FirstOrDefault();

            if (trip != null)
            {
                trip.UserId = userId;

                await this.dbContext.SaveChangesAsync();
            }
        }

        public List<TripModel> GetAvailableTrips()
        {
            var availableTrips = this.dbContext.Trip.ToList().Where(t => t.UserId == null);
            var trips = new List<TripModel>();

            if (availableTrips.Count() > 0)
            {
                foreach (var trip in availableTrips)
                {
                    trips.Add(new TripModel
                    {
                        Id = trip.Id,
                        StartLocation = trip.StartLocation,
                        EndLocation = trip.EndLocation
                    });
                }
            }

            return trips;
        }

        public List<CarModel> GetRegisteredCars(string userId)
        {
            var carsRegistered = this.dbContext.Car.ToList().Where(c => c.UserId == userId);
            var cars = new List<CarModel>();

            if (carsRegistered.Count() > 0)
            {
                foreach (var car in carsRegistered)
                    cars.Add(new CarModel
                    {
                        Name = car.Name,
                        Color = car.Color,
                        RegistrationNumber = car.RegistrationNumber,
                        RegisterTimestamp = car.RegisterTimestamp,
                        IsActive = car.IsActive
                    });
            }

            return cars;
        }
    }
}

