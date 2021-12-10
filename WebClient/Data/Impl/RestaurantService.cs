using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Data.Impl
{
    public class RestaurantService:IRestaurantService
    {
        private readonly HttpClient client;
        private JsonSerializerOptions options;
        private string uri = "http://localhost:8080";

        public RestaurantService()
        {
            client = new HttpClient();
            options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }
        public async Task<Restaurant> GetRestaurant()
        {
            HttpResponseMessage response = await client.GetAsync($"{uri}/restaurant");
            if (!response.IsSuccessStatusCode) throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            string result = await response.Content.ReadAsStringAsync();
            Restaurant restaurant = JsonSerializer.Deserialize<Restaurant>(result, options);
            return restaurant;        }
    }
}