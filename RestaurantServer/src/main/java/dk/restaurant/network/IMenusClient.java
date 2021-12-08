package dk.restaurant.network;

import dk.restaurant.models.Menu;
import dk.restaurant.models.Order;
import dk.restaurant.models.TableBooking;

import java.util.List;

public interface IMenusClient
{
  List<Menu> getMenus();
  Menu createMenu(Menu menu);
  Menu getMenu(int menuId);

}
