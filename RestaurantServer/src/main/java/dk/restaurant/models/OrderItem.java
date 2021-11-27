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

    public OrderItem(Order order, Menu menu, int quantity) {
      this.order = order;
      this.menu = menu;
      this.quantity = quantity;
     // setPrice();
    }

//    private void setPrice()
//  {
//      this.price = .multiply(new BigDecimal(quantity));
//  }
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

    public Menu getMenuId() {
        return menu;
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
