package dk.restaurant.controllers;

import dk.restaurant.network.IClient;
import dk.restaurant.network.ITableBookingsClient;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class TableBookingsController {
    private ITableBookingsClient client;

    public TableBookingsController(IClient client)
    {
        this.client = client.getTableBookingsClient();
    }
}
