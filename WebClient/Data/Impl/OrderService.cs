using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Data.Impl
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient client;
        private JsonSerializerOptions options;
        private string uri = "http://localhost:8080";

        public OrderService()
        {
            client = new HttpClient();
            options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<Order> CreateOrder()
        {
            var newOrder = new Order()
            {
                OrderDateTime = DateTime.Now,
            };
            string orderAsJson = JsonSerializer.Serialize(newOrder, options);
            HttpContent content = new StringContent(orderAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri + "/orders", content);
            if (response.IsSuccessStatusCode)
            {
                string orderAsJsonResponse = await response.Content.ReadAsStringAsync();
                Order resultOrder = JsonSerializer.Deserialize<Order>(orderAsJsonResponse, options);
                Console.WriteLine($"CreateOrder in order service---->{orderAsJsonResponse}");
                return resultOrder;
            }
            throw new Exception($"Error,{response.StatusCode},{response.ReasonPhrase}");

            
        }

        public async Task<List<Order>> GetOrdersAsync(string? status)
        {
            // TODO: Include paramaters to get Pending, Confirmed, Cancelled, or Completed orders
            HttpResponseMessage response = await client.GetAsync($"{uri}/orders/?status={status}");
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
            List<Order> orders = JsonSerializer.Deserialize<List<Order>>(result, options);
            return orders;
        }
    }
}