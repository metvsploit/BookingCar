using BookingCar.Core.Domain;
using BookingCar.Core.Domain.Drivers;
using BookingCar.Core.Domain.Orders;
using BookingCar.Core.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingCar.Service.Interfaces
{
    public interface IOrderService
    {
        Task<IBaseResponse<Order>> GetOrderById(Guid id);
        Task<IBaseResponse<IEnumerable<Order>>> GetAllOrders();
        Task<IBaseResponse<OrderViewModel>> CreateOrder(OrderViewModel model);
        Task<IBaseResponse<bool>> DeleteOrder(Guid id);
        Task<IBaseResponse<Order>> UpdateOrder(Guid id, OrderViewModel model);
        Task<IBaseResponse<IEnumerable<Order>>> GetOrderByName(string employee);
    }
}
