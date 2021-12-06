
using System.Collections.Generic;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient {
    public interface IAccountService {
    
      
        public Task<T> GetAsync<T>(string email, string password);
        public Task PostAsync<T>(T customer);
        public Task UpdateCustomerAsync(Customer customer);
        public  Task DeleteCustomer(long id);
        

        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<Employee> CreateEmployeeAsync(Employee employee);

        Task<Employee> GetEmployeeAccountAsync(string email, string password);
        Task<Customer> GetCustomerAccountAsync(string email, string password);


    }
}