using System;
using System.Text.Json;
using System.Threading.Tasks;
using DataServer.DataAccess.Impl;
using DataServer.Models;
using DataServer.Persistence;

namespace DataServer.Network
{
    public class MenuItemsSelectionsHandler : IRequestHandler
    {
        private IUnitOfWork unitOfWork;

        private JsonSerializerOptions options;

        public MenuItemsSelectionsHandler()
        {
            this.unitOfWork = new UnitOfWork(new RestaurantDbContext());

            options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            options.Converters.Add(new DateTimeConverter());
        }

        public async Task<string> ProcessClientRequestType(string requestType, string args)
        {
            switch (requestType)
            {
                case "getMenuItemsSelections":
                    return await GetMenuItemsSelections(args);
                case "createMenuItemsSelection":
                    return await CreateMenuItemsSelection(args);
                default:
                    return "";
            }
        }

        private async Task<string> CreateMenuItemsSelection(string args)
        {
            MenuItemsSelection menuItemsSelection = JsonSerializer.Deserialize<MenuItemsSelection>(args, options);
            string jsonMenuItemsSelection = JsonSerializer.Serialize(
                await unitOfWork.MenuItemsSelectionsRepository.CreateMenuItemsSelectionAsync(menuItemsSelection),
                options);
            await unitOfWork.Save();
            return jsonMenuItemsSelection;
        }

        private async Task<string> GetMenuItemsSelections(string args)
        {
            int menuId = Int32.Parse(args);
            string response =
                JsonSerializer.Serialize(await unitOfWork.MenuItemsSelectionsRepository.GetMenuItemsSelections(menuId),
                    options);
            return response;
        }
    }
}