using System;
using System.Text.Json;
using System.Threading.Tasks;
using DataServer.DataAccess;
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
                case "createOrderItem":
                    return await CreateOrderItem(args);

                case "getOrderItems":
                    return await GetOrderItems(args);

                case "deleteOrderItem":
                    return await DeleteOrderItem(args);
                default:
                    return "";
            }
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

        private async Task<string> CreateOrderItem(string args)
        {
            OrderItem orderItem = JsonSerializer.Deserialize<OrderItem>(args, options);
            await unitOfWork.OrderItemsRepository.CreateOrderItemAsync(orderItem);
            await unitOfWork.Save();
            Console.WriteLine(JsonSerializer.Serialize(orderItem, optionsWithoutConverter));
            return JsonSerializer.Serialize(orderItem, optionsWithoutConverter);
        }

        private async Task<string> GetOrderItems(string args)
        {
            int orderId = Int32.Parse(args);
            return JsonSerializer.Serialize(await unitOfWork.OrderItemsRepository.GetOrderItemsAsync(orderId), optionsWithoutConverter);
        }

        private async Task<string> DeleteOrderItem(string args)
        {
            int orderItemId = Int32.Parse(args);
            await unitOfWork.OrderItemsRepository.DeleteOrderItemAsync(orderItemId);
            return args; // needs to return the deleted object
        }
    }
}