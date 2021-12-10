using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebClient.Models;
using WebClient.Data;

namespace WebClient.Data.Impl
{
    public class MenuItemsWebService : IMenuItemsService
    {
        private readonly HttpClient client;
        private JsonSerializerOptions options;

        public MenuItemsWebService()
        {
            client = new HttpClient();
            options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }
        
        public async Task<IList<MenuItem>> GetMenuItems( int menuItemId)
        {
            HttpResponseMessage response = await client.GetAsync($"http://localhost:8080/menuItems/{menuItemId}");
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            string result = await response.Content.ReadAsStringAsync();
            List<MenuItem> menusItems = JsonSerializer.Deserialize<List<MenuItem>>(result, options);
            return menusItems;
        }

        

        public async Task<MenuItem> CreateMenuItemAsync(MenuItem menuItem)
        {
            string menuItemAsJson = JsonSerializer.Serialize(menuItem, options);
            Console.WriteLine(menuItemAsJson);
            HttpContent content = new StringContent(menuItemAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost:8080/menuItems", content);
            if (response.IsSuccessStatusCode)
            {
                string menuItemAsJsonResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine(menuItemAsJsonResponse);
                MenuItem resultMenuItem = JsonSerializer.Deserialize<MenuItem>(menuItemAsJsonResponse, options);
                return resultMenuItem;
            }

            throw new Exception($"Error,{response.StatusCode},{response.ReasonPhrase}");

        }
        
        

        public Task DeleteMenuItem(long menuItemId)
        {
            throw new NotImplementedException();
        }
       
    }
}