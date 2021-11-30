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
            /*
            Order toUpdate = await context.Orders
                .FirstAsync(o => o.OrderId == orderItem.Order.OrderId);
            toUpdate.OrderItems.Add(orderItem);
            context.Orders.Update(toUpdate);
            OrderItem itemToUpdate = await context.OrderItems.OrderByDescending(orderItem => orderItem.OrderItemId)
                .FirstOrDefaultAsync();
            itemToUpdate.Menu = orderItem.Menu;
            context.OrderItems.Update(itemToUpdate);

            /*
            Menu menuToUpdate = await context.Menus.FirstAsync(m => m.MenuId == orderItem.Menu.MenuId);
            menuToUpdate.OrderItems.Add(orderItem);
            context.Menus.Update(menuToUpdate);
*/
            
            Console.WriteLine(orderItem.ToString());
            await context.OrderItems.AddAsync(orderItem);

            return orderItem;
        }

        public async Task<List<OrderItem>> GetOrderItemsAsync(int orderId)
        {
            List<OrderItem> orderItems = await context.OrderItems.Where(o => o.Order.OrderId == orderId).ToListAsync();
            return await context.OrderItems.Where(o => o.Order.OrderId == orderId).ToListAsync();
        }

        public async Task DeleteOrderItemAsync(long orderItemId)
        {
            // Needs to be fixed
            OrderItem toRemove = await context.OrderItems.FirstOrDefaultAsync(o => o.OrderId == orderItemId);
            if (toRemove != null)
            {
                context.OrderItems.Remove(toRemove);
                await context.SaveChangesAsync();
            }
        }
    }
}