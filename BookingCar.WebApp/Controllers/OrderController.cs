using BookingCar.Core.Domain.Drivers;
using BookingCar.Core.Domain.ViewModels;
using BookingCar.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookingCar.WebApp.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        private static DictionaryOfDrivers _driversOfDictionary = new DictionaryOfDrivers();
        private IWebHostEnvironment _appEnvironment;

        public OrderController(IOrderService orderService, IWebHostEnvironment appEnvironment)
        {
            _orderService = orderService;
            _appEnvironment = appEnvironment;
        }
        
        [Authorize]
        [Route("Account/Profile/CreateOrder")]
        public IActionResult CreateOrder()
        {
            string value;
            string path = _appEnvironment.WebRootPath + "/files/drivers.json";

            using (var reader = new StreamReader(path))
                value = reader.ReadToEnd();

            var drivers = JsonConvert.DeserializeObject<IEnumerable<DriverViewModel>>(value);
            
            foreach(var driver in drivers)
            {
                _driversOfDictionary.Add(driver.LastName.ToLower(), driver);
                _driversOfDictionary.Add(driver.FirstName.ToLower(), driver);
                _driversOfDictionary.Add(driver.Patronymic.ToLower(), driver);
                _driversOfDictionary.Add(driver.ToString().ToLower(), driver);
            }
            return View();
        }

        [Authorize]
        [HttpPost]
        public JsonResult GetByPrefix(string prefix)
        {
            var result = new HashSet<DriverViewModel>();

            if (!string.IsNullOrWhiteSpace(prefix))
                _driversOfDictionary.GetByPrefix(prefix.ToLower(), result);

            return Json(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SaveOrder(OrderViewModel model)
        {
            model.EmployeeName = User.Identity.Name;

            if (ModelState.IsValid)
            {
                var response = await _orderService.CreateOrder(model);
                if (response.StatusCode == Core.Domain.Enum.StatusCode.OK)
                    return PartialView("_Successfull");
                else
                    return PartialView("_Error", response.Description);

            }
            return View(model);
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var response = await _orderService.GetAllOrders();

            if(response.StatusCode == Core.Domain.Enum.StatusCode.OK)
                return View(response.Data);

            return RedirectToAction("Error");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var response = await _orderService.GetOrderById(id);

            if(response.StatusCode == Core.Domain.Enum.StatusCode.OK)
                return View(response.Data);

            return RedirectToAction("Error");
        }

        [Authorize(Roles ="Admin")]
        
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var response = await _orderService.DeleteOrder(id);

            if (response.StatusCode == Core.Domain.Enum.StatusCode.OK)
            {
                return View("Profile");
            }
            return RedirectToAction("Error");
        }

        [Authorize]
        [Route("Account/Profile/MyOrders")]
        public async Task<IActionResult> MyOrders()
        {
            var response = await _orderService.GetOrderByName(User.Identity.Name);

            return View(response.Data.ToList());
        }

        [Authorize]
        [Route("Account/Profile/Edit")]
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id)
        {
            var order = await _orderService.GetOrderById(id);

            string value;
            string path = _appEnvironment.WebRootPath + "/files/drivers.json";

            using (var reader = new StreamReader(path))
                value = reader.ReadToEnd();

            var drivers = JsonConvert.DeserializeObject<IEnumerable<DriverViewModel>>(value);

            foreach (var driver in drivers)
            {
                _driversOfDictionary.Add(driver.LastName.ToLower(), driver);
                _driversOfDictionary.Add(driver.FirstName.ToLower(), driver);
                _driversOfDictionary.Add(driver.Patronymic.ToLower(), driver);
                _driversOfDictionary.Add(driver.ToString().ToLower(), driver);
            }

            return View(order.Data);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Update(OrderViewModel model, Guid id)
        {
            var response = await _orderService.UpdateOrder(id, model);

            if (response.StatusCode == Core.Domain.Enum.StatusCode.OK)
                return PartialView("_Successfull");
            else
                return PartialView("_Error", response.Description);
        }

        [Authorize(Roles ="Admin")]
        [Route("Account/Profile/Orders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var response = await _orderService.GetAllOrders();
            return View("MyOrders",response.Data);
        }
    }
}
