package dk.restaurant.services.impl;

import dk.restaurant.models.MenuItem;
import dk.restaurant.network.IClientFactory;
import dk.restaurant.network.IMenuItemsClient;
import dk.restaurant.services.IMenuItemsService;

import java.util.List;

public class MenuItemsService implements IMenuItemsService
{
  private IMenuItemsClient client;

  public MenuItemsService(IClientFactory clientFactory) {
    this.client = clientFactory.getMenuItemsClient();
  }

  @Override public List<MenuItem> getMenuItems(int menuId)
  {
    return client.getMenuItems(menuId);
  }

  @Override
  public MenuItem createMenuItem(MenuItem menuItem)
  {
    return client.createMenuItem(menuItem);
  }
}
