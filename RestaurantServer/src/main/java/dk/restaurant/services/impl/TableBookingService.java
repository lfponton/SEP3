package dk.restaurant.services.impl;

import dk.restaurant.models.TableBooking;
import dk.restaurant.network.IClient;
import dk.restaurant.network.ITableBookingsClient;
import dk.restaurant.services.ITableBookingService;

import java.util.Date;
import java.util.List;

public class TableBookingService implements ITableBookingService {
    private ITableBookingsClient client;

    public TableBookingService(IClient client) {
        this.client = client.getTableBookingsClient();
    }

    @Override
    public List<TableBooking> getTableBookings(Date bookingDate, int people) {
        return client.getTableBookings(bookingDate);
    }
}
