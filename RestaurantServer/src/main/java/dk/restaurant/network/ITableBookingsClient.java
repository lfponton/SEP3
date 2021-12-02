package dk.restaurant.network;

import dk.restaurant.models.TableBooking;

import java.util.Date;
import java.util.List;

public interface ITableBookingsClient {
    List<TableBooking> getTableBookings(String bookingDate);

    TableBooking updateTableBooking(TableBooking tableBooking);

    TableBooking createTableBooking(TableBooking tableBooking);

    TableBooking getBookingById(Long tableBookingId);
}
