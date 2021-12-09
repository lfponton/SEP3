using System.Threading.Tasks;
using DataServer.Models;

namespace DataServer.DataAccess
{
    public interface IAccountsRepository
    {
        Task<Person> CreateAccountAsync(Person person);
        Task<Customer> GetCustomerAccountAsync(string email);
        Task<Employee> GetEmployeeAccountAsync(string email);

        Task UpdateCustomerAsync(Customer customer);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteCustomer(long id);
        Task DeleteEmployee(long id);
    }
}