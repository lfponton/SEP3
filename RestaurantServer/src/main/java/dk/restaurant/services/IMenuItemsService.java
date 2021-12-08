package dk.restaurant.services;

import dk.restaurant.models.MenuItem;

import java.util.List;

public interface IMenuItemsService
{
  List<MenuItem> getMenuItems(int menuId);

    MenuItem createMenuItem(MenuItem menuItem);
}
