
namespace BookingCar.Core.Domain.Orders
{
    public class Order:BaseEntity
    {
        public string Comment { get; set; }
        public string DateTimeDeparture { get; set; }
        public string DriverName { get; set; }
        public string EmployeeName { get; set; }
    }
}
