package dk.restaurant.models;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.*;

public class Order implements Serializable
{
  private long orderId;
  private Date orderDateTime;
  private Date deliveryTime;
  private BigDecimal price;
  private Customer customer;
  private String status;
  private List<OrderItem> orderItems;
  private DeliveryAddress deliveryAddress;
  private boolean isDelivery;

  public Order()
  {
    this.price = new BigDecimal(0);
    setPrice();
  }

  public void setPrice()
  {
    if (orderItems != null)
    {
      for (OrderItem orderItem : orderItems)
      {
        price.add(orderItem.getPrice());
      }
    }

  }

  public Order(long orderId, String status, Customer customer,
      List<OrderItem> orderItems, BigDecimal price, Date orderDateTime,
      Date deliveryTime, DeliveryAddress deliveryAddress, boolean isDelivery)
  {
    this.orderId = orderId;
    this.orderDateTime = orderDateTime;
    this.deliveryTime = deliveryTime;
    this.status = status;
    this.customer = customer;
    this.orderItems = orderItems;
    this.price = price;
    this.deliveryAddress = deliveryAddress;
    this.isDelivery = isDelivery;
  }

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
    this.customer = customer;
  }

  public Date getOrderDateTime()
  {
    return orderDateTime;
  }

  public void setOrderDateTime(Date orderDateTime)
  {
    this.orderDateTime = orderDateTime;
  }

  public Date getDeliveryTime()
  {
    return deliveryTime;
  }

  public void setDeliveryTime(Date deliveryTime)
  {
    this.deliveryTime = deliveryTime;
  }

  public List<OrderItem> getOrderItems()
  {
    return orderItems;
  }

  public void setOrderItems(List<OrderItem> orderItems)
  {
    this.orderItems = orderItems;
  }

  public boolean getIsDelivery()
  {
    return isDelivery;
  }

  public void setDelivery(boolean delivery)
  {
    isDelivery = delivery;
  }

  public String getStatus()
  {
    return this.status;
  }

  public void setStatus(String status)
  {
    this.status = status;
  }

  public DeliveryAddress getDeliveryAddress()
  {
    return deliveryAddress;
  }

  public void setDeliveryAddress(DeliveryAddress deliveryAddress)
  {
    this.deliveryAddress = deliveryAddress;
  }

  @Override public String toString()
  {
    return "Order{" + "order_id=" + orderId + ", status=" + status
        + ", customer=" + ", price=" + price + '}';
  }
}