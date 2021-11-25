using System.Threading.Tasks;
using DataServer.Models;

namespace DataServer.DataAccess
{
    public interface IAccountsRepository
    {
        Task CreateCustomerAsync(Customer customer);
        Task<Customer> ReadCustomerAsync(string email);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomer(long id);
    }
}