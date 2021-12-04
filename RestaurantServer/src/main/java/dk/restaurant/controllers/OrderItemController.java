package dk.restaurant.controllers;

import dk.restaurant.models.OrderItem;
import dk.restaurant.network.IClientFactory;
import dk.restaurant.network.IOrderItemsClient;
import dk.restaurant.services.IOrderItemsService;
import dk.restaurant.services.IServiceFactory;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class OrderItemController
{
    private IOrderItemsService service;

    public OrderItemController(IServiceFactory serviceFactory)
    {
        this.service = serviceFactory.getOrderItemsService();
    }

    @GetMapping("/orderItems/{id}")
    @ResponseBody
    public List<OrderItem> getOrdersItems(@PathVariable("id") long orderId)
    {

        return service.getOrderItems(orderId);
    }

    @PostMapping("/orderItems")
    @ResponseStatus(HttpStatus.CREATED)
    public OrderItem createOrderItem(@RequestBody OrderItem orderItem)
    {
        return service.createOrderItem(orderItem);
    }

    @DeleteMapping(value = "/orderItems/{id}")
    public ResponseEntity<Long> deletePost(@PathVariable Long id) {
        try {
             service.deleteOrderItem(id);
            return new ResponseEntity<>(id, HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.NOT_FOUND);
        }


    }
}