
package dk.restaurant.controllers;

import dk.restaurant.models.MenuItem;
import dk.restaurant.network.IClient;
import dk.restaurant.network.IMenuItemsClient;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

import java.io.IOException;
import java.util.List;

@RestController
public class MenuItemsController {
  private IMenuItemsClient client;

  public MenuItemsController(IClient client)
  {
    this.client = client.getMenuItemsClient();
  }

  @GetMapping("/menuItems/{menuId}")
  public List<MenuItem> GetMenuItems(@PathVariable int menuId) throws IOException
  {
    return client.getMenuItems(menuId);
  }
}