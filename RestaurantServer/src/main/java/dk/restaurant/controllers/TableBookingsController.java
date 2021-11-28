package dk.restaurant.controllers;

import dk.restaurant.models.TableBooking;
import dk.restaurant.network.IClient;
import dk.restaurant.network.ITableBookingsClient;
import dk.restaurant.services.ITableBookingService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import java.util.Date;
import java.util.List;

@RestController
public class TableBookingsController {
    private ITableBookingService service;


    public TableBookingsController(ITableBookingService service) {
        this.service = service;
    }

    @GetMapping("/tableBookings/{datetime}/{people}")
    @ResponseBody
    public List<TableBooking> getTableBookings(@PathVariable("datetime") Date bookingDate,
                                               @PathVariable("people") int people) {
        return service.getTableBookings(bookingDate, people);
    }
}
