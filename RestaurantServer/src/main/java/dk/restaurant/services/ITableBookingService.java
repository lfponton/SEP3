package dk.restaurant.services;

import dk.restaurant.models.TableBooking;

import java.util.Date;
import java.util.List;

public interface ITableBookingService {
    List<TableBooking> getTableBookings(String bookingDate);

    TableBooking updateTableBooking(TableBooking tableBooking);

    TableBooking createTableBooking(TableBooking tableBooking);
}
