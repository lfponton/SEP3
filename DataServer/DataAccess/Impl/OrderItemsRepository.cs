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
            Menu menu = await context.Menus.FirstOrDefaultAsync(m => m.MenuId == orderItem.Menu.MenuId);
            orderItem.Menu = menu;
            
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
            await context.AddAsync(orderItem);

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