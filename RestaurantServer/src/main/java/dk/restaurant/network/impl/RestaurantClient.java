package dk.restaurant.network.impl;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import dk.restaurant.models.Order;
import dk.restaurant.models.Restaurant;
import dk.restaurant.network.IRestaurantClient;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;

public class RestaurantClient implements IRestaurantClient {
    final String HOST = "localhost";
    final int PORT = 2001;
    private Socket socket;
    private PrintWriter out;
    private BufferedReader in;
    private Gson gson;

    public RestaurantClient() {
        try
        {
            socket = new Socket(HOST, PORT);
            in = new BufferedReader(new InputStreamReader(socket.getInputStream()));
            out = new PrintWriter(socket.getOutputStream(), true);
            gson = new GsonBuilder().setDateFormat("yyyy-MM-dd'T'HH:mm:ss").create();
        }
        catch (IOException e)
        {
            e.printStackTrace();
        }
    }

    @Override
    public synchronized Restaurant getRestaurant() {
        String response = "";
        try
        {
            out.println("Restaurant");
            out.println("getRestaurant");
            response = in.readLine();
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
        return gson.fromJson(response, Restaurant.class);
    }
}
