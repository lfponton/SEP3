using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Models;
using WebClient.Models;


namespace WebClient {
    public class AccountService : IAccountService{
        private static string requestUrl = "https://localhost:8080";
        private static readonly HttpClient client;

        private IAccountService accountServiceImplementation;

        //Get methods 
        public async Task<T> GetAsync<T>(string email, string password) {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"{requestUrl}/Customer?email={email}&password={password}");
            string result = await responseMessage.Content.ReadAsStringAsync();
            
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception(result);

            T item = JsonSerializer.Deserialize<T>(result, new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return item;
        }
        
        

       
       
        //Post methods
        
        public async Task PostAsync<T>(T customer) {
            using HttpClient client = new HttpClient();

            string itemAsJson = JsonSerializer.Serialize(customer);
            StringContent content = new StringContent(
                itemAsJson, Encoding.UTF8, "application/Json");
            HttpResponseMessage responseMessage = await client.PostAsync($"{requestUrl}/Customer", content);
            string result = await responseMessage.Content.ReadAsStringAsync();
            
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception(result);

            T newItem = JsonSerializer.Deserialize<T>(result, new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }); 
           // return newItem;
        }

        public Task UpdateCustomerAsync(DataServer.Models.Customer customer)
        {
            return accountServiceImplementation.UpdateCustomerAsync(customer);
        }

        Task IAccountService.DeleteCustomer(long id)
        {
            return accountServiceImplementation.DeleteCustomer(id);
        }


        public static async Task UpdateCustomerAsync( Customer customer)
        {
            string tbAsJson = JsonSerializer.Serialize(customer);
            HttpContent content = new StringContent(tbAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PatchAsync($"{requestUrl}//Customer", content);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            string result = await response.Content.ReadAsStringAsync();
            customer = JsonSerializer.Deserialize<Customer>(result);
        }

        public static async Task DeleteCustomer(long id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                    $"{requestUrl}/Customer/{id}");
                if(!response.IsSuccessStatusCode)
                    throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            }
    }}