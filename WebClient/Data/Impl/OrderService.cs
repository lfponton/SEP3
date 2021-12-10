using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebClient.Data.validationhandler;
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

        public async Task<Order> CreateOrder(Order order)
        {
            string orderAsJson = JsonSerializer.Serialize(order, options);
            HttpContent content = new StringContent(orderAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri + "/orders", content);
            if (response.IsSuccessStatusCode)
            {
                string orderAsJsonResponse = await response.Content.ReadAsStringAsync();
                Order resultOrder = JsonSerializer.Deserialize<Order>(orderAsJsonResponse, options);
                return resultOrder;
            }
            var errorMessage = await response.Content.ReadAsStringAsync();
            var exceptionResponse = JsonSerializer.Deserialize<ExceptionResponse>(errorMessage, options); 
            throw new Exception($"{exceptionResponse.Message}");
        }

        public async Task<List<Order>> GetOrdersAsync(string? status)
        {
            HttpResponseMessage response = await client.GetAsync($"{uri}/orders/?status={status}");
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            string result = await response.Content.ReadAsStringAsync();
            List<Order> orders = JsonSerializer.Deserialize<List<Order>>(result, options);
            return orders;
        }

        public async Task<Order> GetOrderAsync(long orderId)
        {
            HttpResponseMessage response = await client.GetAsync($"{uri}/orders/{orderId}");
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            string result = await response.Content.ReadAsStringAsync();
            Order order = JsonSerializer.Deserialize<Order>(result, options);
            return order;
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            string orderAsJson = JsonSerializer.Serialize(order,options);
            HttpContent content = new StringContent(orderAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PatchAsync($"{uri}/orders/", content);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            string result = await response.Content.ReadAsStringAsync();
            var updatedOrder = JsonSerializer.Deserialize<Order>(result, options);
            return updatedOrder;
        }

        public async Task<int> GetCustomerOrders(string email)
        {
            HttpResponseMessage response = await client.GetAsync($"{uri}/orders/customer/?email={email}");
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            string result = await response.Content.ReadAsStringAsync();
            int numberOfOrders = JsonSerializer.Deserialize<int>(result, options);
            return numberOfOrders;
        }
    }
}