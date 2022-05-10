using BookingCar.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookingCar.WebApp.Controllers
{
    public class DriverController : Controller
    { 
        private readonly IDriverService _driverService;
        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }
        public IActionResult CreateDriver()
        {
            return View();
        }

        public IActionResult GetDrivers()
        {
            var drivers = _driverService.GetAllDrivers().Result.Data;
            var json = JsonConvert.SerializeObject(drivers);
            System.IO.File.WriteAllText("drivers.json", json);
            return View();
        }
    }
}
