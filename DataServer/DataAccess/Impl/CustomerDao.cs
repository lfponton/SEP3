using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataServer.Models;
using DataServer.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DataServer.DataAccess.Impl
{
    public class CustomerDao : ICustomerDao
    {
        private RestaurantDbContext context;

        public CustomerDao(RestaurantDbContext context)
        {
            this.context = context;
        }
        public async Task CreateCustomerAsync(Customer customer)
        {
            await context.AddAsync(customer);
            await context.SaveChangesAsync();
        }

        public async Task<Customer> ReadCustomerAsync(string email)
        {
            IList<Customer> customers = await context.Customers.ToListAsync();
            return customers.
                First(c => c.Email == email);
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            Customer toUpdate = await context.Customers.FirstAsync(c => c.Id == customer.Id);
            toUpdate.Email = customer.Email;
            toUpdate.FirstName = customer.FirstName;
            toUpdate.LastName = customer.LastName;
            toUpdate.Password = customer.Password;
            context.Update(toUpdate);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCustomer(long id)
        {
            Customer toRemove = await context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (toRemove != null)
            {
                context.Customers.Remove(toRemove);
                await context.SaveChangesAsync();
            }
        }
    }
}