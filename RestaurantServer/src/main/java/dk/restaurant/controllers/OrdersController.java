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
public class OrdersController
{
  private IOrdersService service;

  public OrdersController(IServiceFactory serviceFactory)
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

  @GetMapping("/customer")
  public ResponseEntity<String> getCustomerOrders(@RequestParam(value="email") String email)
  {
    int numberOfOrders = service.getCustomerOrders(email);
    String response = Integer.toString(numberOfOrders);
    return new ResponseEntity<String>(response, HttpStatus.OK);
  }

  @PostMapping
  @ResponseStatus(HttpStatus.CREATED)
  public ResponseEntity<Order> createOrder(@RequestBody Order order)
      throws Exception
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