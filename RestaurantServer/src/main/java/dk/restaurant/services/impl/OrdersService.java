package dk.restaurant.services.impl;

import dk.restaurant.models.Order;
import dk.restaurant.models.OrderItem;
import dk.restaurant.network.IClientFactory;
import dk.restaurant.network.IOrdersClient;
import dk.restaurant.services.IOrdersService;

import java.math.BigDecimal;
import java.util.List;

public class OrdersService implements IOrdersService
{
  private IOrdersClient client;
  private BigDecimal discount;

  public OrdersService(IClientFactory clientFactory) {
    this.client = clientFactory.getOrdersClient();
    discount = new BigDecimal("0.9");
  }

  @Override public List<Order> getOrders(String status)
  {
    return client.getOrders(status);
  }

  @Override public Order createOrder(Order order)
  {
    Order newOrder = new Order();
    checkForOrderPriceDiscount(order);
    try {
      newOrder = client.createOrder(order);
      checkMenusAmount(newOrder);
    }
    catch (Exception e) {
      throw e;
    }
    return newOrder;
  }

  private void checkForOrderPriceDiscount(Order newOrder)
  {
    if (newOrder.getStatus().equals("ordering") &&
        newOrder.getPrice().compareTo(new BigDecimal(1000)) > 0)
    {
      BigDecimal discountedPrice = newOrder.getPrice().multiply(discount);
      newOrder.setPrice(discountedPrice);
    }
  }

  private void checkMenusAmount(Order newOrder)
  {
    try
    {
      int menusAmount = 0;
      for (OrderItem item : newOrder.getOrderItems())
      {
        menusAmount += item.getQuantity();
      }

      if (menusAmount > 20)
      {
        throw new IllegalArgumentException("The number of menus exceeds 20. Unfortunately, we cannot fulfill your request. Please, contact us for more information");
      }
    } catch (Exception e) {throw e;}
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
