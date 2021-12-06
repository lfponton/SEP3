package dk.restaurant.network.impl;

import dk.restaurant.network.*;

public class ClientFactory implements IClientFactory
{
  public ClientFactory()
  {
  }

  @Override public IOrdersClient getOrdersClient()
  {
    return new OrdersClient();
  }

  @Override public IMenusClient getMenusClient()
  {
    return new MenusClient();
  }

  @Override public IMenuItemsClient getMenuItemsClient()
  {
    return new MenuItemsClient();
  }

  @Override public IOrderItemsClient getOrderItemsClient()
  {
    return new OrderItemsClient();
  }

  @Override public IMenuItemsSelectionsClient getMenuItemsSelectionsClient()
  {
    return new MenuItemsSelectionsClient();
  }

  @Override
  public ITableBookingsClient getTableBookingsClient() {
    return new TableBookingsClient();
  }

  @Override public IAccountsClient getAccountsClient()
  {
    return new AccountsClient();
  }

}