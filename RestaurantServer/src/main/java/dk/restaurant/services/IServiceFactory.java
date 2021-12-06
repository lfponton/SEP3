package dk.restaurant.services;

public interface IServiceFactory
{
  IOrdersService getOrdersService();
  IMenusService getMenusService();
  IMenuItemsService getMenuItemsService();
  IOrderItemsService getOrderItemsService();
  IMenuItemsSelectionsService getMenuItemsSelectionsService();
  ITableBookingService getTableBookingsService();
  IAccountsService getAccountsService();
}
