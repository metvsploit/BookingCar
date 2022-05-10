using BookingCar.Core.Domain;
using BookingCar.Core.Domain.Employee;
using BookingCar.Core.Domain.Enum;
using BookingCar.Core.Domain.Helpers;
using BookingCar.Core.Domain.ViewModels;
using BookingCar.DataAccess.Repositories.Interfaces;
using BookingCar.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookingCar.Service.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public ClaimsIdentity Authenticate(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                new Claim("email", user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };

            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }

        public async Task<IBaseResponse<bool>> DeleteUser(Guid id)
        {
            var response = new UserResponse<bool>();

            try
            {
                var user = await _accountRepository.GetById(id);

                if (user == null)
                {
                    response.Description = "Пользователь не найден";
                    response.StatusCode = StatusCode.UserNotFound;
                    return response;
                }

                await _accountRepository.Delete(user);

                response.Description = "Пользователь удален";
                response.StatusCode = StatusCode.OK;
                return response;
            }
            catch (Exception ex)
            {
                return new UserResponse<bool>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServiceError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<User>>> GetAllUsers()
        {
            var response = new UserResponse<IEnumerable<User>>();

            try
            {
                var user = await _accountRepository.GetAll();

                if(user.Count() == 0)
                {
                    response.Description = "Найдено 0 пользователей";
                    response.StatusCode = StatusCode.OK;
                }
                else
                {
                    response.Data = user;
                    response.StatusCode = StatusCode.OK;
                }
                return response;
            }
            catch (Exception ex)
            {
                return new UserResponse<IEnumerable<User>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServiceError
                };
            }
        }

        public async Task<IBaseResponse<User>> GetUserByEmail(string name)
        {
            var response = new UserResponse<User>();

            try
            {
                var user = await _accountRepository.GetByName(name);

                if (user == null)
                {
                    response.Description = "Пользователь не найден";
                    response.StatusCode = StatusCode.UserNotFound;
                }
                else
                {
                    response.Description = $"Пользователь найден: {user.Name}|{user.Email}";
                    response.StatusCode = StatusCode.OK;
                }
                return response;
            }

            catch (Exception ex)
            {
                return new UserResponse<User>
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServiceError
                };
            }
        }

        public async Task<IBaseResponse<ClaimsIdentity>> Login(LoginModel model)
        {
            var response = new UserResponse<ClaimsIdentity>();

            try
            {
                var user = await _accountRepository.GetByName(model.Email);

                if(user == null)
                {
                    response.Description = "Пользователь не найден";
                    response.StatusCode = StatusCode.UserNotFound;
                    return response;
                }

                var hash = user.Password;

                if (!hash.Verification(model.Password))
                {
                    response.Description = "Неверный пароль";
                    return response;
                }

                var result = Authenticate(user);
                response.StatusCode=StatusCode.OK;
                response.Data = result;
                return response;
            }

            catch(Exception ex)
            {
                return new UserResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServiceError
                };
            }
        }

        public async Task<IBaseResponse<ClaimsIdentity>> Register(UserViewModel model)
        {
            var response = new UserResponse<ClaimsIdentity>();

            try
            {
                var user = await _accountRepository.GetByName(model?.Email);

                if(user != null)
                {
                    response.Description = "Пользователь с такими данными уже существует";
                    return response;
                }

                var newUser = new User()
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password.HashPassword(),
                    Role = Role.User
                };

                await _accountRepository.Create(newUser);
                var result = Authenticate(newUser);

                response.Data = result;
                response.Description = "Пользователь создан";
                response.StatusCode = StatusCode.OK;
                return response;
            }
            catch (Exception ex)
            {
                return new UserResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServiceError
                };
            }
        }
    }
}

