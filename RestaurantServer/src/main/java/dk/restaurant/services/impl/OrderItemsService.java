package dk.restaurant.services.impl;

import dk.restaurant.models.OrderItem;
import dk.restaurant.network.IClientFactory;
import dk.restaurant.network.IOrderItemsClient;
import dk.restaurant.services.IOrderItemsService;

import java.util.List;

public class OrderItemsService implements IOrderItemsService
{
  private IOrderItemsClient client;

  public OrderItemsService(IClientFactory clientFactory) {
    this.client = clientFactory.getOrderItemsClient();
  }

  @Override public OrderItem createOrderItem(OrderItem orderItem)
  {
    return client.createOrderItem(orderItem);
  }

  @Override public List<OrderItem> getOrderItems(long orderId)
  {
    return client.getOrderItems(orderId);
  }

  @Override public void deleteOrderItem(long orderItemId)
  {
    client.deleteOrderItem(orderItemId);
  }
}
