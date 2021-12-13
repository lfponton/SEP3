package dk.restaurant.models;

import java.math.BigDecimal;
import java.util.List;

public class Menu
{
  private int menuId;
  private String name;
  private String type;
  private BigDecimal price;
  private String description;
  private List<MenuItemsSelection> menuItemsSelections;
  private List<OrderItem> orderItems;

  public Menu()
  {
    this.price = new BigDecimal(0);
    setPrice();
  }

  public Menu(int menuId, BigDecimal price, String name, String type,
      String description, List<MenuItemsSelection> menuItemsSelections, List<OrderItem> orderItems)
  {
    this.menuId = menuId;
    this.menuItemsSelections = menuItemsSelections;
    this.orderItems = orderItems;
    this.description = description;
    this.price = price;
    this.name = name;
    this.type = type;
  }

  private void setPrice()
  {
    if (menuItemsSelections != null)
    {
      for (MenuItemsSelection menuItemsSelection : menuItemsSelections)
      {
        price.add(menuItemsSelection.getPrice());
      }
    }

  }

  public List<MenuItemsSelection> getMenuItemsSelections()
  {
    return menuItemsSelections;
  }

  public void setMenuItemsSelections(List<MenuItemsSelection> menuItemsSelections)
  {
    this.menuItemsSelections = menuItemsSelections;
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
