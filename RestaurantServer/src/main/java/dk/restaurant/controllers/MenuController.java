
package dk.restaurant.controllers;

import dk.restaurant.models.Menu;
import dk.restaurant.models.OrderItem;
import dk.restaurant.network.IClient;
import dk.restaurant.network.IMenusClient;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.io.IOException;
import java.util.List;

@RestController
public class MenuController {

    private IMenusClient client;

    public MenuController(IClient client)
    {
        this.client = client.getMenusClient();
    }

    @GetMapping("/menus")
    public List<Menu> getMenus() throws IOException
    {
        return client.getMenus();
    }

    @PostMapping("/menus")
    @ResponseStatus(HttpStatus.CREATED)
    public Menu createMenu(@RequestBody Menu menu)
    {
        return client.createMenu(menu);
    }
}
