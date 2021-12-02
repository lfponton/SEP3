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

  @Override public List<Order> getOrders()
  {
    return client.getOrders();
  }

  @Override public Order createOrder(Order order)
  {
    return client.createOrder(order);
  }

  @Override public Order getOrder(long orderId)
  {
    return client.getOrder(orderId);
  }
}
