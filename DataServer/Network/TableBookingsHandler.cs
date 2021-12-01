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
                case "updateTableBooking":
                    return await UpdateTableBooking(args);
                case "createTableBooking":
                    return await CreateTableBooking(args);
                default:
                    return "";
            }
           
        }

        private async Task<string> CreateTableBooking(string args)
        {
            Console.WriteLine($"args====>{args}");

            var tableBooking = JsonSerializer.Deserialize<TableBooking>(args, options);
            await unitOfWork.TableBookingsRepository.CreateTableBookingAsync(tableBooking);
            await unitOfWork.Save();
            Console.WriteLine("After save");

            return JsonSerializer.Serialize(tableBooking, optionsWithoutConverter);

        }

        private async Task<string> UpdateTableBooking(string args)
        {
            var tableBooking = JsonSerializer.Deserialize<TableBooking>(args, options);
            await unitOfWork.TableBookingsRepository.UpdateTableBookingAsync(tableBooking);
            await unitOfWork.Save();
            return JsonSerializer.Serialize(tableBooking, optionsWithoutConverter);
        }

        private async Task<string> GetTableBookings(string args)
        {
            var dateTime = JsonSerializer.Deserialize<DateTime>(args, options);
            return JsonSerializer.Serialize(await unitOfWork.TableBookingsRepository.GetTableBookingsAsync(dateTime.Date), optionsWithoutConverter);
        }
    }
}