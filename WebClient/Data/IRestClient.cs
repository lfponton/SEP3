using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace WebClient {
    public interface IRestClient {
    
      
        public Task<T> GetAsync<T>(string email, string password);
        public Task PostAsync<T>(T customer);
   
       
    }
}