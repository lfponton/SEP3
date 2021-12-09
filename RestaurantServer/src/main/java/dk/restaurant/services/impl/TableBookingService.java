package dk.restaurant.services.impl;

import dk.restaurant.models.Restaurant;
import dk.restaurant.models.TableBooking;
import dk.restaurant.network.IClientFactory;
import dk.restaurant.network.ITableBookingsClient;
import dk.restaurant.services.ITableBookingService;
import org.springframework.stereotype.Service;

import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.Calendar;
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
        TableBooking tableBooking1 = tableBooking;

        try{
            validateBooking(tableBooking);
           tableBooking1= client.updateTableBooking(tableBooking);
        }
        catch (Exception e)
        {
            throw e;
        }
        return tableBooking1;

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
            isValidPeople(tableBooking);
            isThereCapacity(tableBooking);
            isCorrectDate(tableBooking);
        }
        catch (Exception e)
        {
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
        List<TableBooking> tableBookings = client.getTableBookings(tableBooking.getBookingDateTime());
        int peopleControl = 0;
        for (TableBooking tb : tableBookings) {
            if (tb.getBookingDateTime().getTime() == tableBooking.getBookingDateTime().getTime())
            {
                peopleControl += tableBooking.getPeople();
            }
        }
        if (peopleControl > 0){
            if ((peopleControl + tableBooking.getPeople()) > restaurant.getCapacity())
            {
               throw new IllegalArgumentException("Sorry, we are fully booked at the required time. Try another time or date");
            }
        }
    }
    private boolean isCorrectDate(TableBooking tableBooking){
       Date dateControl = Calendar.getInstance().getTime();
        Calendar calendar = Calendar.getInstance();
        calendar.setTime(dateControl);
        calendar.add(Calendar.HOUR, 2);
        dateControl = calendar.getTime();

        if (tableBooking.getBookingDateTime().before(dateControl)){

            throw new IllegalArgumentException("Bookings need to be done at least 2 hs in advance and up to 365 days from now");
        }
        return true;
    }


}
