using BookingCar.Core.Domain.Employee;
using System.Threading.Tasks;

namespace BookingCar.DataAccess.Repositories.Interfaces
{
    public interface IAccountRepository:IBaseRepository<User>
    {
        Task<User> GetByName(string name);
    }
}
