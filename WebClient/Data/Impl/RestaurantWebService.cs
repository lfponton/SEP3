using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebClient.Data.ValidationHandler;
using WebClient.Models;

namespace WebClient.Data.Impl
{
    public class RestaurantWebService : IRestaurantService
    {
        private readonly HttpClient client;
        private JsonSerializerOptions options;
        private string uri = "http://localhost:8080";

        public RestaurantWebService()
        {
            client = new HttpClient();
            options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<Restaurant> GetRestaurantAsync()
        {
            HttpResponseMessage response = await client.GetAsync($"{uri}/restaurant");

            if
                (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                var exceptionResponse = JsonSerializer.Deserialize<ExceptionResponse>(errorMessage, options);
                throw new Exception($"{exceptionResponse.Message}");
            }

            string result = await response.Content.ReadAsStringAsync();
            Restaurant restaurant = JsonSerializer.Deserialize<Restaurant>(result, options);
            return restaurant;
        }
    }
}