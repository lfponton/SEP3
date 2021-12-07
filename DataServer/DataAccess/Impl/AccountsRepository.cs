using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataServer.Models;
using DataServer.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DataServer.DataAccess.Impl
{
    public class AccountsRepository : IAccountsRepository
    {
        private RestaurantDbContext context;

        public AccountsRepository(RestaurantDbContext context)
        {
            this.context = context;
        }
        public async Task UpdateCustomerAsync(Customer customer)
        {
            Customer toUpdate = await context.Customers.FirstAsync(c => c.Id == customer.Id);
            toUpdate.Email = customer.Email;
            toUpdate.FirstName = customer.FirstName;
            toUpdate.LastName = customer.LastName;
            toUpdate.Password = customer.Password;
            context.Update(toUpdate);
        }

        public async Task DeleteCustomer(long id)
        {
            Customer toRemove = await context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (toRemove != null)
            {
                context.Customers.Remove(toRemove);
            }
        }

        public async Task<Person> CreateAccountAsync(Person person)
        {
            if (person.GetType() == typeof(Customer))
            {
                var customer = new Customer()
                {
                    Email = person.Email,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Password = person.Password
                };
                await context.Customers.AddAsync(customer);
                return customer;
            }
            if (person.GetType() == typeof(Employee))
            {
                var employee = new Employee()
                {
                    Email = person.Email,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Password = person.Password
                };
                await context.Employees.AddAsync(employee);
                return employee;
            }

            return person;
        }

        public async Task<Customer> GetCustomerAccountAsync(string email)
        {
           return await context.Customers.FirstOrDefaultAsync(c => c.Email.Equals(email));
        }
        
        public async Task<Employee> GetEmployeeAccountAsync(string email)
        {
            return await context.Employees.FirstOrDefaultAsync(e => e.Email.Equals(email));
        }
    }
}