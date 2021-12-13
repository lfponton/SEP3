package dk.restaurant.models;

import java.math.BigDecimal;
import java.util.List;

public class MenuItem
{
  private int menuItemId;
  private String name;
  private BigDecimal price;
  private List<MenuItemsSelection> menuItemsSelections;

  public MenuItem(int menuItemId, String name, BigDecimal price,
      List<MenuItemsSelection> menuItemsSelections)
  {
    this.menuItemId = menuItemId;
    this.name = name;
    this.price = price;
    this.menuItemsSelections = menuItemsSelections;
  }

  public MenuItem()
  {
  }

  public int getMenuItemId()
  {
    return menuItemId;
  }

  public void setMenuItemId(int menuItemId)
  {
    this.menuItemId = menuItemId;
  }

  public String getName()
  {
    return name;
  }

  public void setName(String name)
  {
    this.name = name;
  }

  public List<MenuItemsSelection> getMenuItemsSelections()
  {
    return menuItemsSelections;
  }

  public void setMenuItemsSelections(
      List<MenuItemsSelection> menuItemsSelections)
  {
    this.menuItemsSelections = menuItemsSelections;
  }

  public BigDecimal getPrice()
  {
    return price;
  }

  public void setPrice(BigDecimal price)
  {
    this.price = price;
  }

  @Override
  public String toString() {
    return "MenuItem{" +
            "name='" + name + '\'' +
            '}';
  }
}

