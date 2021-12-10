package dk.restaurant.services.impl;

import dk.restaurant.network.IClientFactory;
import dk.restaurant.services.*;

public class ServiceFactory implements IServiceFactory
{
  private IClientFactory clientFactory;

  public ServiceFactory(IClientFactory clientFactory)
  {
    this.clientFactory = clientFactory;
  }

  @Override public IOrdersService getOrdersService()
  {
    return new OrdersService(clientFactory);
  }

  @Override public IMenusService getMenusService()
  {
    return new MenusService(clientFactory);
  }

  @Override public IMenuItemsService getMenuItemsService()
  {
    return new MenuItemsService(clientFactory);
  }

  @Override public IOrderItemsService getOrderItemsService()
  {
    return new OrderItemsService(clientFactory);
  }

  @Override public IMenuItemsSelectionsService getMenuItemsSelectionsService()
  {
    return new MenuItemsSelectionsService(clientFactory);
  }

  @Override public ITableBookingService getTableBookingsService()
  {
    return new TableBookingService(clientFactory);
  }

  @Override public IAccountsService getAccountsService()
  {
    return new AccountsService(clientFactory);
  }

  @Override
  public IRestaurantService getRestaurantService() {
    return new RestaurantService(clientFactory);
  }
}
