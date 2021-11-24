package dk.restaurant.models;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;

public class Menu implements Serializable
{
  private int menuId;
  private String name;
  private String type;
  private BigDecimal price;
  private String description;
  private List<MenuItem> menuItems;
  private List<OrderItem> orderItems;

  public Menu()
  {
    this.price = new BigDecimal(0);
    setPrice();
  }

  public Menu(int menuId, BigDecimal price, String name, String type,
      String description, List<MenuItem> menuItems, List<OrderItem> orderItems)
  {
    this.menuId = menuId;
    this.menuItems = menuItems;
    this.orderItems = orderItems;
    this.description = description;
    this.price = price;
    this.name = name;
    this.type = type;
  }

  private void setPrice()
  {
    if (menuItems != null)
    {
      for (MenuItem menuItem : menuItems)
      {
        price.add(menuItem.getPrice());
      }
    }

  }

  public List<MenuItem> getMenuItems()
  {
    return menuItems;
  }

  public void setMenuItems(List<MenuItem> menuItems)
  {
    this.menuItems = menuItems;
  }

  public String getDescription()
  {
    return description;
  }

  public void setDescription(String description)
  {
    this.description = description;
  }

  public List<OrderItem> getOrderItems()
  {
    return orderItems;
  }

  public void setOrderItems(List<OrderItem> orderItems)
  {
    this.orderItems = orderItems;
  }

  public BigDecimal getPrice()
  {
    return price;
  }

  public void setPrice(BigDecimal price)
  {
    this.price = price;
  }

  public int getMenuId()
  {
    return menuId;
  }

  public void setMenuId(int menuId)
  {
    this.menuId = menuId;
  }

  public String getName()
  {
    return name;
  }

  public String getType()
  {
    return type;
  }

  public void setName(String name)
  {
    this.name = name;
  }

  public void setType(String type)
  {
    this.type = type;
  }
}
