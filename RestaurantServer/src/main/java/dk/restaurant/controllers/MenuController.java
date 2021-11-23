
package dk.restaurant.controllers;

import dk.restaurant.models.Menu;
import dk.restaurant.network.IClient;
import dk.restaurant.network.IMenusClient;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

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
        System.out.println("Getting Menus Controller");
        return client.getMenus();
    }
}
