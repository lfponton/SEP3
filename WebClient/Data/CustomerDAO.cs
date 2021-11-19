using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using WebClient.Data;
using WebClient.Models;

namespace WebClient.Data {
    public class CustomerDAO : ICustomerDAO {
        private CustomerFileContext fileContext;

        public CustomerDAO() {
            fileContext = new CustomerFileContext();
        }

        public async Task<Customer> GetCustomerAsync(string email, string password) {
            Customer customer = fileContext.Customers.FirstOrDefault(
                u => u.Email.Equals(email) && u.Password.Equals(password));
            if (email == null)
                throw new NullReferenceException("No customer found");
            return customer;
        }

        public async Task<Customer> AddCustomerAsync(Customer customer) {
            Customer first = fileContext.Customers.FirstOrDefault(u => u.Email.Equals(customer.Email, StringComparison.CurrentCultureIgnoreCase));
            if (first!=null && first.Equals(customer))
                throw new Exception("Customer already exists");
            fileContext.Customers.Add(customer);
            fileContext.WriteCustomersToFile();
            return first;
        }
    }
}