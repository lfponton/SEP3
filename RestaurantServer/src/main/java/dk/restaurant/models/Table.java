package dk.restaurant.models;

import java.util.List;

public class Table
{
  private int tableId;
  private int capacity;
  private List<TableBooking> tableBookings;
  public Table(int tableId, int capacity, List<TableBooking> tableBookings)
  {
    this.tableId = tableId;
    this.capacity = capacity;
    this.tableBookings = tableBookings;
  }

  public Table() {}

  public int getTableId()
  {
    return tableId;
  }

  public void setTableId(int tableId)
  {
    this.tableId = tableId;
  }

  public int getCapacity()
  {
    return capacity;
  }

  public void setCapacity(int capacity)
  {
    this.capacity = capacity;
  }

  public List<TableBooking> getTableBookings() {
    return tableBookings;
  }

  public void setTableBookings(List<TableBooking> tableBookings) {
    this.tableBookings = tableBookings;
  }
}
