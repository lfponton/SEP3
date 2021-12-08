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
        
        public async Task<IList<MenuItem>> GetMenuItems( int menuId)
        {
            HttpResponseMessage response = await client.GetAsync($"http://localhost:8080/menuItems/{menuId}");
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
            List<MenuItem> menus = JsonSerializer.Deserialize<List<MenuItem>>(result, options);
            return menus;
        }

        

        public async Task<MenuItem> CreateMenuAsync(MenuItem menuItem)
        {
            string menuItemAsJson = JsonSerializer.Serialize(menuItem, options);
            HttpContent content = new StringContent(menuItemAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost:8080/menuItems", content);
            if (response.IsSuccessStatusCode)
            {
                string menuItemAsJsonResponse = await response.Content.ReadAsStringAsync();
                MenuItem resultMenuItem = JsonSerializer.Deserialize<MenuItem>(menuItemAsJsonResponse, options);
                return menuItem;
            }

            throw new Exception($"Error,{response.StatusCode},{response.ReasonPhrase}");

        }

        public Task DeleteMenuItem(long menuItemId)
        {
            throw new NotImplementedException();
        }
       
    }
}