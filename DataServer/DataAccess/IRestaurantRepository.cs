using System.Threading.Tasks;
using DataServer.Models;

namespace DataServer.DataAccess
{
    public interface IRestaurantRepository
    {
        Task<Restaurant> GetRestaurantAsync();
    }
}