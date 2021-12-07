package dk.restaurant.models;

import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.databind.annotation.JsonDeserialize;



import javax.persistence.Column;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import java.time.LocalDate;
import java.time.LocalDateTime;
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

    public TableBooking() {

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

    public long getTableBookingId() {
        return tableBookingId;
    }

    public void setTableBookingId(long tableBookingId) {
        this.tableBookingId = tableBookingId;
    }

    public Table getTable() {
        return table;
    }

    public void setTable(Table table) {
        this.table = table;
    }

    public Customer getCustomer() {
        return customer;
    }

    public void setCustomer(Customer customer) {
        this.customer = customer;
    }

    public Date getBookingDateTime() {
        return bookingDateTime;
    }

    public void setBookingDateTime(Date bookingDateTime) {
        this.bookingDateTime = bookingDateTime;
    }

    public int getPeople() {
        return people;
    }

    public void setPeople(int people) {
        this.people = people;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }
}
