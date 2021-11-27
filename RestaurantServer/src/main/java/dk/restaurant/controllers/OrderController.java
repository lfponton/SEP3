package dk.restaurant.controllers;

import dk.restaurant.models.Order;
import dk.restaurant.network.IClient;
import dk.restaurant.network.IOrdersClient;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class OrderController
{
  private IOrdersClient client;

  public OrderController(IClient client)
  {
    this.client = client.getOrdersClient();
  }

  @GetMapping("/orders")
  public List<Order> getOrders()
  {
    return client.getOrders();
  }

  @GetMapping("/orders/{orderId}")
  public Order getOrder(@PathVariable long orderId)
  {
    return client.getOrder(orderId);
  }

  @PostMapping("/orders")
  @ResponseStatus(HttpStatus.CREATED)
  public Order createOrder(@RequestBody Order order)
  {
    return client.createOrder(order);
  }
}