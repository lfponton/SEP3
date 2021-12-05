package dk.restaurant.models;

import java.util.Date;

public class Restaurant {
    //it sets the full house capacity every two hours
    private int capacity;

    public Restaurant() {
        this.capacity = 200;
    }

    public int getCapacity() {
        return capacity;
    }

    public void setCapacity(int capacity) {
        this.capacity = capacity;
    }
}
