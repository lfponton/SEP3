package dk.restaurant.network;

import dk.restaurant.models.MenuItemsSelection;

import java.util.List;

public interface IMenuItemsSelectionsClient
{
  List<MenuItemsSelection> getMenuItemsSelections(long menuId);
}
