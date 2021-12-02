package dk.restaurant.models;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.Date;

public class TableBooking
{
  @JsonProperty("tableBookingId")
  private long tableBookingId;
  @JsonProperty("table")
  private Table table;
  @JsonProperty("customer")
  private Customer customer;
  @JsonProperty("bookingDateTime")
  private Date bookingDateTime;
  @JsonProperty("people")
  private int people;
  @JsonProperty("description")
  private String description;

 /* public TableBooking(long tableBookingId, Table table, Customer customer, Date bookingDateTime, int people,String description) {
    this.tableBookingId = tableBookingId;
    this.table = table;
    this.customer = customer;
    this.bookingDateTime = bookingDateTime;
    this.people = people;
    this.description = description;
  }*/
  public TableBooking()
  {
  }

    @Override
    public String toString() {
        return "TableBooking{" +
                "tableBookingId=" + tableBookingId +
                ", table=" + table +
                ", customer=" + customer +
                ", bookingDateTime=" + bookingDateTime +
                ", people=" + people +
                ", description='" + description + '\'' +
                '}';
    }
}
