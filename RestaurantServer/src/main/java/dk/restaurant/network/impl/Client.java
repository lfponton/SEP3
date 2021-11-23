package dk.restaurant.network.impl;

import dk.restaurant.network.*;

public class Client implements IClient
{
  public Client()
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

}