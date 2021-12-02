package dk.restaurant.controllers;

import dk.restaurant.models.Order;
import dk.restaurant.network.IClientFactory;
import dk.restaurant.network.IOrdersClient;
import dk.restaurant.services.IOrdersService;
import dk.restaurant.services.IServiceFactory;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class OrderController
{
  private IOrdersService service;

  public OrderController(IServiceFactory serviceFactory)
  {
    this.service = serviceFactory.getOrdersService();
  }

  @GetMapping("/orders")
  public List<Order> getOrders()
  {
    return service.getOrders();
  }

  @GetMapping("/orders/{orderId}")
  public Order getOrder(@PathVariable long orderId)
  {
    return service.getOrder(orderId);
  }

  @PostMapping("/orders")
  @ResponseStatus(HttpStatus.CREATED)
  public Order createOrder(@RequestBody Order order)
  {
    return service.createOrder(order);
  }
}