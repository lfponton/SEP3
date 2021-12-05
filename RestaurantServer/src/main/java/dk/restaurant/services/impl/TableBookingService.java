package dk.restaurant.services.impl;

import dk.restaurant.models.Restaurant;
import dk.restaurant.models.TableBooking;
import dk.restaurant.network.IClientFactory;
import dk.restaurant.network.ITableBookingsClient;
import dk.restaurant.services.ITableBookingService;

import java.time.LocalDateTime;
import java.util.Date;
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
        if (tableBooking == null){
            throw new IllegalArgumentException("The request can not be empty");
        }
        else validateBooking(tableBooking);
        return client.createTableBooking(tableBooking);
    }

    @Override
    public TableBooking getBookingById(Long tableBookingId) {
        return client.getBookingById(tableBookingId);
    }

    //this should be a separated class to test without running anything else

    public void validateBooking(TableBooking tableBooking) {
        isValidPeople(tableBooking);
        isThereCapacity(tableBooking);
        isCorrectDate(tableBooking);
    }

    private boolean isValidPeople(TableBooking tableBooking) {
        if (tableBooking.getPeople() == 0 || tableBooking.getPeople() > 20) {
            throw new IllegalArgumentException("Only bookings from 1 to 20 people are accepted at the web site. For bigger events, please contact us");
        }
            return true;
    }
    private boolean isThereCapacity(TableBooking tableBooking)
    {
        Restaurant restaurant = new Restaurant();
        List<TableBooking> tableBookings = client.getTableBookings(tableBooking.getBookingDateTime().toString());
        int peopleControl = 0;
        for (TableBooking tb : tableBookings) {
            peopleControl += tableBooking.getPeople();
        }
        if ((peopleControl + tableBooking.getPeople()) > restaurant.getCapacity())
        {
            throw new IllegalArgumentException("Sorry, try with a different time or date");
        }
        return true;
    }
    private boolean isCorrectDate(TableBooking tableBooking){
        LocalDateTime now = LocalDateTime.now();
        LocalDateTime max = now.plusDays(365);

        if (!tableBooking.getBookingDateTime().equals(now) || !tableBooking.getBookingDateTime().isAfter(now) ||
                !tableBooking.getBookingDateTime().isAfter(now) || tableBooking.getBookingDateTime().isAfter(max) ){
            throw new IllegalArgumentException("The date must be between today and 365 days after");
        }
        return true;
    }


}
