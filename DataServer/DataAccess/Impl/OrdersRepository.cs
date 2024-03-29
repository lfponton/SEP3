﻿using System;
using System.Collections.Generic;
using System.Linq;
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
                Customer customer =
                    await context.Customers.FirstOrDefaultAsync(c => c.Email.Equals(order.Customer.Email));
                order.Customer = customer;
            }

            foreach (var item in order.OrderItems)
            {
                item.Menu = null;
            }

            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
            return order;
        }

        public async Task<IList<Order>> GetOrdersAsync(string status)
        {
            return await context.Orders.Where(o => o.Status == status).Include(o => o.Customer).ToListAsync();
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            Order toUpdate = await context.Orders.FirstAsync(o => o.OrderId == order.OrderId);
            toUpdate.Customer = order.Customer;
            toUpdate.Price = order.Price;
            toUpdate.Status = order.Status;
            toUpdate.DeliveryTime = order.DeliveryTime;
            toUpdate.OrderDateTime = order.OrderDateTime;
            toUpdate.DeliveryAddress = order.DeliveryAddress;
            toUpdate.IsDelivery = order.IsDelivery;
            context.Update(toUpdate);
            return toUpdate;
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
            return context.Orders
                .Include(o => o.Customer)
                .Include(o => o.DeliveryAddress)
                .Include(o => o.OrderItems)
                .ThenInclude(item => item.Menu)
                .FirstOrDefaultAsync(order => order.OrderId == orderId);
        }

        public async Task<int> GetCustomerOrders(string email)
        {
            List<Order> orders = await context.Orders.Where(o => o.Customer.Email == email)
                .Where(o => o.Status.Equals("completed")).ToListAsync();
            return orders.Count;
        }
    }
}