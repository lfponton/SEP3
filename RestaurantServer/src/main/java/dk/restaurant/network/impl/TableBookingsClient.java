package dk.restaurant.network.impl;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;
import dk.restaurant.models.Order;
import dk.restaurant.models.TableBooking;
import dk.restaurant.network.ITableBookingsClient;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class TableBookingsClient implements ITableBookingsClient {
    final String HOST = "localhost";
    final int PORT = 2001;
    private Socket socket;
    private PrintWriter out;
    private BufferedReader in;
    private Gson gson;

    public TableBookingsClient() {
        try {
            socket = new Socket(HOST, PORT);
            in = new BufferedReader(new InputStreamReader(socket.getInputStream()));
            out = new PrintWriter(socket.getOutputStream(), true);
            gson = new GsonBuilder().setDateFormat("yyyy-MM-dd'T'HH:mm:ss").create();
        } catch (
                IOException e) {
            e.printStackTrace();
        }
    }

    @Override
    public synchronized List<TableBooking> getTableBookings(String bookingDate) {
        List<TableBooking> bookings = new ArrayList<>();
        try
        {
            out.println("Bookings");
            out.println("getTableBookings");
            String send = gson.toJson(bookingDate);
            out.println(send);
            String response = in.readLine();
            System.out.println("Client response" + response);
            bookings = gson.fromJson(response, new TypeToken<ArrayList<TableBooking>>() {}.getType());
        }
        catch (IOException e)
        {
            e.printStackTrace();
        }
        System.out.println(bookings.size());
        return bookings;
    }

    @Override
    public synchronized TableBooking updateTableBooking(TableBooking tableBooking) {
        TableBooking booking = new TableBooking();
        try
        {
            out.println("Bookings");
            out.println("updateTableBooking");
            String send = gson.toJson(tableBooking);
            out.println(send);
            String response = in.readLine();
            booking = gson.fromJson(response, TableBooking.class);
        }
        catch (IOException e)
        {
            e.printStackTrace();
        }
        return booking;
    }

    @Override
    public synchronized TableBooking createTableBooking(TableBooking tableBooking) {
        TableBooking booking = new TableBooking();
        try
        {
            System.out.println("hello from client");

            out.println("Bookings");
            out.println("createTableBooking");
            String send = gson.toJson(tableBooking);
            System.out.println("client " + send);
            out.println(send);
            String response = in.readLine();
            System.out.println("response" + response);
            booking = gson.fromJson(response, TableBooking.class);
        }
        catch (IOException e)
        {
            e.printStackTrace();
        }
        return booking;
    }
}
