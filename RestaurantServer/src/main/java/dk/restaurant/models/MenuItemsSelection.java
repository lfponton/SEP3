package dk.restaurant.models;

import java.math.BigDecimal;

public class MenuItemsSelection
{
  public long menuId;
  public Menu menu;
  public long menuItemId;
  public MenuItem menuItem;
  public int quantity;
  public BigDecimal price;

  public MenuItemsSelection()
  {
    this.price = new BigDecimal(0);
  }

  public MenuItemsSelection(long menuId, Menu menu, long menuItemId,
      MenuItem menuItem, int quantity, BigDecimal price)
  {
    this.menuId = menuId;
    this.menu = menu;
    this.menuItemId = menuItemId;
    this.menuItem = menuItem;
    this.quantity = quantity;
    this.price = price;
  }

  public long getMenuId()
  {
    return menuId;
  }

  public void setMenuId(long menuId)
  {
    this.menuId = menuId;
  }

  public Menu getMenu()
  {
    return menu;
  }

  public void setMenu(Menu menu)
  {
    this.menu = menu;
  }

  public long getMenuItemId()
  {
    return menuItemId;
  }

  public void setMenuItemId(long menuItemId)
  {
    this.menuItemId = menuItemId;
  }

  public MenuItem getMenuItem()
  {
    return menuItem;
  }

  public void setMenuItem(MenuItem menuItem)
  {
    this.menuItem = menuItem;
  }

  public int getQuantity()
  {
    return quantity;
  }

  public void setQuantity(int quantity)
  {
    this.quantity = quantity;
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
