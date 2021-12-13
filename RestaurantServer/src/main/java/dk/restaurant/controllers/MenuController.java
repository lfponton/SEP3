
package dk.restaurant.controllers;

import dk.restaurant.models.Menu;
import dk.restaurant.services.IMenusService;
import dk.restaurant.services.IServiceFactory;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.io.IOException;
import java.util.List;

@RestController
@RequestMapping("/menus")
public class MenuController {

    private IMenusService service;

    public MenuController(IServiceFactory serviceFactory)
    {
        this.service = serviceFactory.getMenusService();
    }

    @GetMapping(value = "/{menuId}")
    public ResponseEntity<Menu> getMenu(@PathVariable("menuId") int menuId)
    {
        Menu menu = (Menu) service.getMenus(menuId);
        return new ResponseEntity<Menu>(menu, HttpStatus.OK);
    }

    @GetMapping
    @RequestMapping(method = RequestMethod.GET)
    public ResponseEntity<List<Menu>> getMenus()
    {
        List<Menu> menus = service.getMenus();
        return new ResponseEntity<List<Menu>>(menus, HttpStatus.OK);
    }

    @PostMapping
    @ResponseStatus(HttpStatus.CREATED)
    public ResponseEntity<Menu> createMenu(@RequestBody Menu menu)
    {
        Menu newMenu =  service.createMenu(menu);
        return new ResponseEntity<Menu>(newMenu, HttpStatus.OK);
    }
}
