using System.Linq;
using System.Threading.Tasks;
using DataServer.Models;
using DataServer.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DataServer.DataAccess.Impl
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private RestaurantDbContext context;

        public RestaurantRepository(RestaurantDbContext context)
        {
            this.context = context;

        }
        
        public async Task<Restaurant> GetRestaurantAsync()
        {
            return new Restaurant()
            {
                Capacity = 10
            };
        }
    }
}