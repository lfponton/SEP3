using System.Threading.Tasks;
using DataServer.Models;

namespace DataServer.DataAccess
{
    public interface IAddressRepository
    {
        Task CreateAddressAsync(DeliveryAddress deliveryAddress);
    }
}