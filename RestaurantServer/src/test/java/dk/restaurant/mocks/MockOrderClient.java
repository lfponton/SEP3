package dk.restaurant.mocks;

import dk.restaurant.models.*;
import dk.restaurant.network.IOrdersClient;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class MockOrderClient implements IOrdersClient
{
  private List<Order> orders;
  private int numberOfCustomersOrders;

  public MockOrderClient()
  {
  }

  public void seed() {
    // Customer
    Customer customer = new Customer(1, "jan@doe.com", "Doe", "Jan", "1234");
    // Price
    BigDecimal price = new BigDecimal("100");
    // Selections
    List<MenuItemsSelection> selections = new ArrayList<>();
    // Order Items
    List<OrderItem> orderItems = new ArrayList<>();
    // MenuItem
    MenuItem menuItem = new MenuItem(1, "Item1", price, selections);
    // Menu
    Menu menu = new Menu(1, price, "Menu 1", "regular", "Menu description", selections, orderItems);
    // Selection
    MenuItemsSelection selection = new MenuItemsSelection(1, menu, 1, menuItem, 1, price);
    // Add selection to selections
    selections.add(selection);
    // Order  and Delivery dates
    Date orderDate = new Date();
    Date deliveryDate = new Date();
    // Set selections in Menus and MenuItems
    menu.setMenuItemsSelections(selections);
    menuItem.setMenuItemsSelections(selections);
    // Delivery address
    DeliveryAddress deliveryAddress = new DeliveryAddress(1, "Horsens", "Gade", "8700", "6", "tv.");
    // Order
    Order order1 = new Order(1, "pending", customer, orderItems, price, orderDate, deliveryDate, deliveryAddress, true);
    Order order2 = new Order(2, "confirmed", customer, orderItems, price, orderDate, deliveryDate, deliveryAddress, true);
    Order order3 = new Order(3, "completed", customer, orderItems, price, orderDate, deliveryDate, deliveryAddress, true);
    // Order items
    List<Order> orders = new ArrayList<>();
    // Order item
    //OrderItem orderItem = new OrderItem(1, order, 1, menu, 1, price);
    // Add order item
    //orderItems.add(orderItem);
    // Set order items
    order1.setOrderItems(orderItems);
    order2.setOrderItems(orderItems);
    order3.setOrderItems(orderItems);
    // Orders list
    orders.add(order1);
    orders.add(order2);
    orders.add(order3);
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
