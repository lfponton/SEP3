using System.Threading.Tasks;
using DataServer.Models;

namespace DataServer.DataAccess
{
    public interface IAddressDao
    {
        Task CreateAddressAsync(DeliveryAddress deliveryAddress);
    }
}