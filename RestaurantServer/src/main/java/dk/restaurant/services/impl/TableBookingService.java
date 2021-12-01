package dk.restaurant.services.impl;

import dk.restaurant.models.TableBooking;
import dk.restaurant.network.IClient;
import dk.restaurant.network.ITableBookingsClient;
import dk.restaurant.services.ITableBookingService;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

public class TableBookingService implements ITableBookingService {
    private ITableBookingsClient client;

    public TableBookingService(IClient client) {
        this.client = client.getTableBookingsClient();
    }

    @Override
    public List<TableBooking> getTableBookings(String bookingDate) {
        return client.getTableBookings(bookingDate);
    }

    @Override
    public TableBooking updateTableBooking(TableBooking tableBooking) {
        return client.updateTableBooking(tableBooking);
    }
}
