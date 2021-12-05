
using System.Collections.Generic;
using System.Threading.Tasks;
using DataServer.Models;
using Models;

namespace WebClient {
    public interface IAccountService {
    
      
        public Task<T> GetAsync<T>(string email, string password);
        public Task PostAsync<T>(T customer);
        public Task UpdateCustomerAsync( Customer customer);
        public  Task DeleteCustomer(long id);
        


    }
}