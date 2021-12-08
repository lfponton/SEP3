
package dk.restaurant.controllers;

import dk.restaurant.models.Menu;
import dk.restaurant.models.Order;
import dk.restaurant.network.IClientFactory;
import dk.restaurant.network.IMenusClient;
import dk.restaurant.services.IMenusService;
import dk.restaurant.services.IServiceFactory;
import org.springframework.http.HttpStatus;
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
    public Menu getMenu(@PathVariable("menuId") int menuId)
    {
        return (Menu) service.getMenus(menuId);
    }

    @GetMapping
    @RequestMapping(method = RequestMethod.GET)
    public List<Menu> getMenus(@RequestParam(value="menuId", required = true) int menuId)
    {
        return service.getMenus(menuId);
    }



    /*@GetMapping(value="/{menuId}")
    public List<Menu> getMenus() throws IOException
    {
        return service.getMenus();
    }*/

    @PostMapping("/menus")
    @ResponseStatus(HttpStatus.CREATED)
    public Menu createMenu(@RequestBody Menu menu)
    {
        return service.createMenu(menu);
    }
}
