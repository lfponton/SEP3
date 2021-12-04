package dk.restaurant.models;

import java.math.BigDecimal;

public class OrderItem {

    private long orderId;
    private Order order;
    private long menuId;
    private Menu menu;
    private int quantity;
    private BigDecimal price;

  public OrderItem()
  {
      this.price = new BigDecimal(0);
      //setPrice();
  }

  public OrderItem(long orderId, Order order, long menuId, Menu menu,
      int quantity, BigDecimal price)
  {
    this.orderId = orderId;
    this.order = order;
    this.menuId = menuId;
    this.menu = menu;
    this.quantity = quantity;
    this.price = price;
  }

//For testing

    public BigDecimal getPrice() {
        return price;
    }

    public void setPrice(BigDecimal price) {
        this.price = price;
    }

    public long getOrderId() {
        return orderId;
    }

    public Order getOrder() {
        return order;
    }

    public long getMenuId() {
        return menuId;
    }

  public void setMenuId(long menuId)
  {
    this.menuId = menuId;
  }

  public void setOrderId(long orderId)
  {
    this.orderId = orderId;
  }

  public void setOrder(Order order)
  {
    this.order = order;
  }

  public Menu getMenu()
  {
    return menu;
  }

  public void setMenu(Menu menu)
  {
    this.menu = menu;
  }

  public void setQuantity(int quantity)
  {
    this.quantity = quantity;
  }

  public int getQuantity() {
        return quantity;
    }

    //testing

    @Override
    public String toString() {
        return "OrderItem{" +
                ", quantity=" + quantity +
                ", price=" + price +
                '}';
    }
}
