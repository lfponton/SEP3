package dk.restaurant.services.validation.impl;

import dk.restaurant.models.TableBooking;
import dk.restaurant.network.IClientFactory;
import dk.restaurant.services.validation.ITableBookingValidation;

import java.time.LocalDateTime;
import java.util.Date;
import java.util.List;

public class BookingValidation implements ITableBookingValidation {

    @Override
    public void bookingValidation(TableBooking tableBooking) {
        isValidPeople(tableBooking);

    }

    private boolean isValidPeople(TableBooking tableBooking) {
        if (tableBooking.getPeople() == 0 || tableBooking.getPeople() > 20) {
            throw new IllegalArgumentException("Only bookings from 1 to 20 people are accepted at the web site. For bigger events, please contact us");
        }
        LocalDateTime now = LocalDateTime.now();
        return true;
    }
}
