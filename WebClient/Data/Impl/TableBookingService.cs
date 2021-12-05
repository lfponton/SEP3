using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Data.Impl
{
    public class TableBookingService : ITableBookingService
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
            HttpResponseMessage response =
                await client.GetAsync($"{uri}/tableBookings?bookingDate={bookingDateTime.ToString()}");
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            string result = await response.Content.ReadAsStringAsync();
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

        public async Task<TableBooking> UpdateTableBooking(TableBooking tableBooking)
        {
            string tbAsJson = JsonSerializer.Serialize(tableBooking,options);
            HttpContent content = new StringContent(tbAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PatchAsync($"{uri}//tableBookings/{tableBooking.TableBookingId}", content);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            string result = await response.Content.ReadAsStringAsync();
            var updatedBooking = JsonSerializer.Deserialize<TableBooking>(result, options);
            return updatedBooking;

        }
        
        

        public async Task<TableBooking> GetBookingById(long tableBookingId)
        {

            HttpResponseMessage response = await client.GetAsync($"{uri}/tableBookings/{tableBookingId}");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"{this} caught exception: {await response.Content.ReadAsStringAsync()} with status code {response.StatusCode}");
                throw new Exception(await response.Content.ReadAsStringAsync());
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            }
                
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);

            var tableBooking = JsonSerializer.Deserialize<TableBooking>(result, options);
            return tableBooking;
        }
    }


}