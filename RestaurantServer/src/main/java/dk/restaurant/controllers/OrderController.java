package dk.restaurant.controllers;

import dk.restaurant.models.Order;
import dk.restaurant.models.TableBooking;
import dk.restaurant.network.IClientFactory;
import dk.restaurant.network.IOrdersClient;
import dk.restaurant.services.IOrdersService;
import dk.restaurant.services.IServiceFactory;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

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
  public Order getOrder(@PathVariable("orderId") long orderId)
  {
    return service.getOrder(orderId);
  }

  @GetMapping
  @RequestMapping(method = RequestMethod.GET)
  public List<Order> getOrders(@RequestParam(value="status", required = false) String status)
  {
    return service.getOrders(status);
  }

  @PostMapping("/orders")
  @ResponseStatus(HttpStatus.CREATED)
  public Order createOrder(@RequestBody Order order)
  {
    return service.createOrder(order);
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