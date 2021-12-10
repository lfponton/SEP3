package dk.restaurant.network;

import dk.restaurant.models.Menu;
import dk.restaurant.models.MenuItem;

import java.util.List;

public interface IMenuItemsClient
{
  List<MenuItem> getMenuItems(int menuId);
  MenuItem createMenuItem(MenuItem menuItem);
  MenuItem getMenuItem(int menuItemId);
}
