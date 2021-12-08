using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebClient.Data.validationhandler;
using WebClient.Models;

namespace WebClient.Data.Impl {
    public class AccountWebService : IAccountService{
        private static string uri = "http://localhost:8080";
        private static readonly HttpClient client;
        private JsonSerializerOptions options;

        private IAccountService accountServiceImplementation;

        public AccountWebService()
        {
            options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        //Get methods 
        public async Task<T> GetAsync<T>(string email, string password) {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"{uri}/Customer?email={email}&password={password}");
            string result = await responseMessage.Content.ReadAsStringAsync();
            
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception(result);

            T item = JsonSerializer.Deserialize<T>(result, new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return item;
        }
        
        

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            using HttpClient client = new HttpClient();
            string personAsJson = JsonSerializer.Serialize(customer, options);
            HttpContent content = new StringContent(personAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri + "/accounts/customers", content);
            if (response.IsSuccessStatusCode)
            {
                string personAsJsonResponse = await response.Content.ReadAsStringAsync();
                Customer resultOrder = JsonSerializer.Deserialize<Customer>(personAsJsonResponse, options);
                return resultOrder;
            }
            throw new Exception($"Error,{response.StatusCode},{response.ReasonPhrase}");
        }
        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            using HttpClient client = new HttpClient();
            string personAsJson = JsonSerializer.Serialize(employee, options);
            HttpContent content = new StringContent(personAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri + "/accounts/employees", content);
            if (response.IsSuccessStatusCode)
            {
                string personAsJsonResponse = await response.Content.ReadAsStringAsync();
                Employee resultOrder = JsonSerializer.Deserialize<Employee>(personAsJsonResponse, options);
                return resultOrder;
            }
            throw new Exception($"Error,{response.StatusCode},{response.ReasonPhrase}");
        }
      
        public async Task<Employee> GetEmployeeAccountAsync(string email, string password)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"{uri}/accounts/employees/?email={email}&password={password}");
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                var exceptionResponse = JsonSerializer.Deserialize<ExceptionResponse>(errorMessage, options);
                throw new Exception($"{exceptionResponse.Message}");
            }
            string result = await response.Content.ReadAsStringAsync();
            Employee employee = JsonSerializer.Deserialize<Employee>(result, options);
            return employee;
        }

        public async Task<Customer> GetCustomerAccountAsync(string email, string password)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"{uri}/accounts/customers/?email={email}&password={password}");
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                var exceptionResponse = JsonSerializer.Deserialize<ExceptionResponse>(errorMessage, options);
                throw new Exception($"{exceptionResponse.Message}");
            }
            string result = await response.Content.ReadAsStringAsync();
            Customer customer = JsonSerializer.Deserialize<Customer>(result, options);
            return customer;
        }


        //Post methods
        
        public async Task PostAsync<T>(T customer) {
            using HttpClient client = new HttpClient();

            string itemAsJson = JsonSerializer.Serialize(customer);
            StringContent content = new StringContent(
                itemAsJson, Encoding.UTF8, "application/Json");
            HttpResponseMessage responseMessage = await client.PostAsync($"{uri}/Customer", content);
            string result = await responseMessage.Content.ReadAsStringAsync();
            
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception(result);

            T newItem = JsonSerializer.Deserialize<T>(result, new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }); 
           // return newItem;
        }

        Task IAccountService.UpdateCustomerAsync(Customer customer)
        {
            return accountServiceImplementation.UpdateCustomerAsync(customer);
        }

        Task IAccountService.DeleteCustomer(long id)
        {
            return accountServiceImplementation.DeleteCustomer(id);
        }


        public static async Task UpdateCustomerAsync(Customer customer)
        {
            string tbAsJson = JsonSerializer.Serialize(customer);
            HttpContent content = new StringContent(tbAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PatchAsync($"{uri}//Customer", content);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            string result = await response.Content.ReadAsStringAsync();
            customer = JsonSerializer.Deserialize<Customer>(result);
        }

        public static async Task DeleteCustomer(long id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                    $"{uri}/Customer/{id}");
                if(!response.IsSuccessStatusCode)
                    throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            }
    }}