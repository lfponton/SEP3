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
            Customer toUpdate = await context.Customers.FirstAsync(c => c.Email == customer.Email);
            toUpdate.Email = customer.Email;
            toUpdate.FirstName = customer.FirstName;
            toUpdate.LastName = customer.LastName;
            toUpdate.Password = customer.Password;
            context.Update(toUpdate);
        }
        public async Task UpdateEmployeeAsync(Employee employee)
        {
            Employee toUpdate = await context.Employees.FirstAsync(c => c.Email == employee.Email);
            toUpdate.Email = employee.Email;
            toUpdate.FirstName = employee.FirstName;
            toUpdate.LastName = employee.LastName;
            toUpdate.Password = employee.Password;
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
        public async Task DeleteEmployee(long id)
        {
            Employee toRemove = await context.Employees.FirstOrDefaultAsync(c => c.Id == id);
            if (toRemove != null)
            {
                context.Employees.Remove(toRemove);
            }
        }

        public async Task<User> CreateAccountAsync(User user)
        {
            if (user.GetType() == typeof(Customer))
            {
                var customer = new Customer()
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Password = user.Password
                };
                await context.Customers.AddAsync(customer);
                return customer;
            }
            if (user.GetType() == typeof(Employee))
            {
                var employee = new Employee()
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Password = user.Password
                };
                await context.Employees.AddAsync(employee);
                return employee;
            }

            return user;
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