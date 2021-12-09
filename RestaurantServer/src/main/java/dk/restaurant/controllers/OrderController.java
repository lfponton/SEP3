package dk.restaurant.controllers;

import dk.restaurant.models.Order;
import dk.restaurant.services.IOrdersService;
import dk.restaurant.services.IServiceFactory;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import java.util.List;

@RestController
@RequestMapping("/orders")
public class OrderController
{
  private IOrdersService service;

  public OrderController(IServiceFactory serviceFactory)
  {
    this.service = serviceFactory.getOrdersService();
  }

  @GetMapping(value = "/{orderId}")
  public ResponseEntity<Order> getOrder(@PathVariable("orderId") long orderId)
  {
    Order order = service.getOrder(orderId);
    return new ResponseEntity<Order>(order, HttpStatus.OK);
  }

  @GetMapping
  @RequestMapping(method = RequestMethod.GET)
  public ResponseEntity<List<Order>> getOrders(@RequestParam(value="status", required = false) String status)
  {
    List<Order> orders = service.getOrders(status);
    return new ResponseEntity<List<Order>>(orders, HttpStatus.OK);
  }

  @PostMapping
  @ResponseStatus(HttpStatus.CREATED)
  public ResponseEntity<Order> createOrder(@RequestBody Order order) throws Exception
  {
    Order newOrder = service.createOrder(order);
    return new ResponseEntity<Order>(newOrder, HttpStatus.OK);
  }

  @PatchMapping
  public ResponseEntity<Order> updateOrder(@RequestBody Order order)
  {
    Order updatedOrder = service.updateOrder(order);
    if (updatedOrder == null)
    {
      return ResponseEntity.badRequest().build();
    }
    return new ResponseEntity<Order>(updatedOrder, HttpStatus.OK);
  }
}