
namespace BookingCar.Core.Domain.Drivers
{
    public class Driver:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public bool IsBusy { get; set; }
    }
}
