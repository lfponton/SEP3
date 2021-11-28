package dk.restaurant.network;

public interface IClient
{
  IOrdersClient getOrdersClient();
  IMenusClient getMenusClient();
  IMenuItemsClient getMenuItemsClient();
  IOrderItemsClient getOrderItemsClient();
  IMenuItemsSelectionsClient getMenuItemsSelectionsClient();
}
