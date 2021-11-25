using System.Text.Json;
using System.Threading.Tasks;
using DataServer.DataAccess.Impl;
using DataServer.Persistence;

namespace DataServer.Network
{
    public class MenusHandler : IRequestHandler
    {
        private IUnitOfWork unitOfWork;
        private JsonSerializerOptions options;
        private JsonSerializerOptions optionsWithoutConverter;

        public MenusHandler()
        {
            unitOfWork = new UnitOfWork(new RestaurantDbContext());

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
                case "getMenus":
                    return await GetMenus();
                default:
                    return "";
            }
        }

        private async Task<string> GetMenus()
        {
           return JsonSerializer.Serialize(await unitOfWork.MenusRepository.GetMenusAsync(), options);
        }
    }
}