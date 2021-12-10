package dk.restaurant.controllers;

import dk.restaurant.models.TableBooking;
import dk.restaurant.services.IServiceFactory;
import dk.restaurant.services.ITableBookingService;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.Date;
import java.util.List;
@RestController
public class TableBookingsController {
    private ITableBookingService service;


    public TableBookingsController(IServiceFactory serviceFactory) {
        this.service = serviceFactory.getTableBookingsService();
    }


    @PostMapping("/tableBookings")
    public ResponseEntity<TableBooking> createTableBooking(@RequestBody TableBooking tableBooking) throws Exception{
        TableBooking tableBooking1 = service.createTableBooking(tableBooking);
        return new ResponseEntity<TableBooking>(tableBooking1, HttpStatus.OK);
    }



    @GetMapping("/tableBookings")
    public ResponseEntity<List<TableBooking>> getTableBookings(@RequestParam(required = false) Date bookingDate) {
        List<TableBooking> tableBookings = service.getTableBookings(bookingDate);
        return new ResponseEntity<List<TableBooking>>(tableBookings, HttpStatus.OK);
    }
    @GetMapping("/tableBookings/{tableBookingId}")
    public ResponseEntity<TableBooking> getBookingById(@PathVariable("tableBookingId") Long tableBookingId)
    {
        TableBooking tableBooking1 = service.getBookingById(tableBookingId);
        return new ResponseEntity<TableBooking>(tableBooking1, HttpStatus.OK);
    }

    @PatchMapping("/tableBookings/{tableBookingId}")
    public ResponseEntity<TableBooking> updateTableBooking(@PathVariable("tableBookingId") Long tableBookingId, @RequestBody TableBooking tableBooking)
    {
        TableBooking tableBooking1 = service.updateTableBooking(tableBooking);
        return new ResponseEntity<TableBooking>(tableBooking1, HttpStatus.OK);
    }
}
