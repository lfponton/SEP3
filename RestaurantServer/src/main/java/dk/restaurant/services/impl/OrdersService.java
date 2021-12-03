package dk.restaurant.services.impl;

import dk.restaurant.models.Order;
import dk.restaurant.network.IClientFactory;
import dk.restaurant.network.IOrdersClient;
import dk.restaurant.services.IOrdersService;

import java.util.List;

public class OrdersService implements IOrdersService
{
  private IOrdersClient client;

  public OrdersService(IClientFactory clientFactory) {
    this.client = clientFactory.getOrdersClient();
  }

  @Override public List<Order> getOrders(String status)
  {
    return client.getOrders(status);
  }

  @Override public Order createOrder(Order order)
  {
    return client.createOrder(order);
  }

  @Override public Order getOrder(long orderId)
  {
    return client.getOrder(orderId);
  }

  @Override public Order updateOrder(Order order)
  {
    return client.updateOrder(order);
  }
}
