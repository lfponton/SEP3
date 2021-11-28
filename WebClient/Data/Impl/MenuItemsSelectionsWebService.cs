using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Data.Impl
{
    public class MenuItemsSelectionsWebService : IMenuItemsSelectionsService
    {
        private readonly HttpClient client;
        private JsonSerializerOptions options;

        public MenuItemsSelectionsWebService()
        {
            client = new HttpClient();
            options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }
        
        public async Task<IList<MenuItemsSelection>> GetMenuItemsSelections(long menuId)
        {
            HttpResponseMessage response = await client.GetAsync($"http://localhost:8080/menuItemsSelections/{menuId}");
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
            List<MenuItemsSelection> menusItemsSelections = JsonSerializer.Deserialize<List<MenuItemsSelection>>(result, options);
            return menusItemsSelections;
        }
    }
}