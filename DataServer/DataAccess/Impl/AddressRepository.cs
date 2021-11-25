using System.Threading.Tasks;
using DataServer.Models;
using DataServer.Persistence;

namespace DataServer.DataAccess.Impl
{
    public class AddressRepository : IAddressRepository
    {
        private RestaurantDbContext context;

        public AddressRepository(RestaurantDbContext context)
        {
            this.context = context;
        }
        public async Task CreateAddressAsync(DeliveryAddress deliveryAddress)
        {
            await context.Addresses.AddAsync(deliveryAddress);
        }
    }
}