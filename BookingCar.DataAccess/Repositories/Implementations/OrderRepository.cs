using BookingCar.Core.Domain.Drivers;
using BookingCar.Core.Domain.Orders;
using BookingCar.DataAccess.DataBase;
using BookingCar.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingCar.DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _db;

        public OrderRepository(DataContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(Order entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Order entity)
        {
            _db.Orders.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Order> Update(Order entity)
        {
            _db.Orders.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _db.Orders.ToListAsync();
        }

        public async Task<Order> GetById(Guid id)
        {
            return await _db.Orders.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Driver> GetDriver(string firstName, string lastName, string patronymic)
        {
            return await _db.Drivers.FirstOrDefaultAsync(d => d.FirstName == firstName
               && d.LastName == lastName && d.Patronymic == patronymic);
        }
    }
}
