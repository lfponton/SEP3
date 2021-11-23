package dk.restaurant.network;

import dk.restaurant.models.OrderItem;

import java.util.List;

public interface IOrderItemsClient
{
  OrderItem createOrderItem(OrderItem orderItem);
  List<OrderItem> getOrderItems(long orderId);
  void deleteOrderItem(long orderItemId);
}
