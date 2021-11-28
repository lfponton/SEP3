using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Data.Impl
{
    public class TableBookingService:ITableBookingService
    {
        private readonly HttpClient client;
        private JsonSerializerOptions options;
        private string uri = "http://localhost:8080";

        public TableBookingService()
        {
            client = new HttpClient();
            options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<List<TableBooking>> GetBookings(DateTime bookingDateTime)
        {
            HttpResponseMessage response = await client.GetAsync($"{uri}/tableBookings/{bookingDateTime}");
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
            List<TableBooking> tableBookings = JsonSerializer.Deserialize<List<TableBooking>>(result, options);
            return tableBookings; 
        }

        public Task<Table> GetTables()
        {
            throw new NotImplementedException();
        }

        public Task<TableBooking> CreateTableBooking(TableBooking tableBooking)
        {
            throw new NotImplementedException();
        }
    }
}