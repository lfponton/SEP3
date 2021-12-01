package dk.restaurant.controllers;

import dk.restaurant.models.TableBooking;
import dk.restaurant.network.IClient;
import dk.restaurant.network.ITableBookingsClient;
import dk.restaurant.services.ITableBookingService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.Date;
import java.util.List;

@RestController
public class TableBookingsController {
    private ITableBookingService service;


    public TableBookingsController(ITableBookingService service) {
        this.service = service;
    }

    @GetMapping("/tableBookings")

    public List<TableBooking> getTableBookings(@RequestParam(required = false) String bookingDate) {
        System.out.println(bookingDate);
        return service.getTableBookings(bookingDate);
    }
}
