package dk.restaurant.services.impl;

import dk.restaurant.models.MenuItemsSelection;
import dk.restaurant.network.IClientFactory;
import dk.restaurant.network.IMenuItemsSelectionsClient;
import dk.restaurant.services.IMenuItemsSelectionsService;

import java.util.List;

public class MenuItemsSelectionsService implements IMenuItemsSelectionsService
{
  private IMenuItemsSelectionsClient client;

  public MenuItemsSelectionsService(IClientFactory clientFactory) {
    this.client = clientFactory.getMenuItemsSelectionsClient();
  }

  @Override public List<MenuItemsSelection> getMenuItemsSelections(long menuId)
  {
    return client.getMenuItemsSelections(menuId);
  }

  @Override public MenuItemsSelection createMenuItemsSelection(
      MenuItemsSelection menuItemsSelection)
  {
    return client.createMenuItemsSelection(menuItemsSelection);
  }
}
