package dk.restaurant.services;

import dk.restaurant.network.*;

public interface IServiceFactory
{
  IOrdersService getOrdersService();
  IMenusService getMenusService();
  IMenuItemsService getMenuItemsService();
  IOrderItemsService getOrderItemsService();
  IMenuItemsSelectionsService getMenuItemsSelectionsService();
  ITableBookingService getTableBookingsService();
}
