using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataServer.Models;
using DataServer.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DataServer.DataAccess.Impl
{
    public class OrderItemsRepository : IOrderItemsRepository
    {
        private RestaurantDbContext context;
        public OrderItemsRepository(RestaurantDbContext context)
        {
            this.context = context;
        }
        
        
        public async Task<OrderItem>CreateOrderItemAsync(OrderItem orderItem)
        {
            Order toUpdate = await context.Orders
                .FirstAsync(o => o.OrderId == orderItem.Order.OrderId);
            toUpdate.OrderItems.Add(orderItem); 
            context.Orders.Update(toUpdate);
            return orderItem;
        }

        public async Task<List<OrderItem>> GetOrderItemsAsync(int orderId)
        {
            List<OrderItem> orderItems = await context.OrderItems.Where(o => o.Order.OrderId == orderId).ToListAsync();
           // orderItems.ForEach(Console.WriteLine());
           foreach (var oi in orderItems)
           {
               Console.WriteLine(oi.OrderItemId);

           }
            return await context.OrderItems.Where(o => o.Order.OrderId == orderId).ToListAsync();
        }

        public async Task DeleteOrderItemAsync(long orderItemId)
        {
            OrderItem toRemove = await context.OrderItems.FirstOrDefaultAsync(o => o.OrderItemId == orderItemId);
            if (toRemove != null)
            {
                context.OrderItems.Remove(toRemove);
                await context.SaveChangesAsync();
            }
        }
    }
}