using BookingCar.Core.Domain.ViewModels;
using BookingCar.Service.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookingCar.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IActionResult> Register(UserViewModel model)
        {
          
            if (ModelState.IsValid)
            {
                var response = await _accountService.Register(model);

                if(response.StatusCode == Core.Domain.Enum.StatusCode.OK)
                {
                    var data = GetMyData();
                    return View("Profile", data);
                }
                else
                    return View("Error", response.Description);
            }
            return View(model);
        }

   
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                var response = await _accountService.Login(model);

                if(response.StatusCode == Core.Domain.Enum.StatusCode.OK)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(response.Data));

                    return PartialView("_SuccessfullLogin");
                }
                ModelState.AddModelError("Email", response.Description);
            }
            return Content("Неверный логин или пароль");
        }
        
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home");
        }

        [Authorize]
        public IActionResult Profile()
        {
            var data = GetMyData();

            return View(data);
        }

        private UserViewModel GetMyData()
        {
            var data = User.Claims.ToList();
            var user = new UserViewModel();

            user.Name = data[0].Value;
            user.Email = data[1].Value;

            return user;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AllUsers()
        {
            var users = await _accountService.GetAllUsers();

            if(users.StatusCode == Core.Domain.Enum.StatusCode.OK)
                return View(users.Data.ToList());

            return RedirectToAction("Error", users.Description);
        }
    }
}
