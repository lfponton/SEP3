
namespace DataServer.DataAccess
{
    public interface IDaoFactory
    {
        ICustomerDao CustomerDao { get; }
        IOrdersDao OrdersDao { get; }
        IAddressDao AddressDao { get; }
        IMenuDao MenuDao { get; }
        IMenuItemDao MenuItemDao { get; }
        public IOrderItemDao OrderItemsDao { get; }
    }
}