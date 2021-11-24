package dk.restaurant.models;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;

public class MenuItem
{
  private int menuItemId;
  private String name;
  private BigDecimal price;
  private List<Menu> menus;

  public MenuItem(int menuItemId, String name, BigDecimal price,
      List<Menu> menus)
  {
    this.menuItemId = menuItemId;
    this.name = name;
    this.price = price;
    this.menus = menus;
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

  public List<Menu> getMenus()
  {
    return menus;
  }

  public void setMenus(List<Menu> menus)
  {
    this.menus = menus;
  }

  public BigDecimal getPrice()
  {
    return price;
  }

  public void setPrice(BigDecimal price)
  {
    this.price = price;
  }
}
