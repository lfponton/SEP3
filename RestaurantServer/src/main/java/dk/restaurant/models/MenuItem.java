package dk.restaurant.models;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.List;

public class MenuItem implements Serializable
{
  private int menuItemId;
  private String name;
  private BigDecimal price;
  private List<MenuItemsSelection> menusSelections;

  public MenuItem(int menuItemId, String name, BigDecimal price,
      List<MenuItemsSelection> menuItemsSelections)
  {
    this.menuItemId = menuItemId;
    this.name = name;
    this.price = price;
    this.menusSelections = menuItemsSelections;
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

  public List<MenuItemsSelection> getMenusSelections()
  {
    return menusSelections;
  }

  public void setMenusSelections(
      List<MenuItemsSelection> menusSelections)
  {
    this.menusSelections = menusSelections;
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

