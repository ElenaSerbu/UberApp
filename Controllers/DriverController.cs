using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UberApp.Data;
using UberApp.Infrastructure;
using UberApp.Interfaces;
using UberApp.Models;
using UberApp.Services;

namespace UberApp.Controllers
{
    public class DriverController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDriverService driverService;

        public DriverController(ApplicationDbContext dbContext, IMapper mapper, IDriverService driverService, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.userManager = userManager;
            this.driverService = driverService;
        }

        public IActionResult Index()
        {
            return this.View("Index");
        }

        public IActionResult AddCar()
        {
            return this.View("AddCar");
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(CarModel model)
        {
            var user = await this.userManager.GetUserAsync(this.HttpContext.User);

            if (this.ModelState.IsValid && user != null)
            {
                var carDto = this.mapper.Map<CarDto>(model);
                
                if(!await this.driverService.AddCar(carDto, user)){
                    this.ModelState.AddModelError("RegistrationNumber", "You can not register more than one car");
                }
            }

                return this.View("Index");
        }

        public async Task<IActionResult> RegisteredCars()
        {
            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
           
            if(user != null)
            {
                var registeredCars = this.driverService.GetRegisteredCars(user.Id);
                if(registeredCars.Count() > 0)
                {
                    return this.View(registeredCars);
                }
            }

            return this.View("Index");
        }

        public IActionResult AvailableTrips()
        {
            var trips = this.driverService.GetAvailableTrips();

            if(trips.Count()> 0)
            {
                return this.View(trips);
            }

            return this.View("Index");
        }

        public async Task<IActionResult> SelectTrip(int id)
        {
            var user = await this.userManager.GetUserAsync(this.HttpContext.User);

            try
            {
                await this.driverService.AddTrip(user.Id);

                return this.Redirect("https://localhost:44325/PAyment/Index");
            }
            catch (DbUpdateException)
            {
                return this.RedirectToAction(nameof(SelectTrip), new { id, saveChangesError = true });
            }
        }
    }
}
