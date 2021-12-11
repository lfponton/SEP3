using System.Threading.Tasks;

namespace DataServer.DataAccess.Impl
{
    public interface IUnitOfWork
    {
        IOrdersRepository OrdersRepository { get; }
        IAccountsRepository AccountsRepository { get; }
        IAddressRepository AddressRepository { get; }
        IMenusRepository MenusRepository { get; }
        IMenuItemsRepository MenuItemsRepository { get; }
        IMenuItemsSelectionsRepository MenuItemsSelectionsRepository { get; }
        ITableBookingsRepository TableBookingsRepository { get; }
        IRestaurantRepository RestaurantRepository { get; }
        Task Save();

    }

 
}