using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Models;


namespace WebClient {
    public class RestClient : IRestClient {
        private string requestUrl = "https://localhost:8080";
        
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
        
        
       
}}