package dk.restaurant.services;

import dk.restaurant.models.Order;

import java.util.List;

public interface IOrdersService
{
  List<Order> getOrders(String status);
  Order createOrder(Order order);
  Order getOrder(long orderId);
  Order updateOrder(Order order);
}
