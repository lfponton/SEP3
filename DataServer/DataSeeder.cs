using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataServer.DataAccess;
using DataServer.DataAccess.Impl;
using DataServer.Models;
using DataServer.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DataServer
{
    public class DataSeeder
    {

        public async Task Seed()
        {
            await using var restaurantDbContext = new RestaurantDbContext();
            IUnitOfWork unitOfWork = new UnitOfWork(restaurantDbContext);
            // ONLY FOR TESTING
            // Checks if there has been a customer added with the id = 1
            var testCustomer = await restaurantDbContext.Customers.FirstOrDefaultAsync(c => c.Id == 1);
            // If it hasn't, then it will add the data to the database
            if (testCustomer == null)
            {
                await CreateCustomer(unitOfWork.AccountsRepository);
                await CreateMenuItems(unitOfWork.MenuItemsRepository);
                await unitOfWork.Save();
                var menuItem1 = restaurantDbContext.MenuItems.First(menuItem => menuItem.MenuItemId == 1);
                var menuItem2 = restaurantDbContext.MenuItems.First(menuItem => menuItem.MenuItemId == 2);
                //var menu2 = restaurantDbContext.Menus.First(menu => menu.MenuId == 2);
                MenuItemsSelection selection1 = new MenuItemsSelection()
                {
                    MenuItem = menuItem1,
                    Quantity = 2,
                    Price = 100
                };
                MenuItemsSelection selection2 = new MenuItemsSelection()
                {
                    MenuItem = menuItem2,
                    Quantity = 4,
                    Price = 200
                };
                await CreateMenus(unitOfWork.MenusRepository, selection1, selection2);
                await unitOfWork.Save();
            }
            var menu1 = restaurantDbContext.Menus.First(menu => menu.MenuId == 1);
            await CreateOrder(unitOfWork.OrdersRepository, menu1);
            await unitOfWork.Save();
        }

        public async Task SeedPendingOrders()
        {
            await using var restaurantDbContext = new RestaurantDbContext();
            IUnitOfWork unitOfWork = new UnitOfWork(restaurantDbContext);
            Menu menu = await restaurantDbContext.Menus.FirstOrDefaultAsync(m => m.MenuId == 1);
            //await CreateOrderWithCustomerAndStatus(unitOfWork.OrdersRepository, menu);
            await unitOfWork.Save();
        }

        public async Task SeedNumberOfCustomerOrdersByStatus(int numberOfOrders, string status)
        {
            await using var restaurantDbContext = new RestaurantDbContext();
            IUnitOfWork unitOfWork = new UnitOfWork(restaurantDbContext);
            
            var customer = await restaurantDbContext.Customers.FirstOrDefaultAsync(c => c.Email.Equals("a"));
            Menu menu = await restaurantDbContext.Menus.FirstOrDefaultAsync(m => m.MenuId == 1);

            for (int i = 0; i < numberOfOrders; i++)
            {
                await CreateOrderWithCustomerAndStatus(unitOfWork.OrdersRepository, menu, customer, status);
            }
            await unitOfWork.Save();
        }
        private async Task CreateOrderWithCustomerAndStatus(IOrdersRepository ordersRepository, Menu menu, Customer customer, string status)
        {
            var order = new Order
            {
                Customer = customer,
                OrderDateTime = DateTime.Now,
                DeliveryTime = DateTime.Now,
                IsDelivery = false,
                Price = 1000,
                Status = status
            };
            await ordersRepository.CreateOrderAsync(order);
        }


        private async Task CreateOrderItem(IOrderItemsRepository orderItemsRepository, Menu menu1)
        {
            var orderItem = new OrderItem
            {
                Menu = menu1,
                Quantity = 5,
                Price = 1000
            };

            await orderItemsRepository.CreateOrderItemAsync(orderItem);
        }

        // ONLY FOR TESTING
        
        private static async Task CreateCustomer(IAccountsRepository accountsRepository)
        {
            Person customer = new Customer
            {
                Email = "hello@gmail.com",
                FirstName = "Bill",
                LastName = "Smith",
                Password = "4321",
            };

            await accountsRepository.CreateAccountAsync(customer);
        }

        private static async Task CreateMenuItems(IMenuItemsRepository menuItemsRepository)
        {
            var menuItem1 = new MenuItem
            {
                Name = "Item1",
                Price = 50,
            };

            var menuItem2 = new MenuItem
            {
                Name = "Item2",
                Price = 100,
            };

            await menuItemsRepository.CreateMenuItemAsync(menuItem1);
            await menuItemsRepository.CreateMenuItemAsync(menuItem2);
        }
        
        private static async Task CreateMenus(IMenusRepository menusRepository, MenuItemsSelection selection1, MenuItemsSelection selection2)
        {
            var menu1 = new Menu
            {
                Name = "Yummy Menu",
                Type = "Regular",
                Description = "Yummy Stuff",
                Price = 100,
                MenuItemsSelections = new List<MenuItemsSelection>()
                {
                    selection1,
                }
            };

            var menu2 = new Menu
            {
                Name = "Healthy Menu",
                Type = "Regular",
                Description = "Healthy Stuff",
                Price = 200,
                MenuItemsSelections = new List<MenuItemsSelection>()
                {
                    selection2,
                }
            };
            await menusRepository.CreateMenuAsync(menu1);
            await menusRepository.CreateMenuAsync(menu2);
        }
        
        
        private static async Task CreateOrder(IOrdersRepository ordersRepository, Menu menu)
        {
            var order = new Order
            {
                OrderDateTime = DateTime.Now,
                DeliveryTime = DateTime.Now,
                OrderItems = new List<OrderItem>()
                {
                    new OrderItem()
                    {
                        Menu = menu,
                        Quantity = 5,
                        Price = 1000
                    }
                },
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