using BookingCar.Core.Domain.Employee;
using BookingCar.DataAccess.DataBase;
using BookingCar.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingCar.DataAccess.Repositories.Implementations
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataContext _db;

        public AccountRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(User entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(User entity)
        {
            _db.Users.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _db.Users.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<User> GetByName(string name)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Email == name);
        }

        public async Task<User> Update(User entity)
        {
            _db.Users.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
