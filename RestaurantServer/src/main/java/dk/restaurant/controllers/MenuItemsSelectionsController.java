package dk.restaurant.controllers;

import dk.restaurant.models.Menu;
import dk.restaurant.models.MenuItemsSelection;
import dk.restaurant.network.IClient;
import dk.restaurant.network.IMenuItemsSelectionsClient;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.io.IOException;
import java.util.List;

@RestController
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

  @PostMapping("/menuItemsSelections")
  @ResponseStatus(HttpStatus.CREATED)
  public MenuItemsSelection createMenuItemsSelection(@RequestBody MenuItemsSelection menuItemsSelection)
  {
    return client.createMenuItemsSelection(menuItemsSelection);
  }
}
