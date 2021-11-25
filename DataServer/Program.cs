using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using DataServer.Models;
using DataServer.DataAccess;
using DataServer.DataAccess.Impl;
using DataServer.Network;
using DataServer.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DataServer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Server server = new Server(IPAddress.Parse("127.0.0.1"), 2001);
            var serverThread = new Thread(server.Listen);
            serverThread.Start();
            Console.WriteLine($"Server started.");
            /*
            // ONLY FOR TESTING
            // Checks if there has been a customer added with the id = 1
            var testCustomer = await restaurantDbContext.Customers.FirstOrDefaultAsync(c => c.Id == 1);
            // If it hasn't, then it will add the data to the database
            if (testCustomer == null)
            {
                await CreateCustomer(daoFactory.AccountsRepository);
                await CreateMenuItems(daoFactory.MenuItemsRepository);
                var menuItem1 = restaurantDbContext.MenuItems.First(menuItem => menuItem.MenuItemId == 1);
                var menuItem2 = restaurantDbContext.MenuItems.First(menuItem => menuItem.MenuItemId == 2);
                await CreateMenus(daoFactory.MenusRepository, menuItem1, menuItem2);
                var customer = restaurantDbContext.Customers.First(c => c.Id == 1);
                var menu1 = restaurantDbContext.Menus.First(menu => menu.MenuId == 1);
                var menu2 = restaurantDbContext.Menus.First(menu => menu.MenuId == 2);
                await CreateOrder(daoFactory.OrdersRepository, customer, menu1, menu2);
            }
            */
        }
        
        
        // ONLY FOR TESTING
        private static async Task CreateCustomer(IAccountsRepository accountsRepository)
        {
            var customer = new Customer
            {
                Email = "hello@gmail.com",
                FirstName = "Bill",
                LastName = "Smith",
                Password = "4321",
            };

            await accountsRepository.CreateCustomerAsync(customer);
        }

        private static async Task CreateMenuItems(IMenuItemsRepository menuItemsRepository)
        {
            var menuItem1 = new MenuItem
            {
                Name = "Item1",
                Price = 50
            };

            var menuItem2 = new MenuItem
            {
                Name = "Item2",
                Price = 100
            };

            await menuItemsRepository.CreateMenuItemAsync(menuItem1);
            await menuItemsRepository.CreateMenuItemAsync(menuItem2);
        }
        
        private static async Task CreateMenus(IMenusRepository menusRepository, MenuItem menuItem1, MenuItem menuItem2)
        {
            var menu1 = new Menu
            {
                Name = "Yummy Menu",
                Type = "Regular",
                Description = "Yummy Stuff",
                MenuItems = new List<MenuItem>()
                {
                    menuItem1,
                    menuItem2
                },
                Price = 100
            };

            var menu2 = new Menu
            {
                Name = "Healthy Menu",
                Type = "Regular",
                Description = "Healthy Stuff",
                MenuItems = new List<MenuItem>()
                {
                    menuItem1,
                    menuItem2,
                    },
                Price = 200
            };
            await menusRepository.CreateMenuAsync(menu1);
            await menusRepository.CreateMenuAsync(menu2);
        }
        
        private static async Task CreateOrder(IOrdersRepository ordersRepository, Customer customer, Menu menu1, Menu menu2)
        {
            var order = new Order
            {
                OrderDateTime = DateTime.Now,
               // CustomerId = customer.CustomerId,
                DeliveryTime = DateTime.Now,
              /*  OrderItems = new List<OrderItem>()
                {
                    new OrderItem
                    {
                        MenuId = menu1.MenuId,
                        Quantity = 2
                    },
                    new OrderItem
                    {
                        MenuId = menu2.MenuId,
                        Quantity = 2
                    }
                },*/
                Price = 300,
               // Status = Status.InProgress
            };

            await ordersRepository.CreateOrderAsync(order);
        }
        
        private static async Task CreateOrderWithNoCustomer(IOrdersRepository ordersRepository)
        {
            var order = new Order
            {
                OrderDateTime = DateTime.Now,
                DeliveryTime = DateTime.Now,
               // OrderItems = new List<OrderItem>(),
                Price = 100,
              //  Status = Status.InProgress
            };

            await ordersRepository.CreateOrderAsync(order);
        }
    }
}