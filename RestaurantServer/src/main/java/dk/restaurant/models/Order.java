package dk.restaurant.models;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.*;

public class Order implements Serializable
{
  private long orderId;
  private Date orderDate;
  private Date deliveryTime;
  private BigDecimal price;
  private Customer customer;
  private String status; // Not sure how to make the enums work with JSON and SQL
  private List<OrderItem> orderItems;
  private Address deliveryAddress;


  public Order() {
    this.price = new BigDecimal(0);
    setPrice();
  }

  public void setPrice()
  {
    if (orderItems != null)
    {
      for (OrderItem orderItem : orderItems)
      {
        price.add(orderItem.getPrice()) ;
      }
    }

  }
 /* public Order(long orderId, String status, Customer customer, List<Menu> menus,
      double price, Date orderDate, Date deliveryTime)
  {
    this.orderId = orderId;
    this.orderDate = orderDate;
    this.deliveryTime = deliveryTime;
    this.status = status;
    this.customer = customer;
    this.menus = new ArrayList<Menu>();
    this.price = price;
  }*/

  public long getOrderId()
  {
    return orderId;
  }

  public void setOrderId(long orderId)
  {
    this.orderId = orderId;
  }

  public BigDecimal getPrice()
  {
    return price;
  }

  public void setPrice(BigDecimal price)
  {
    this.price = price;
  }

  public Customer getCustomer()
  {
    return customer;
  }

  public void setCustomer(Customer customer)
  {
    this.customer= customer;
  }

 /* public List<OrderItem> getMenus()
  {
    return orderItems;
  }*/

  public Date getOrderDate()
  {
    return orderDate;
  }

  public void setOrderDate(Date orderDate)
  {
    this.orderDate = orderDate;
  }

  public Date getDeliveryTime()
  {
    return deliveryTime;
  }

  public void setDeliveryTime(Date deliveryTime)
  {
    this.deliveryTime = deliveryTime;
  }

 /* public void setMenus(List<OrderItem> orderItems)
  {
    this.orderItems = orderItems;
  }*/

  public String getStatus() {
    return this.status;
  }


  public void setStatus(String status) {
    this.status = status;
  }


  public Address getDeliveryAddress() {
    return deliveryAddress;
  }

  public void setDeliveryAddress(Address deliveryAddress) {
    this.deliveryAddress = deliveryAddress;
  }

  @Override public String toString()
  {
    return "Order{" + "order_id=" + orderId +
        ", status=" + status + ", customer=" + ", price=" + price + '}';
  }
}