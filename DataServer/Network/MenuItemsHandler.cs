using System;
using System.Text.Json;
using System.Threading.Tasks;
using DataServer.DataAccess;

namespace DataServer.Network
{
    public class MenuItemsHandler : IRequestHandler
    {
        private IDaoFactory daoFactory;

        private JsonSerializerOptions options;
        private JsonSerializerOptions optionsWithoutConverter;

        public MenuItemsHandler(IDaoFactory daoFactory)
        {
            this.daoFactory = daoFactory;

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
                default:
                    return "";
            }
        }

        private async Task<string> GetMenuItems(string args)
        {
            int menuId = Int32.Parse(args);
            return  JsonSerializer.Serialize(await daoFactory.MenuItemDao.ReadMenuItemsAsync(menuId), options);
        }
    }
}