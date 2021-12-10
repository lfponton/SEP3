package dk.restaurant.network;

public interface IClientFactory
{
  IOrdersClient getOrdersClient();
  IMenusClient getMenusClient();
  IMenuItemsClient getMenuItemsClient();
  IOrderItemsClient getOrderItemsClient();
  IMenuItemsSelectionsClient getMenuItemsSelectionsClient();
  ITableBookingsClient getTableBookingsClient();
  IAccountsClient getAccountsClient();
  IRestaurantClient getRestaurantClient();
}
