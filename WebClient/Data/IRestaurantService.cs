using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Data
{
    public interface IRestaurantService
    {
        public Task<Restaurant> GetRestaurantAsync();
    }
}