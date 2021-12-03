using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using DataServer.Models;

namespace DataServer.DataAccess
{
    public interface IOrdersRepository
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<IList<Order>> GetOrdersAsync();
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(Order order);
        Task<Order> GetOrder(long orderId);
    }
}