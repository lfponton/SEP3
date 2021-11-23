package dk.restaurant.network;

import dk.restaurant.models.Order;

import java.util.List;

public interface IOrdersClient
{
  List<Order> getOrders();
  Order createOrder(Order order);
}
