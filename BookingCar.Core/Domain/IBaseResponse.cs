using BookingCar.Core.Domain.Enum;

namespace BookingCar.Core.Domain
{
    public interface IBaseResponse<T>
    {
        public string Description { get; set; }
        public StatusCode StatusCode { get; set; }
        public T Data { get; set; }
    }
}
