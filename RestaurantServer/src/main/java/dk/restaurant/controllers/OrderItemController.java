package dk.restaurant.controllers;

import dk.restaurant.models.Order;
import dk.restaurant.models.OrderItem;
import dk.restaurant.network.Client;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.io.Console;
import java.io.IOException;
import java.util.List;

@RestController
public class OrderItemController
{
    private Client client;

    public OrderItemController()
    {
        client = Client.getInstance();
    }

    @GetMapping("/orderItems/{id}")
    @ResponseBody
    public List<OrderItem> getOrdersItems(@PathVariable("id") long orderId) throws IOException
    {
        return client.getOrderItems(orderId);
    }

    @PostMapping("/orderItems")
    @ResponseStatus(HttpStatus.CREATED)
    public OrderItem createOrderItem(@RequestBody OrderItem orderItem)
    {
        System.out.println("OrderItemController--->"+orderItem.toString());
        return client.createOrderItem(orderItem);
    }

    @DeleteMapping(value = "/orderItems/{id}")
    public ResponseEntity<Long> deletePost(@PathVariable Long id) {
        try {
             client.deleteOrderItem(id);
            return new ResponseEntity<>(id, HttpStatus.OK);
        } catch (IOException e) {
            return new ResponseEntity<>(HttpStatus.NOT_FOUND);
        }


    }
}