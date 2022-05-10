using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingCar.DataAccess.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T entity);
        Task<bool> Delete(T entity);
        Task<T> Update(T entity);
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
    }
}
