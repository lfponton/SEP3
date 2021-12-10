using System.Text.Json;
using System.Threading.Tasks;
using DataServer.DataAccess.Impl;
using DataServer.Persistence;

namespace DataServer.Network
{
    public class RestaurantHandler :IRequestHandler
    {
        private IUnitOfWork unitOfWork;
        private JsonSerializerOptions options;
        private JsonSerializerOptions optionsWithoutConverter;

        public RestaurantHandler()
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
                case "getRestaurant":
                    return await GetRestaurant();
                default:
                    return "";
                
            }
        }

        private async Task<string> GetRestaurant()
        {
            return JsonSerializer.Serialize(await unitOfWork.RestaurantRepository.GetRestaurantAsync(), options);
        }
    }
}