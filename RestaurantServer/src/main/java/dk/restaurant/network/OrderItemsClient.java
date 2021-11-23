package dk.restaurant.network;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import dk.restaurant.models.Menu;
import dk.restaurant.models.Order;
import dk.restaurant.models.OrderItem;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;

public class OrderItemsClient {
    final String HOST = "localhost";
    final int PORT = 2001;
    private Socket socket;
    private PrintWriter out;
    private BufferedReader in;
    private Gson gson;


    public OrderItemsClient() throws IOException {
        socket = new Socket(HOST, PORT);
        in = new BufferedReader(new InputStreamReader(socket.getInputStream()));
        out = new PrintWriter(socket.getOutputStream(), true);
        gson = new Gson();

    }

    public synchronized OrderItem createOrderItem(OrderItem orderItem) throws IOException {
        System.out.println("orderItemsClient-->" + orderItem.toString());
        out.println("createOrderItem");
        String send = gson.toJson(orderItem);
        out.println(send);
        String response = in.readLine();
        System.out.println("orderItemsClient response" + orderItem.toString());
        return gson.fromJson(response, OrderItem.class);
    }

    public synchronized List<OrderItem> getOrderItems(long orderId) throws IOException {
       List<OrderItem> orderItems;
        out.println("getOrderItems");
        String send = gson.toJson(orderId);
        out.println(send);
        String response = in.readLine();
        orderItems = gson.fromJson(response, new TypeToken<ArrayList<OrderItem>>() {}.getType());
        return orderItems;
    }

    public synchronized void deleteOrderItem(long orderItemId){
        out.println("deleteOrderItem");
        String send = gson.toJson(orderItemId);
        out.println(send);
    }
}
