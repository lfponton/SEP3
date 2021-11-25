package dk.restaurant.controllers;

import dk.restaurant.models.MenuItemsSelection;
import dk.restaurant.network.IClient;
import dk.restaurant.network.IMenuItemsSelectionsClient;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;

import java.io.IOException;
import java.util.List;

public class MenuItemsSelectionsController
{
  private IMenuItemsSelectionsClient client;

  public MenuItemsSelectionsController(IClient client)
  {
    this.client = client.getMenuItemsSelectionsClient();
  }

  @GetMapping("/menuItemsSelections/{menuId}")
  public List<MenuItemsSelection> GetMenuItemsSelections(
      @PathVariable int menuId) throws IOException
  {
    return client.getMenuItemsSelections(menuId);
  }
}
