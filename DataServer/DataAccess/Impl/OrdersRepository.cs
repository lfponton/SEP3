﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataServer.Models;
using DataServer.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DataServer.DataAccess.Impl
{
    public class OrdersRepository : IOrdersRepository
    {
        private RestaurantDbContext context;
        public OrdersRepository(RestaurantDbContext context)
        {
            this.context = context;
        }
        public async Task<Order> CreateOrderAsync(Order order)
        {
            if (order.Customer != null)
            {
                Customer customer = await context.Customers.FirstOrDefaultAsync(c => c.Id == order.Customer.Id);
                order.Customer = customer;
            }

            Console.WriteLine(order.ToString());
            await context.Orders.AddAsync(order);
            return order;
        }

        public async Task<IList<Order>> ReadOrdersAsync()
        {
            // return await context.Orders
            //     .Include(o => o.OrderItems)
            //     .Include(o => o.Customer)
            //     .Include(o => o.DeliveryAddress).ToListAsync();
            return await context.Orders.ToListAsync();

        }

        public async Task UpdateOrderAsync(Order order)
        {
            Order toUpdate = await context.Orders.FirstAsync(o => o.OrderId == order.OrderId);
            toUpdate.Customer = order.Customer;
          //  toUpdate.OrderItems = order.OrderItems;
            toUpdate.Price = order.Price;
            toUpdate.Status = order.Status;
            toUpdate.DeliveryTime = order.DeliveryTime;
            toUpdate.OrderDateTime = order.OrderDateTime;
            toUpdate.DeliveryAddress = order.DeliveryAddress;
            context.Update(toUpdate);
            await context.SaveChangesAsync();
        }

        // Not sure why orders should be deleted
        public async Task DeleteOrderAsync(Order order)
        {
            Order toRemove = await context.Orders.FirstOrDefaultAsync(o => o.OrderId == order.OrderId);
            if (toRemove != null)
            {
                context.Orders.Remove(toRemove);
                await context.SaveChangesAsync();
            }
        }

        public Task<Order> GetOrder(long orderId)
        {
            return context.Orders.FirstOrDefaultAsync(order => order.OrderId == orderId);
        }
    }
}