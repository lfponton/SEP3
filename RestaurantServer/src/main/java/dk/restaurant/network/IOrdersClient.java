package dk.restaurant.network;

import dk.restaurant.models.Order;

import java.util.List;

public interface IOrdersClient
{
  List<Order> getOrders(String status);
  Order createOrder(Order order);
  Order getOrder(long orderId);
}
