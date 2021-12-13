package dk.restaurant.mocks;

import dk.restaurant.models.*;
import dk.restaurant.network.IOrdersClient;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class MockOrderClient implements IOrdersClient
{
  private int numberOfCustomersOrders;

  public MockOrderClient()
  {
  }

  @Override public List<Order> getOrders(String status)
  {
    Customer customer = new Customer(1, "jan@doe.com", "Doe", "Jan", "1234");
    List<Order> pendingOrders = new ArrayList<>();
    List<OrderItem> orderItems = new ArrayList<>();
    BigDecimal price = new BigDecimal("100");
    Date orderDate = new Date();
    Date deliveryDate = new Date();
    DeliveryAddress deliveryAddress = new DeliveryAddress(1, "Horsens", "Gade", "8700", "6", "tv.");
    Order order1 = new Order(1, "pending", customer, orderItems, price, orderDate, deliveryDate, deliveryAddress, true);
    pendingOrders.add(order1);
    return pendingOrders;
  }

  @Override public Order createOrder(Order order)
  {
    return order;
  }

  @Override public Order getOrder(long orderId)
  {
    Order order = new Order();
    return order;
  }

  @Override public Order updateOrder(Order order)
  {
    return order;
  }

  @Override public int getCustomerOrders(String email)
  {
    return numberOfCustomersOrders;
  }

  public void setNumberOfCustomersOrders(int numberOfCustomersOrders)
  {
    this.numberOfCustomersOrders = numberOfCustomersOrders;
  }
}
