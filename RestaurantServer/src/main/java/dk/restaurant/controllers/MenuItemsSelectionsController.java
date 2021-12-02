package dk.restaurant.controllers;

import dk.restaurant.models.MenuItemsSelection;
import dk.restaurant.network.IClientFactory;
import dk.restaurant.network.IMenuItemsSelectionsClient;
import dk.restaurant.services.IMenuItemsSelectionsService;
import dk.restaurant.services.IServiceFactory;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.io.IOException;
import java.util.List;

@RestController
public class MenuItemsSelectionsController
{
  private IMenuItemsSelectionsService service;

  public MenuItemsSelectionsController(IServiceFactory serviceFactory)
  {
    this.service = serviceFactory.getMenuItemsSelectionsService();
  }

  @GetMapping("/menuItemsSelections/{menuId}")
  public List<MenuItemsSelection> GetMenuItemsSelections(
      @PathVariable int menuId) throws IOException
  {
    return service.getMenuItemsSelections(menuId);
  }

  @PostMapping("/menuItemsSelections")
  @ResponseStatus(HttpStatus.CREATED)
  public MenuItemsSelection createMenuItemsSelection(@RequestBody MenuItemsSelection menuItemsSelection)
  {
    return service.createMenuItemsSelection(menuItemsSelection);
  }
}
