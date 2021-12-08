package dk.restaurant.services.impl;

import dk.restaurant.models.Menu;
import dk.restaurant.network.IClientFactory;
import dk.restaurant.network.IMenusClient;
import dk.restaurant.services.IMenusService;

import java.util.List;

public class MenusService implements IMenusService
{
  private IMenusClient client;

  public MenusService(IClientFactory clientFactory) {
    this.client = clientFactory.getMenusClient();
  }

  @Override public List<Menu> getMenus(int name)
  {
    return client.getMenus();
  }

  @Override public Menu createMenu(Menu menu)
  {
    return client.createMenu(menu);
  }
}
