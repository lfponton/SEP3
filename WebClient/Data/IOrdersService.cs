using System.Collections.Generic;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Data
{
    public interface IOrdersService
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<List<Order>> GetOrdersAsync(string? status);
        Task<Order> GetOrderAsync(long orderId);
        Task<Order> UpdateOrderAsync(Order order);
        Task<int> GetCustomerOrdersAsync(string email);
    }
}