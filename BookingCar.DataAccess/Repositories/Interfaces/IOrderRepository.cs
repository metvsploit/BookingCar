using BookingCar.Core.Domain.Drivers;
using BookingCar.Core.Domain.Orders;
using System.Threading.Tasks;

namespace BookingCar.DataAccess.Repositories.Interfaces
{
    public interface IOrderRepository:IBaseRepository<Order>
    {
        Task<Driver> GetDriver(string firstName, string lastName, string patronymic);
    }
}
