package dk.restaurant.network;

public interface IClientFactory
{
  IOrdersClient getOrdersClient();
  IMenusClient getMenusClient();
  IMenuItemsClient getMenuItemsClient();
  IMenuItemsSelectionsClient getMenuItemsSelectionsClient();
  ITableBookingsClient getTableBookingsClient();
  IAccountsClient getAccountsClient();
  IRestaurantClient getRestaurantClient();
}
