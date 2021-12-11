using System;
using System.Text.Json;
using System.Threading.Tasks;
using DataServer.DataAccess.Impl;
using DataServer.Models;
using DataServer.Persistence;

namespace DataServer.Network
{
    public class OrdersHandler : IRequestHandler
    {
        private IUnitOfWork unitOfWork;
        private JsonSerializerOptions options;
        private JsonSerializerOptions optionsWithoutConverter;

        public OrdersHandler()
        {
            unitOfWork = new UnitOfWork(new RestaurantDbContext());

            options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            options.Converters.Add(new DateTimeConverter());

            optionsWithoutConverter = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<string> ProcessClientRequestType(string requestType, string args)
        {
            switch (requestType)
            {
                case "getOrder":
                    return await GetOrder(args);
                case "getOrders":
                    return await GetOrders(args);
                case "createOrder":
                    return await CreateOrder(args);
                case "updateOrder":
                    return await UpdateOrderAsync(args);
                case "getCustomerOrders":
                    return await GetCustomerOrders(args);
                default:
                    return "";
            }
        }

        private async Task<string> GetCustomerOrders(string args)
        {
            string email = args;
            return (await unitOfWork.OrdersRepository.GetCustomerOrders(email)).ToString();
        }

        private async Task<string> UpdateOrderAsync(string args)
        {
            Order order = JsonSerializer.Deserialize<Order>(args, options);
            await unitOfWork.OrdersRepository.UpdateOrderAsync(order);
            await unitOfWork.Save();
            return JsonSerializer.Serialize(order, optionsWithoutConverter);
        }

        private async Task<string> GetOrder(string args)
        {
            long orderId = Int64.Parse(args);
            return JsonSerializer.Serialize(await unitOfWork.OrdersRepository.GetOrder(orderId), optionsWithoutConverter);
        }

        private async Task<string> GetOrders(String args)
        {
            return JsonSerializer.Serialize(await unitOfWork.OrdersRepository.GetOrdersAsync(args), optionsWithoutConverter);
        }

        private async Task<string> CreateOrder(string args)
        {
            Order order = JsonSerializer.Deserialize<Order>(args, options);
            await unitOfWork.OrdersRepository.CreateOrderAsync(order);
            await unitOfWork.Save();
            return JsonSerializer.Serialize(order, optionsWithoutConverter);
        }
    }
}