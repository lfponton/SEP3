package dk.restaurant;

import dk.restaurant.mocks.MockClientFactory;
import dk.restaurant.mocks.MockOrdersClient;
import dk.restaurant.models.Customer;
import dk.restaurant.models.Order;
import dk.restaurant.models.OrderItem;
import dk.restaurant.services.IOrdersService;
import dk.restaurant.services.impl.OrdersService;
import org.junit.Before;
import org.junit.Test;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertThrows;

public class OrdersServiceTest
{
  private MockClientFactory clientFactory;
  private MockOrdersClient orderClient;
  private IOrdersService ordersService;

  @Before
  public void setUp() {
    clientFactory = new MockClientFactory();
    orderClient = clientFactory.getOrdersClient();
    ordersService = new OrdersService(clientFactory);
  }

  @Test
  public void getOrdersReturnsPendingOrders() {
    List<Order> orders = ordersService.getOrders("pending");
    assertEquals("pending", orders.get(0).getStatus());
  }

  @Test
  public void customerCreatingOrderWith10ConfirmedOrdersGet50PercentDiscount()
      throws Exception
  {
    orderClient.setNumberOfCustomersOrders(10);
    Customer customer = new Customer(1, "jan@doe.com", "Doe", "Jan", "1234");
    List<OrderItem> orderItems = new ArrayList<>();
    BigDecimal price = new BigDecimal("100");
    Order order = new Order(1, "pending", customer, orderItems, price, new Date(), new Date(), null, false);
    Order createdOrder = ordersService.createOrder(order);
    assertEquals("50.0", createdOrder.getPrice().toString());
  }

  @Test
  public void customerCreatingOrderWithLessThan10ConfirmedOrdersGetsNoDiscount()
      throws Exception
  {
    orderClient.setNumberOfCustomersOrders(9);
    Customer customer = new Customer(1, "jan@doe.com", "Doe", "Jan", "1234");
    List<OrderItem> orderItems = new ArrayList<>();
    BigDecimal price = new BigDecimal("100");
    Order order = new Order(1, "pending", customer, orderItems, price, new Date(), new Date(), null, false);
    Order createdOrder = ordersService.createOrder(order);
    assertEquals("100", createdOrder.getPrice().toString());
  }

  @Test
  public void customerCreatingOrderWithMoreThan10ConfirmedOrdersGetsNoDiscount()
      throws Exception
  {
    orderClient.setNumberOfCustomersOrders(11);
    Customer customer = new Customer(1, "jan@doe.com", "Doe", "Jan", "1234");
    List<OrderItem> orderItems = new ArrayList<>();
    BigDecimal price = new BigDecimal("100");
    Order order = new Order(1, "pending", customer, orderItems, price, new Date(), new Date(), null, false);
    Order createdOrder = ordersService.createOrder(order);
    assertEquals("100", createdOrder.getPrice().toString());
  }

  @Test
  public void customerCreatingOrderWithZeroConfirmedOrdersGetsNoDiscount()
      throws Exception
  {
    orderClient.setNumberOfCustomersOrders(0);
    Customer customer = new Customer(1, "jan@doe.com", "Doe", "Jan", "1234");
    List<OrderItem> orderItems = new ArrayList<>();
    BigDecimal price = new BigDecimal("100");
    Order order = new Order(1, "pending", customer, orderItems, price, new Date(), new Date(), null, false);
    Order createdOrder = ordersService.createOrder(order);
    assertEquals("100", createdOrder.getPrice().toString());
  }

  @Test
  public void CreatingOrderWithPriceAbove1000AndStatusPendingGetsNoDiscount() throws Exception
  {
    Customer customer = new Customer(1, "jan@doe.com", "Doe", "Jan", "1234");
    List<OrderItem> orderItems = new ArrayList<>();
    BigDecimal price = new BigDecimal("2000");
    Order order = new Order(1, "pending", customer, orderItems, price, new Date(), new Date(), null, false);
    Order createdOrder = ordersService.createOrder(order);
    assertEquals("2000", createdOrder.getPrice().toString());
  }

  @Test
  public void CreatingOrderWithPriceAbove1000ButStatusOrderingGets10PercentDiscount() throws Exception
  {
    Customer customer = new Customer(1, "jan@doe.com", "Doe", "Jan", "1234");
    List<OrderItem> orderItems = new ArrayList<>();
    BigDecimal price = new BigDecimal("2000");
    Order order = new Order(1, "ordering", customer, orderItems, price, new Date(), new Date(), null, false);
    Order createdOrder = ordersService.createOrder(order);
    assertEquals("1800.0", createdOrder.getPrice().toString());
  }

  @Test
  public void CreatingOrderWithPriceBelow1000AndStatusOrderingGetsNoDiscount() throws Exception
  {
    Customer customer = new Customer(1, "jan@doe.com", "Doe", "Jan", "1234");
    List<OrderItem> orderItems = new ArrayList<>();
    BigDecimal price = new BigDecimal("500");
    Order order = new Order(1, "pending", customer, orderItems, price, new Date(), new Date(), null, false);
    Order createdOrder = ordersService.createOrder(order);
    assertEquals("500", createdOrder.getPrice().toString());
  }

  @Test
  public void CreatingOrderWithPrice1000AndStatusOrderingGetsNoDiscount() throws Exception
  {
    Customer customer = new Customer(1, "jan@doe.com", "Doe", "Jan", "1234");
    List<OrderItem> orderItems = new ArrayList<>();
    BigDecimal price = new BigDecimal("1000");
    Order order = new Order(1, "pending", customer, orderItems, price, new Date(), new Date(), null, false);
    Order createdOrder = ordersService.createOrder(order);
    assertEquals("1000", createdOrder.getPrice().toString());
  }

  @Test
  public void CreatingOrderWithMoreThanTwentyMenusThrowsException() throws Exception
  {
    Customer customer = new Customer(1, "jan@doe.com", "Doe", "Jan", "1234");
    List<OrderItem> orderItems = new ArrayList<>();
    BigDecimal price = new BigDecimal("1000");
    OrderItem orderItem = new OrderItem();
    orderItem.setQuantity(21);
    orderItems.add(orderItem);
    Order order = new Order(1, "pending", customer, orderItems, price, new Date(), new Date(), null, false);
    assertThrows(IllegalArgumentException.class, () -> ordersService.createOrder(order));
  }

  @Test
  public void CreatingOrderWithLessThanTwentyMenus() throws Exception
  {
    Customer customer = new Customer(1, "jan@doe.com", "Doe", "Jan", "1234");
    List<OrderItem> orderItems = new ArrayList<>();
    BigDecimal price = new BigDecimal("1000");
    OrderItem orderItem = new OrderItem();
    orderItem.setQuantity(19);
    orderItems.add(orderItem);
    Order order = new Order(1, "pending", customer, orderItems, price, new Date(), new Date(), null, false);
    Order createdOrder = ordersService.createOrder(order);
    int numberOfMenus = 0;
    for (OrderItem i : order.getOrderItems())
    {
      numberOfMenus = i.getQuantity();
    }
    assertEquals(19, numberOfMenus);
  }

  @Test
  public void CreatingOrderWithTwentyMenus() throws Exception
  {
    Customer customer = new Customer(1, "jan@doe.com", "Doe", "Jan", "1234");
    List<OrderItem> orderItems = new ArrayList<>();
    BigDecimal price = new BigDecimal("1000");
    OrderItem orderItem = new OrderItem();
    orderItem.setQuantity(20);
    orderItems.add(orderItem);
    Order order = new Order(1, "pending", customer, orderItems, price, new Date(), new Date(), null, false);
    Order createdOrder = ordersService.createOrder(order);
    int numberOfMenus = 0;
    for (OrderItem i : order.getOrderItems())
    {
      numberOfMenus = i.getQuantity();
    }
    assertEquals(20, numberOfMenus);
  }
}
