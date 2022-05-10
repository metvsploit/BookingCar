using BookingCar.Core.Domain;
using BookingCar.Core.Domain.Employee;
using BookingCar.Core.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookingCar.Service.Interfaces
{
    public interface IAccountService
    {
        Task<IBaseResponse<IEnumerable<User>>> GetAllUsers();
        Task<IBaseResponse<User>> GetUserByEmail(string name);
        Task<IBaseResponse<ClaimsIdentity>> Register(UserViewModel model);
        Task<IBaseResponse<ClaimsIdentity>> Login(LoginModel model);
        Task<IBaseResponse<bool>> DeleteUser(Guid id);
    }
}
