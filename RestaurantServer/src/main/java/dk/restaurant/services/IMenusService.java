package dk.restaurant.services;

import dk.restaurant.models.Menu;

import java.util.List;

public interface IMenusService
{
  List<Menu> getMenus(int name);
  Menu createMenu(Menu menu);
}
