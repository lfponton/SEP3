package dk.restaurant.controllers;

import dk.restaurant.models.OrderItem;
import dk.restaurant.network.IClient;
import dk.restaurant.network.IOrderItemsClient;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class OrderItemController
{
    private IOrderItemsClient client;

    public OrderItemController(IClient client)
    {
        this.client = client.getOrderItemsClient();
    }

    @GetMapping("/orderItems/{id}")
    @ResponseBody
    public List<OrderItem> getOrdersItems(@PathVariable("id") long orderId)
    {
        return client.getOrderItems(orderId);
    }

    @PostMapping("/orderItems")
    @ResponseStatus(HttpStatus.CREATED)
    public OrderItem createOrderItem(@RequestBody OrderItem orderItem)
    {
        return client.createOrderItem(orderItem);
    }

    @DeleteMapping(value = "/orderItems/{id}")
    public ResponseEntity<Long> deletePost(@PathVariable Long id) {
        try {
             client.deleteOrderItem(id);
            return new ResponseEntity<>(id, HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.NOT_FOUND);
        }


    }
}