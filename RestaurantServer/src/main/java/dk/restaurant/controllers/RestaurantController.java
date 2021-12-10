package dk.restaurant.controllers;

import dk.restaurant.models.Order;
import dk.restaurant.models.Restaurant;
import dk.restaurant.models.TableBooking;
import dk.restaurant.services.IRestaurantService;
import dk.restaurant.services.IServiceFactory;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/restaurant")
public class RestaurantController {
private IRestaurantService service;

    public RestaurantController(IServiceFactory serviceFactory)
    {
        this.service = serviceFactory.getRestaurantService();
    }
    @GetMapping
    @RequestMapping(method = RequestMethod.GET)
    public ResponseEntity<Restaurant> getRestaurant()
    {
        System.out.println("here");
        Restaurant restaurant = service.getRestaurant();
        return new ResponseEntity<Restaurant>(restaurant, HttpStatus.OK);
    }

}
