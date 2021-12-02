package dk.restaurant.services;

import dk.restaurant.models.MenuItemsSelection;

import java.util.List;

public interface IMenuItemsSelectionsService
{
  List<MenuItemsSelection> getMenuItemsSelections(long menuId);
  MenuItemsSelection createMenuItemsSelection(MenuItemsSelection menuItemsSelection);
}
