package dk.restaurant.network.impl;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;
import dk.restaurant.models.Order;
import dk.restaurant.network.IOrdersClient;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;

public class OrdersClient implements IOrdersClient
{
  final String HOST = "localhost";
  final int PORT = 2001;
  private Socket socket;
  private PrintWriter out;
  private BufferedReader in;
  private Gson gson;

  public OrdersClient()
  {
    try
    {
      socket = new Socket(HOST, PORT);

      in = new BufferedReader(new InputStreamReader(socket.getInputStream()));
      out = new PrintWriter(socket.getOutputStream(), true);
      gson = new GsonBuilder().setDateFormat("yyyy-MM-dd'T'HH:mm:ssZ").create();
    }
    catch (IOException e)
    {
      e.printStackTrace();
    }
  }

  @Override public synchronized List<Order> getOrders()
  {
    List<Order> orders = new ArrayList<>();
    try
    {
      out.println("Orders");
      System.out.println("Sending Orders to DataServer");
      out.println("getOrders");
      System.out.println("Getting Orders from DataServer");
      out.println("");
      String response = in.readLine();
      orders = gson.fromJson(response, new TypeToken<ArrayList<Order>>()
      {
      }.getType());
    }
    catch (IOException e)
    {
      e.printStackTrace();
    }
    return orders;
  }

  @Override public synchronized Order createOrder(Order order)
  {
    String response = "";
    try
    {
      out.println("Orders");
      System.out.println("Sending Orders to DataServer");
      System.out.println("Creating Order");
      out.println("createOrder");
      String send = gson.toJson(order);
      out.println(send);
      response = in.readLine();
      System.out.println(response);
    }
    catch (Exception e)
    {
      e.printStackTrace();
    }
    return gson.fromJson(response, Order.class);
  }

}
