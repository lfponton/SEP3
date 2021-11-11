﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using DatabaseServer.Models;
using DataServer.DataAccess;
using DataServer.DataAccess.Impl;
using DataServer.Models;
using DataServer.Network;
using DataServer.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DataServer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            RestaurantDbContext restaurantDbContext = new RestaurantDbContext();
            IDaoFactory daoFactory = new DaoFactory(restaurantDbContext);

            Server server = new Server(IPAddress.Parse("127.0.0.1"), 2001, daoFactory);
            var serverThread = new Thread(server.Listen);
            serverThread.Start();
            Console.WriteLine($"Server started.");
            /* ONLY FOR TESTING
            1) Create a customer:
            await CreateCustomer(daoFactory.CustomerDao);
            2) Create MenuItems
            await CreateMenuItems(daoFactory.MenuItemDao);
            3) Create Menus
            await CreateMenus(daoFactory.MenuDao);
            4) Create Order
            var customer = restaurantDbContext.Customers.First(c => c.CustomerId == 1);
            await CreateOrder(daoFactory.OrdersDao, customer);
            5) Create another order for the same customer
            var customer = restaurantDbContext.Customers.First(c => c.CustomerId == 1);
            await CreateAnotherOrder(daoFactory.OrdersDao, customer);
            
            await CreateCustomer(daoFactory.CustomerDao);
            await CreateMenuItems(daoFactory.MenuItemDao);
            var menuItem1 = restaurantDbContext.MenuItems.First(menuItem => menuItem.MenuItemId == 1);
            var menuItem2 = restaurantDbContext.MenuItems.First(menuItem => menuItem.MenuItemId == 2);
            await CreateMenus(daoFactory.MenuDao, menuItem1, menuItem2);
            var customer = restaurantDbContext.Customers.First(c => c.CustomerId == 1);
            var menu1 = restaurantDbContext.Menus.First(menu => menu.MenuId == 1);
            var menu2 = restaurantDbContext.Menus.First(menu => menu.MenuId == 2);
            await CreateOrder(daoFactory.OrdersDao, customer, menu1, menu2);
*/          
        }
        
        
        // ONLY FOR TESTING
        private static async Task CreateCustomer(ICustomerDao customerDao)
        {
            var customer = new Customer
            {
                Email = "hello@gmail.com",
                FirstName = "Bill",
                LastName = "Smith",
                Password = "4321",
            };

            await customerDao.CreateCustomerAsync(customer);
        }

        private static async Task CreateMenuItems(IMenuItemDao menuItemDao)
        {
            var menuItem1 = new MenuItem
            {
                Name = "Item1",
                Description = "Yummy stuff",
                Price = 50
            };

            var menuItem2 = new MenuItem
            {
                Name = "Item2",
                Description = "Healthy goods",
                Price = 100
            };

            await menuItemDao.CreateMenuItemAsync(menuItem1);
            await menuItemDao.CreateMenuItemAsync(menuItem2);
        }
        
        private static async Task CreateMenus(IMenuDao menuDao, MenuItem menuItem1, MenuItem menuItem2)
        {
            var menu1 = new Menu
            {
                Name = "Yummy Menu",
                Type = "Regular",
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
                MenuItems = new List<MenuItem>()
                {
                    menuItem1,
                    menuItem2,
                    },
                Price = 200
            };
            await menuDao.CreateMenuAsync(menu1);
            await menuDao.CreateMenuAsync(menu2);
        }
        
        private static async Task CreateOrder(IOrdersDao ordersDao, Customer customer, Menu menu1, Menu menu2)
        {
            var order = new Order
            {
                OrderDate = DateTime.Now,
                Customer = customer,
                DeliveryTime = DateTime.Now,
                OrderItems = new List<OrderItem>()
                {
                    new OrderItem
                    {
                        Menu = menu1,
                        Quantity = 2
                    },
                    new OrderItem
                    {
                        Menu = menu2,
                        Quantity = 2
                    }
                },
                Price = 300,
                Status = Status.InProgress
            };

            await ordersDao.CreateOrderAsync(order);
        }

/*
        private static async Task CreateAnotherOrder(IOrdersDao ordersDao, Customer customer)
        {
            var order = new Order
            {
                OrderDate = DateTime.Now,
                Customer = customer,
                DeliveryTime = DateTime.Now,
                OrderItems = new List<OrderItem>()
                {
                    new OrderItem
                    {
                        MenuId = 2,
                        Quantity = 2
                    }
                },
                Price = 100,
                Status = Status.InProgress
            };

            await ordersDao.CreateOrderAsync(order);
        }
  */      
    }
}