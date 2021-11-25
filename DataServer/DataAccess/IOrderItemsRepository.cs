using System.Collections.Generic;
using System.Threading.Tasks;
using DataServer.Models;

namespace DataServer.DataAccess
{
    public interface IOrderItemsRepository
    {
        Task<OrderItem> CreateOrderItemAsync(OrderItem orderItem);

        Task<List<OrderItem>> GetOrderItemsAsync(int orderId);

        Task DeleteOrderItemAsync(long orderItemId);
    }
}