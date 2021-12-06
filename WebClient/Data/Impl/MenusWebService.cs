using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Data.Impl
{
    public class MenusWebService : IMenusService
    {
        private readonly HttpClient client;
        private JsonSerializerOptions options;

        public MenusWebService()
        {
            client = new HttpClient();
            options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<List<Menu>> GetMenus()
        {
            HttpResponseMessage response = await client.GetAsync($"http://localhost:8080/menus");
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
            List<Menu> menus = JsonSerializer.Deserialize<List<Menu>>(result, options);
            return menus;
        }

        public async Task<Menu> CreateMenuAsync(Menu menu)
        {
            string menuAsJson = JsonSerializer.Serialize(menu, options);
            HttpContent content = new StringContent(menuAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost:8080/menus", content);
            if (response.IsSuccessStatusCode)
            {
                string menuAsJsonResponse = await response.Content.ReadAsStringAsync();
                Menu resultMenu = JsonSerializer.Deserialize<Menu>(menuAsJsonResponse, options);
                return resultMenu;
            }

            throw new Exception($"Error,{response.StatusCode},{response.ReasonPhrase}");

        }
    }
}