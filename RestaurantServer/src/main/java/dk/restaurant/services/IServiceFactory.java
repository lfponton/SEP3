package dk.restaurant.services;

public interface IServiceFactory
{
  IOrdersService getOrdersService();
  IMenusService getMenusService();
  IMenuItemsService getMenuItemsService();
  IMenuItemsSelectionsService getMenuItemsSelectionsService();
  ITableBookingService getTableBookingsService();
  IAccountsService getAccountsService();
  IRestaurantService getRestaurantService();
}
