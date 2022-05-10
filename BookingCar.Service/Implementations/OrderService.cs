using BookingCar.Core.Domain;
using BookingCar.Core.Domain.Enum;
using BookingCar.Core.Domain.Orders;
using BookingCar.Core.Domain.ViewModels;
using BookingCar.DataAccess.Repositories.Interfaces;
using BookingCar.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingCar.Service.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IBaseResponse<OrderViewModel>> CreateOrder(OrderViewModel model)
        {
            var response = new OrderResponse<OrderViewModel>();

            try
            {
                model.DriverName += "  "; 
                var splitter = model.DriverName.Split(' ');
                string firstName = splitter[1];
                string lastName = splitter[0];
                string patronymic = splitter[2];
                var driver = await _orderRepository.GetDriver(firstName, lastName, patronymic);
                
                if(driver == null)
                {
                    response.Description = "Водитель не найден";
                    response.StatusCode = StatusCode.UserNotFound;
                    return response;
                }

                var orderModel = new Order()
                {
                    Id = new Guid(),
                    Comment = model.Comment,
                    DateTimeDeparture = model.DateTimeDeparture,
                    EmployeeName = model.EmployeeName,
                    DriverName = model.DriverName,
                };
                
                await _orderRepository.Create(orderModel);
                response.Description = "Заявка создана";
                response.StatusCode = StatusCode.OK;
                return response;
            }
            catch (Exception ex)
            {
                return new OrderResponse<OrderViewModel>()
                {
                    Description = $"Не удалось создать заявку: {ex.Message}",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteOrder(Guid id)
        {
            var response = new OrderResponse<bool>();

            try
            {
                var order = await _orderRepository.GetById(id);
                if(order == null)
                {
                    response.Description = "Заявка не найдена";
                    response.StatusCode = StatusCode.OK;
                }
                else
                {
                   await _orderRepository.Delete(order);
                   response.StatusCode = StatusCode.OK;
                }
                return response;
            }
            catch(Exception ex)
            {
                return new OrderResponse<bool>()
                {
                    Description = $"Не удалось удалить заявку: {ex.Message}",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
        }

      

        public async Task<IBaseResponse<IEnumerable<Order>>> GetAllOrders()
        {
            var response = new OrderResponse<IEnumerable<Order>>();

            try
            {
                var orders = await _orderRepository.GetAll();
                if(orders.Count() == 0)
                {
                    response.Description = "Найдено 0 элементов";
                    response.StatusCode = StatusCode.OK;
                }
                else
                {
                    response.Data = orders;
                    response.StatusCode = StatusCode.OK;
                }
                return response;
            }
            catch (Exception ex)
            {
                return new OrderResponse<IEnumerable<Order>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServiceError
                };
            }
        }

        public async Task<IBaseResponse<Order>> GetOrderById(Guid id)
        {
            var response = new OrderResponse<Order>();

            try
            {
                var order = await _orderRepository.GetById(id);

                if(order == null)
                {
                    response.Description = "Заявка не найдена";
                    response.StatusCode = StatusCode.NotFound;
                }
                else
                {
                    response.Data = order;
                    response.StatusCode = StatusCode.OK;
                }
                return response;
            }
            catch(Exception ex)
            {
                return new OrderResponse<Order>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServiceError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Order>>> GetOrderByName(string employee)
        {
            var response = new OrderResponse<IEnumerable<Order>>();

            try
            {
                var orders = await _orderRepository.GetAll();
                orders = orders.Where(o => o.EmployeeName == employee);

                if(orders == null)
                {
                    response.Description = "Заявки не найдены";
                    response.StatusCode = StatusCode.NotFound;
                }
                else
                {
                    response.Data = orders;
                    response.StatusCode = StatusCode.OK;
                }
                return response;
            }
            catch (Exception ex)
            {
                return new OrderResponse<IEnumerable<Order>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServiceError
                };
            }
        }

        public async Task<IBaseResponse<Order>> UpdateOrder(Guid id, OrderViewModel model)
        {
            var response = new OrderResponse<Order>();

            try
            {
                model.DriverName += "  ";
                var splitter = model.DriverName.Split(' ');
                string firstName = splitter[1];
                string lastName = splitter[0];
                string patronymic = splitter[2];
                var driver = await _orderRepository.GetDriver(firstName, lastName, patronymic);

                if (driver == null)
                {
                    response.Description = "Водитель не найден";
                    response.StatusCode = StatusCode.UserNotFound;
                    return response;
                }

                var order = await _orderRepository.GetById(id);

                if( order == null)
                {
                    response.Description = "Заявка не найдена";
                    response.StatusCode= StatusCode.NotFound;
                }
                else
                {
                    order.Comment = model.Comment;
                    order.DateTimeDeparture = model.DateTimeDeparture;
                    order.DriverName = model.DriverName;
                    response.StatusCode = StatusCode.OK;
                    await _orderRepository.Update(order);
                }
                return response;
            }
            catch (Exception ex)
            {
                return new OrderResponse<Order>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServiceError
                };
            }
        }

    }
}
