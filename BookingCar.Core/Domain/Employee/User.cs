using BookingCar.Core.Domain.Enum;

namespace BookingCar.Core.Domain.Employee
{
    public class User:BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
