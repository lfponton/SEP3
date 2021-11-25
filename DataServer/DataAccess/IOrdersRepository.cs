using System.Collections.Generic;
using System.Threading.Tasks;
using DataServer.Models;

namespace DataServer.DataAccess
{
    public interface IOrdersRepository
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<IList<Order>> ReadOrdersAsync();
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(Order order);
    }
}