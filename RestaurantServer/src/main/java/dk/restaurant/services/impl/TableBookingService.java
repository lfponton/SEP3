package dk.restaurant.services.impl;

import dk.restaurant.models.TableBooking;
import dk.restaurant.network.IClientFactory;
import dk.restaurant.network.ITableBookingsClient;
import dk.restaurant.services.ITableBookingService;

import java.util.List;

public class TableBookingService implements ITableBookingService {
    private ITableBookingsClient client;

    public TableBookingService(IClientFactory clientFactory) {
        this.client = clientFactory.getTableBookingsClient();
    }

    @Override
    public List<TableBooking> getTableBookings(String bookingDate) {
        return client.getTableBookings(bookingDate);
    }

    @Override
    public TableBooking updateTableBooking(TableBooking tableBooking) {
        return client.updateTableBooking(tableBooking);
    }

    @Override
    public TableBooking createTableBooking(TableBooking tableBooking) {
        return client.createTableBooking(tableBooking);
    }
}
