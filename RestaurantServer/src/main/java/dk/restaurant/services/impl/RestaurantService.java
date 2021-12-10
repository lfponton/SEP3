package dk.restaurant.services.impl;

import dk.restaurant.models.Restaurant;
import dk.restaurant.network.IClientFactory;
import dk.restaurant.network.IRestaurantClient;
import dk.restaurant.services.IRestaurantService;

public class RestaurantService implements IRestaurantService {

    private IRestaurantClient client;

    public RestaurantService(IClientFactory clientFactory) {
        this.client = clientFactory.getRestaurantClient();
    }

    @Override
    public Restaurant getRestaurant() {
        System.out.println("here service");
        return client.getRestaurant() ;
    }
}
