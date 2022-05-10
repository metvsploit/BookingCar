using BookingCar.Core.Domain;
using BookingCar.Core.Domain.Drivers;
using BookingCar.Core.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingCar.Service.Interfaces
{
    public interface IDriverService
    {
        Task<IBaseResponse<Driver>> GetDriverById(Guid id);
        Task<IBaseResponse<IEnumerable<Driver>>> GetAllDrivers();
        Task<IBaseResponse<DriverViewModel>> CreateDriver(DriverViewModel model);
        Task<IBaseResponse<bool>> DeleteDriver(Guid id);
        Task<IBaseResponse<Driver>> UpdateDriver(Guid id, DriverViewModel model);
    }
}
