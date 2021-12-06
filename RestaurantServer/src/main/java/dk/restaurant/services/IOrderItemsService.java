package dk.restaurant.services;

import dk.restaurant.models.OrderItem;

import java.util.List;

public interface IOrderItemsService
{
  OrderItem createOrderItem(OrderItem orderItem);
  List<OrderItem> getOrderItems(long orderId);
  void deleteOrderItem(OrderItem orderItem);
}
