using BookingCar.Core.Domain.Drivers;
using BookingCar.DataAccess.DataBase;
using BookingCar.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingCar.DataAccess.Repositories.Implementations
{
    public class DriverRepository : IDriverRepository
    {
        private readonly DataContext _db;
        public DriverRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Driver entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Driver entity)
        {
             _db.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Driver>> GetAll()
        {
            return await _db.Drivers.ToListAsync();
        }

        public async Task<Driver> GetById(Guid id)
        {
            return await _db.Drivers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Driver> Update(Driver entity)
        {
            _db.Drivers.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
