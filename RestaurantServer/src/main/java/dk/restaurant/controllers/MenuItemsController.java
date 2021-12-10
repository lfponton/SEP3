
package dk.restaurant.controllers;

import dk.restaurant.models.MenuItem;
import dk.restaurant.models.OrderItem;
import dk.restaurant.network.IClientFactory;
import dk.restaurant.network.IMenuItemsClient;
import dk.restaurant.services.IMenuItemsService;
import dk.restaurant.services.IServiceFactory;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.io.IOException;
import java.util.List;

@RestController
public class MenuItemsController {
  private IMenuItemsService service;

  public MenuItemsController(IServiceFactory serviceFactory)
  {
    this.service = serviceFactory.getMenuItemsService();
  }


  @GetMapping("/menuItems/{id}")
  @ResponseBody
  public List<MenuItem> getMenuItems(@PathVariable("id") int menuId)
  {

    return service.getMenuItems(menuId);
  }
  @PostMapping("/menuItems")
  @ResponseStatus(HttpStatus.CREATED)
  public MenuItem createMenuItem(@RequestBody MenuItem menuItem)
  {
    return service.createMenuItem(menuItem);
  }
}