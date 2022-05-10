using BookingCar.Core.Domain.Drivers;
using BookingCar.Core.Domain.Employee;
using BookingCar.Core.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace BookingCar.DataAccess.DataBase
{
    public class DataContext:DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(FakeDataFactory.Users);
            builder.Entity<Driver>().HasData(FakeDataFactory.Drivers);
        }

    }
}
