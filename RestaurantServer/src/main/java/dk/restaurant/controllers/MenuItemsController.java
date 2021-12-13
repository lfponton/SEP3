
package dk.restaurant.controllers;

import dk.restaurant.models.Menu;
import dk.restaurant.models.MenuItem;
import dk.restaurant.services.IMenuItemsService;
import dk.restaurant.services.IServiceFactory;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/menuItems")
public class MenuItemsController {
  private IMenuItemsService service;

  public MenuItemsController(IServiceFactory serviceFactory)
  {
    this.service = serviceFactory.getMenuItemsService();
  }


  @GetMapping("/{menuItemId}")
  @ResponseBody
  public ResponseEntity<List<MenuItem>> getMenuItems(@PathVariable("menuItemId") int menuItemId)
  {
    List<MenuItem> menus = service.getMenuItems(menuItemId);
    return new ResponseEntity<List<MenuItem>>(menus, HttpStatus.OK);
  }
  @PostMapping
  @ResponseStatus(HttpStatus.CREATED)
  public ResponseEntity<MenuItem> createMenuItem(@RequestBody MenuItem menuItem)
  {
    MenuItem newMenuItem = service.createMenuItem(menuItem);
    return new ResponseEntity<MenuItem>(newMenuItem, HttpStatus.OK);
  }
}