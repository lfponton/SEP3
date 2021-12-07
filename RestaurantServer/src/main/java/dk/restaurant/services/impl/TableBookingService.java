package dk.restaurant.services.impl;

import dk.restaurant.models.Restaurant;
import dk.restaurant.models.TableBooking;
import dk.restaurant.network.IClientFactory;
import dk.restaurant.network.ITableBookingsClient;
import dk.restaurant.services.ITableBookingService;
import org.springframework.stereotype.Service;

import java.util.Date;
import java.util.List;

public class TableBookingService implements ITableBookingService {
    private ITableBookingsClient client;

    public TableBookingService(IClientFactory clientFactory) {
        this.client = clientFactory.getTableBookingsClient();
    }

    @Override
    public List<TableBooking> getTableBookings(Date bookingDate) {
        return client.getTableBookings(bookingDate);
    }

    @Override
    public TableBooking updateTableBooking(TableBooking tableBooking) {
        return client.updateTableBooking(tableBooking);
    }

    @Override
    public TableBooking createTableBooking(TableBooking tableBooking){
        TableBooking tableBooking1 = tableBooking;

            try {
                validateBooking(tableBooking);
                tableBooking1 = client.createTableBooking(tableBooking);
            }
            catch (Exception e)
            {
                throw e;
            }

       return tableBooking1;
    }

    @Override
    public TableBooking getBookingById(Long tableBookingId) {
        return client.getBookingById(tableBookingId);
    }

    //this should be a separated class to test without running anything else

    public void validateBooking(TableBooking tableBooking) {
        try {
            //isValidPeople(tableBooking);
            isThereCapacity(tableBooking);
           // isCorrectDate(tableBooking);
        }
        catch (Exception e)
        {
            System.out.println(e.getStackTrace());
            throw e;
        }
    }

    private boolean isValidPeople(TableBooking tableBooking) {
        if (tableBooking.getPeople() < 1 || tableBooking.getPeople() > 20) {
            throw new IllegalArgumentException("Only bookings from 1 to 20 people are accepted at the web site. For bigger events, please contact us");
        }
            return true;
    }
    private void isThereCapacity(TableBooking tableBooking) throws IllegalArgumentException{
        Restaurant restaurant = new Restaurant();
        System.out.println(tableBooking.getBookingDateTime().toString());
        List<TableBooking> tableBookings = client.getTableBookings(tableBooking.getBookingDateTime());
        int peopleControl = 0;
        for (TableBooking tb : tableBookings) {
            peopleControl += tableBooking.getPeople();
        }
        if (peopleControl > 0){
            if ((peopleControl + tableBooking.getPeople()) > restaurant.getCapacity())
            {
               throw new IllegalArgumentException("Try another date");

            }
        }
    }
    private boolean isCorrectDate(TableBooking tableBooking){
     /*   Date now = Date.
        LocalDateTime max = now.plusDays(365);

        if (tableBooking.getBookingDateTime().before() || tableBooking.getBookingDateTime().isBefore(now)){
            throw new IllegalArgumentException("The date must be between today and 365 days after");
        }
        return true;*/
        return true;
    }


}
