using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebClient.Data.ValidationHandler;
using WebClient.Models;

namespace WebClient.Data.Impl
{
    public class AccountWebService : IAccountService
    {
        private readonly HttpClient client;
        private JsonSerializerOptions options;
        private string uri = "http://localhost:8080";

        private IAccountService accountServiceImplementation;

        public AccountWebService()
        {
            client = new HttpClient();
            options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
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
            HttpResponseMessage response =
                await client.GetAsync($"{uri}/accounts/employees/?email={email}&password={password}");
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
            HttpResponseMessage response =
                await client.GetAsync($"{uri}/accounts/customers/?email={email}&password={password}");
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

        public async Task UpdateCustomerAsync(Customer customer)
        {
            string tbAsJson = JsonSerializer.Serialize(customer);
            HttpContent content = new StringContent(tbAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PatchAsync($"{uri}/accounts/customers", content);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            string result = await response.Content.ReadAsStringAsync();
            customer = JsonSerializer.Deserialize<Customer>(result);
        }

        public async Task DeleteCustomer(long id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"{uri}/accounts/customers/{id}");
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            string tbAsJson = JsonSerializer.Serialize(employee);
            HttpContent content = new StringContent(tbAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PatchAsync($"{uri}/accounts/employees", content);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            string result = await response.Content.ReadAsStringAsync();
            employee = JsonSerializer.Deserialize<Employee>(result);
        }

        public async Task DeleteEmployee(long id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"{uri}/accounts/employees/{id}");
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
        }
    }
}