package dk.restaurant.models;

import java.util.List;

public class Restaurant {
    private long restaurantId;
    //it sets the full house capacity every two hours
    private int capacity;
    private List<Table> tables;

    public Restaurant() {

    }

    public int getCapacity() {
        return capacity;
    }

    public void setCapacity(int capacity) {
        this.capacity = capacity;
    }

    public long getRestaurantId() {
        return restaurantId;
    }

    public void setRestaurantId(long restaurantId) {
        this.restaurantId = restaurantId;
    }

    public List<Table> getTables() {
        return tables;
    }

    public void setTables(List<Table> tables) {
        this.tables = tables;
    }
}
