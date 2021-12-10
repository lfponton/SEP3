using System;
using System.Text.Json;
using System.Threading.Tasks;
using DataServer.DataAccess.Impl;
using DataServer.Models;
using DataServer.Persistence;

namespace DataServer.Network
{
    public class MenuItemsHandler : IRequestHandler
    {
        private IUnitOfWork unitOfWork;

        private JsonSerializerOptions options;
        private JsonSerializerOptions optionsWithoutConverter;

        public MenuItemsHandler()
        {
            this.unitOfWork = new UnitOfWork(new RestaurantDbContext());

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
                case "getMenuItems":
                    return await GetMenuItems(args);
                case "createMenuItem":
                    return await CreateMenuItem(args);
                default:
                    return "";
            }
        }

        private async Task<string> GetMenuItems(string args)
        {
            int menuId = Int32.Parse(args);
            return  JsonSerializer.Serialize(await unitOfWork.MenuItemsRepository.ReadMenuItemsAsync(menuId), options);
        }
        private async Task<string> CreateMenuItem(string args)
        {
            MenuItem menuItem = JsonSerializer.Deserialize<MenuItem>(args, options);
            Console.WriteLine(menuItem.ToString());
            await unitOfWork.MenuItemsRepository.CreateMenuItemAsync(menuItem);
            await unitOfWork.Save();
            return JsonSerializer.Serialize(menuItem, optionsWithoutConverter);
        }
    }
}