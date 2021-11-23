using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataServer.Models;
using DataServer.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DataServer.DataAccess.Impl
{
    public class OrderItemsDao : IOrderItemDao
    {
        private RestaurantDbContext context;
        public OrderItemsDao(RestaurantDbContext context)
        {
            this.context = context;
        }
        
        
        public async Task<OrderItem>CreateOrderItemAsync(OrderItem orderItem)
        {
            /*OrderItem toAdd = new OrderItem()
            {
              Order = context.Orders.Where(o=>o.Equals(orderItem.Order)),
              Quantity = orderItem.Quantity,
              Price = orderItem.Price,
              Menu = context.Menus.Where(m=>m.Equals(orderItem.Menu))
            };
            await context.OrderItems.AddAsync(orderItem);
           await context.SaveChangesAsync();
            return orderItem;*/
            return null;
        }

        public async Task<List<OrderItem>> GetOrderItemsAsync(int orderId)
        {
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