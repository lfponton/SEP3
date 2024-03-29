package dk.restaurant.network.impl;

import com.google.gson.*;
import com.google.gson.reflect.TypeToken;
import dk.restaurant.models.TableBooking;
import dk.restaurant.network.ITableBookingsClient;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.lang.reflect.Type;
import java.net.Socket;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
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
    public synchronized List<TableBooking> getTableBookings(Date bookingDate) {
        List<TableBooking> bookings = new ArrayList<>();
        try
        {
            out.println("Bookings");
            out.println("getTableBookings");
            String send = gson.toJson(bookingDate);
            out.println(send);
            String response = in.readLine();
            bookings = gson.fromJson(response, new TypeToken<ArrayList<TableBooking>>() {}.getType());

        }
        catch (IOException e)
        {
            e.printStackTrace();
        }return bookings;
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
            out.println("Bookings");
            out.println("createTableBooking");
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
    public synchronized TableBooking getBookingById(Long tableBookingId) {
        TableBooking booking = new TableBooking();
        try
        {
            out.println("Bookings");
            out.println("getBookingById");
            String send = gson.toJson(tableBookingId);
            out.println(send);
            String response = in.readLine();
            booking = gson.fromJson(response, TableBooking.class);
        }
        catch (IOException e)
        {
            e.printStackTrace();
        }return booking;
    }
}
