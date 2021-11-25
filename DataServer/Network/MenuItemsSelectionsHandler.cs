using System;
using System.Text.Json;
using System.Threading.Tasks;
using DataServer.DataAccess.Impl;
using DataServer.Persistence;

namespace DataServer.Network
{
    public class MenuItemsSelectionsHandler : IRequestHandler
    {
        private IUnitOfWork unitOfWork;

        private JsonSerializerOptions options;
        private JsonSerializerOptions optionsWithoutConverter;

        public MenuItemsSelectionsHandler()
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
                case "getMenuItemsSelections":
                    return await GetMenuItemsSelections(args);
                default:
                    return "";
            }
        }

        private async Task<string> GetMenuItemsSelections(string args)
        {
            int menuId = Int32.Parse(args);
            string response =
                JsonSerializer.Serialize(await unitOfWork.MenuItemsSelectionsRepository.GetMenuItemsSelections(menuId),
                    options);
            Console.WriteLine(response);
            return  response;
        }
    }
}