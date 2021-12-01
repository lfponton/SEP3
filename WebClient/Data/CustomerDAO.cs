using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;
using WebClient.Data;
using WebClient.Models;

namespace WebClient.Data {
    public class CustomerDAO : ICustomerDAO {
        public async Task<Customer> AddCustomerAsync(Customer customer) {
            using CustomerFileContext context = new CustomerFileContext();

            Customer existing = await context.Set<Customer>().FirstOrDefaultAsync(u =>
                u.Email.Equals(customer.Email));
            
            if (existing != null) throw new Exception("That email is already taken");
            
            await context.Set<Customer>().AddAsync(customer);
            await context.SaveChangesAsync();
            return customer;
        }

        public Task updateCustomerAsync(string email, Customer customer)
        {
            throw new NotImplementedException();
        }


        public async Task<Customer> GetCustomerAsync(string email, string password) {
            using CustomerFileContext context = new CustomerFileContext();

            Customer customer = await context.Set<Customer>().FirstOrDefaultAsync(u =>
                u.Email.Equals(email) && u.Password.Equals(password));
            
            if (customer == null) throw new NullReferenceException("No such customer found");
            
            return customer;
        }

        public static async Task<Customer> UpdateCustomerAsync(string email, Customer customer) {
            using CustomerFileContext context = new CustomerFileContext();
            Customer u = await context.Set<Customer>().FirstOrDefaultAsync(u => u.Email.Equals(email));
            if (u == null) throw new NullReferenceException("No such customer found");
            u.Role = customer.Role;
            u.Password = customer.Password;
            u.FirstName = customer.FirstName;
            u.LastName = customer.LastName;
            u.Email = customer.Email;
            context.Set<Customer>().Update(u);
            await context.SaveChangesAsync();
            return u;
        }

        public static async Task DeleteCustomer(long id)
        {
            throw new NotImplementedException();
        }
    }
}