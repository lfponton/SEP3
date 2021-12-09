using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Data {
    public interface IAccountService {
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomer(long id);
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<Employee> CreateEmployeeAsync(Employee employee);

        Task<Employee> GetEmployeeAccountAsync(string email, string password);
        Task<Customer> GetCustomerAccountAsync(string email, string password);


    }
}