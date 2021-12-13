package dk.restaurant.controllers;

import dk.restaurant.models.MenuItemsSelection;
import dk.restaurant.network.IClientFactory;
import dk.restaurant.network.IMenuItemsSelectionsClient;
import dk.restaurant.services.IMenuItemsSelectionsService;
import dk.restaurant.services.IServiceFactory;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
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
  public ResponseEntity<List<MenuItemsSelection>> GetMenuItemsSelections(
      @PathVariable int menuId) throws IOException
  {
    List<MenuItemsSelection> selections = service.getMenuItemsSelections(menuId);
    return new ResponseEntity<List<MenuItemsSelection>>(selections, HttpStatus.OK);
  }

  @PostMapping("/menuItemsSelections")
  @ResponseStatus(HttpStatus.CREATED)
  public ResponseEntity<MenuItemsSelection> createMenuItemsSelection(@RequestBody MenuItemsSelection menuItemsSelection)
  {
    MenuItemsSelection newSelection = service.createMenuItemsSelection(menuItemsSelection);
    return new ResponseEntity<MenuItemsSelection>(newSelection, HttpStatus.OK);
  }
}
