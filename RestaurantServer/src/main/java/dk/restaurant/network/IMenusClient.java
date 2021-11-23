package dk.restaurant.network;

import dk.restaurant.models.Menu;

import java.util.List;

public interface IMenusClient
{
  List<Menu> getMenus();
  void createMenu(Menu menu);
}
