using BookingCar.Core.Domain;
using BookingCar.Core.Domain.Drivers;
using BookingCar.Core.Domain.Enum;
using BookingCar.Core.Domain.ViewModels;
using BookingCar.DataAccess.Repositories.Interfaces;
using BookingCar.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingCar.Service.Implementations
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;

        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }
        public async Task<IBaseResponse<DriverViewModel>> CreateDriver(DriverViewModel model)
        {
            var response = new DriverResponse<DriverViewModel>();

            try
            {
                var driverModel = new Driver()
                {
                    Id = new Guid(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Patronymic = model.Patronymic,
                    IsBusy = true
                };
                await _driverRepository.Create(driverModel);
                response.Description = "Водитель добавлен в базу данных";
                response.StatusCode = StatusCode.OK;
                return response;
            }
            catch (Exception ex)
            {
                return new DriverResponse<DriverViewModel>()
                {
                    Description = $"Не удалось добавить водителя в базу данных: {ex.Message}",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteDriver(Guid id)
        {
            var response = new DriverResponse<bool>();

            try
            {
                var driver = await _driverRepository.GetById(id);
                if (driver == null)
                {
                    response.Description = "Водитель не найден";
                    response.StatusCode = StatusCode.OK;
                }
                else
                {
                    await _driverRepository.Delete(driver);
                    response.StatusCode = StatusCode.OK;
                }
                return response;
            }
            catch (Exception ex)
            {
                return new DriverResponse<bool>()
                {
                    Description = $"Не удалось удалить водителя: {ex.Message}",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Driver>>> GetAllDrivers()
        {
            var response = new DriverResponse<IEnumerable<Driver>>();

            try
            {
                var drivers = await _driverRepository.GetAll();
                if (drivers.Count() == 0)
                {
                    response.Description = "Найдено 0 элементов";
                    response.StatusCode = StatusCode.OK;
                }
                else
                {
                    response.Data = drivers;
                    response.StatusCode = StatusCode.OK;
                }
                return response;
            }
            catch (Exception ex)
            {
                return new DriverResponse<IEnumerable<Driver>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServiceError
                };
            }
        }

        public async Task<IBaseResponse<Driver>> GetDriverById(Guid id)
        {
            var response = new DriverResponse<Driver>();

            try
            {
                var driver = await _driverRepository.GetById(id);

                if (driver == null)
                {
                    response.Description = "Водитель не найден";
                    response.StatusCode = StatusCode.NotFound;
                }
                else
                {
                    response.Data = driver;
                    response.StatusCode = StatusCode.OK;
                }
                return response;
            }
            catch (Exception ex)
            {
                return new DriverResponse<Driver>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServiceError
                };
            }
        }

        public async Task<IBaseResponse<Driver>> UpdateDriver(Guid id, DriverViewModel model)
        {
            var response = new DriverResponse<Driver>();

            try
            {
                var driver = await _driverRepository.GetById(id);

                if (driver == null)
                {
                    response.Description = "Заявка не найдена";
                    response.StatusCode = StatusCode.NotFound;
                }
                else
                {
                    driver.FirstName = model.FirstName;
                    driver.LastName = model.LastName;
                    driver.Patronymic = model.Patronymic;
                    driver.IsBusy = model.IsBusy;
                    await _driverRepository.Update(driver);
                }
                return response;
            }
            catch (Exception ex)
            {
                return new DriverResponse<Driver>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServiceError
                };
            }
        }
    }
}
