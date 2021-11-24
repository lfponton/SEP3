using System;
using System.Text.Json;
using System.Threading.Tasks;
using DataServer.DataAccess;
using DataServer.Models;

namespace DataServer.Network
{
    public class OrdersHandler : IRequestHandler
    {
        private IDaoFactory daoFactory;
        private JsonSerializerOptions options;
        private JsonSerializerOptions optionsWithoutConverter;

        public OrdersHandler(IDaoFactory daoFactory)
        {
            this.daoFactory = daoFactory;

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
                case "getOrders":
                    return await GetOrders();

                case "createOrder":
                    return await CreateOrder(args);

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

        private async Task<string> GetOrders()
        {
            return JsonSerializer.Serialize(await daoFactory.OrdersDao.ReadOrdersAsync(), options);
        }

        private async Task<string> CreateOrder(string args)
        {
            Order order = JsonSerializer.Deserialize<Order>(args, options);
            await daoFactory.OrdersDao.CreateOrderAsync(order);
            return JsonSerializer.Serialize(order, optionsWithoutConverter);
        }

        private async Task<string> CreateOrderItem(string args)
        {
            OrderItem orderItem = JsonSerializer.Deserialize<OrderItem>(args, options);
            await daoFactory.OrderItemsDao.CreateOrderItemAsync(orderItem);
            return JsonSerializer.Serialize(orderItem, optionsWithoutConverter);
        }

        private async Task<string> GetOrderItems(string args)
        {
            int orderId = Int32.Parse(args);
            return JsonSerializer.Serialize(await daoFactory.OrderItemsDao.GetOrderItemsAsync(orderId), optionsWithoutConverter);
        }

        private async Task<string> DeleteOrderItem(string args)
        {
            int orderItemId = Int32.Parse(args);
            await daoFactory.OrderItemsDao.DeleteOrderItemAsync(orderItemId);
            return args; // needs to return the deleted object
        }
    }
}