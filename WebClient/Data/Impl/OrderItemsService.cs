using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Data.Impl
{
    public class OrderItemsService : IOrderItemsService
    {
        private readonly HttpClient client;
        private JsonSerializerOptions options;
        private string uri = "http://localhost:8080";


        public OrderItemsService()
        {
            client = new HttpClient();
            options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }
        
        public async Task CreateOrderItem(int quantity, Menu menu, Order order)
        {
            var orderItem = new OrderItem()
            {  
                Order = order ,
                Quantity = quantity,
                Menu = menu
            };
            
            string orderItemAsJson = JsonSerializer.Serialize(orderItem, options);
            Console.Write($"orderItemAsJson ------------------->{orderItemAsJson}");
            HttpContent content = new StringContent(orderItemAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri + "/orderItems", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error,{response.StatusCode},{response.ReasonPhrase}");
            }
        }

        public async Task<List<OrderItem>> GetOrderItems(long orderId)
        {
            HttpResponseMessage response = await client.GetAsync($"{uri}/orderItems/{orderId}");
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
            List<OrderItem> orderItems = JsonSerializer.Deserialize<List<OrderItem>>(result, options);
            return orderItems;        }

        public async Task DeleteOrderItem(long orderItemId)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"{uri}/orderItems/{orderItemId}");
            if(!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
        }
    }
    
}