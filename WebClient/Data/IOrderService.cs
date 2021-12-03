using System.Collections.Generic;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Data
{
    public interface IOrderService
    {
        Task<Order> CreateOrder();
        Task<List<Order>> GetOrdersAsync(string? status);
        Task<Order> GetOrderAsync(long orderId);
        Task<Order> UpdateOrderAsync(Order order);
    }
}