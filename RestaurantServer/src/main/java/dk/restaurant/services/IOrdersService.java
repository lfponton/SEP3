package dk.restaurant.services;

import dk.restaurant.models.Order;

import java.util.List;

public interface IOrdersService
{
  List<Order> getOrders();
  Order createOrder(Order order);
  Order getOrder(long orderId);
}
