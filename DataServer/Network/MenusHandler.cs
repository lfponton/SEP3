using System.Text.Json;
using System.Threading.Tasks;
using DataServer.DataAccess.Impl;
using DataServer.Models;
using DataServer.Persistence;

namespace DataServer.Network
{
    public class MenusHandler : IRequestHandler
    {
        private IUnitOfWork unitOfWork;
        private JsonSerializerOptions options;

        public MenusHandler()
        {
            unitOfWork = new UnitOfWork(new RestaurantDbContext());

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
                case "getMenus":
                    return await GetMenus();
                case "createMenu":
                    return await CreateMenu(args);
                default:
                    return "";
            }
        }

        private async Task<string> CreateMenu(string args)
        {
            Menu menu = JsonSerializer.Deserialize<Menu>(args, options);
            string jsonMenu = JsonSerializer.Serialize(await unitOfWork.MenusRepository.CreateMenuAsync(menu), options);
            await unitOfWork.Save();
            return jsonMenu;
        }

        private async Task<string> GetMenus()
        {
           return JsonSerializer.Serialize(await unitOfWork.MenusRepository.GetMenusAsync(), options);
        }
    }
}