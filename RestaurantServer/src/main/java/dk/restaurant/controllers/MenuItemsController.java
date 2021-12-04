
package dk.restaurant.controllers;

import dk.restaurant.models.MenuItem;
import dk.restaurant.network.IClientFactory;
import dk.restaurant.network.IMenuItemsClient;
import dk.restaurant.services.IMenuItemsService;
import dk.restaurant.services.IServiceFactory;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

import java.io.IOException;
import java.util.List;

@RestController
public class MenuItemsController {
  private IMenuItemsService service;

  public MenuItemsController(IServiceFactory serviceFactory)
  {
    this.service = serviceFactory.getMenuItemsService();
  }

  @GetMapping("/menuItems/{menuId}")
  public List<MenuItem> GetMenuItems(@PathVariable int menuId) throws IOException
  {
    return service.getMenuItems(menuId);
  }
}