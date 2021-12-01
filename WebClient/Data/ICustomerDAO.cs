using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using WebClient.Models;

namespace WebClient.Data {
    public interface ICustomerDAO {
        Task<Customer> AddCustomerAsync(Customer customer);
        Task updateCustomerAsync(string email,Customer customer);
        Task<Customer> GetCustomerAsync(string email, string password);
    }
}