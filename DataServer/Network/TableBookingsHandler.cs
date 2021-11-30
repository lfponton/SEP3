using System;
using System.Text.Json;
using System.Threading.Tasks;
using DataServer.DataAccess.Impl;
using DataServer.Models;
using DataServer.Persistence;

namespace DataServer.Network
{
    public class TableBookingsHandler:IRequestHandler
    {
        private IUnitOfWork unitOfWork;
        private JsonSerializerOptions options;
        private JsonSerializerOptions optionsWithoutConverter;

        public TableBookingsHandler()
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
                case "getTableBookings":
                    return await GetTableBookings(args);
                default:
                    return "";
            }
           
        }

        private async Task<string> GetTableBookings(string args)
        {
            Console.WriteLine($"bookings handler {args}");
            DateTime dateTime = new DateTime();
               dateTime = JsonSerializer.Deserialize<DateTime>(args, options);
            Console.WriteLine($"{dateTime}");
            return JsonSerializer.Serialize(await unitOfWork.TableBookingsRepository.GetTableBookingsAsync(dateTime.Date), optionsWithoutConverter);
        }
    }
}