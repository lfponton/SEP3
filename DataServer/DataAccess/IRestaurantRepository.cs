using System.Text.Json;
using System.Threading.Tasks;
using DataServer.Models;

namespace DataServer.DataAccess.Impl
{
    public interface IRestaurantRepository
    {
        Task<Restaurant> GetRestaurantAsync();
    }
}