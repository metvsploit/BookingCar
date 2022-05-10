using System.ComponentModel.DataAnnotations;

namespace BookingCar.Core.Domain.ViewModels
{
    public class OrderViewModel
    {
        public string Comment { get; set; }

        [Required(ErrorMessage = "Не указана дата")]
        public string DateTimeDeparture { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        public string DriverName { get; set; }
        public string EmployeeName { get; set; }
    }
}
