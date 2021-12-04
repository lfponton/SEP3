package dk.restaurant.network.impl;

import com.google.gson.*;
import com.google.gson.reflect.TypeToken;
import dk.restaurant.models.Order;
import dk.restaurant.network.IOrdersClient;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.lang.reflect.Type;
import java.net.Socket;
import java.time.Instant;
import java.time.LocalDateTime;
import java.time.ZoneId;
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
      gson = new GsonBuilder().setDateFormat("yyyy-MM-dd'T'HH:mm:ss").create();
    }
    catch (IOException e)
    {
      e.printStackTrace();
    }
  }

  @Override public synchronized List<Order> getOrders(String status)
  {
    List<Order> orders = new ArrayList<>();
    try
    {
      out.println("Orders");
      out.println("getOrders");
      if (status == null)
      {
        out.println("");
      }
      else
      {
        out.println(status);
      }
      String response = in.readLine();
      orders = gson.fromJson(response, new TypeToken<ArrayList<Order>>() {}.getType());
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
      out.println("createOrder");
      String jsonOrder = gson.toJson(order);
      out.println(jsonOrder);
      response = in.readLine();
    }
    catch (Exception e)
    {
      e.printStackTrace();
    }
    return gson.fromJson(response, Order.class);
  }

  @Override public Order getOrder(long orderId)
  {
    String response = "";
    try
    {
      out.println("Orders");
      out.println("getOrder");
      out.println(orderId);
      response = in.readLine();
    }
    catch (Exception e)
    {
      e.printStackTrace();
    }
    return gson.fromJson(response, Order.class);
  }

  @Override public Order updateOrder(Order order)
  {
    String response = "";
    try
    {
      out.println("Orders");
      out.println("updateOrder");
      String jsonOrder = gson.toJson(order);
      out.println(jsonOrder);
      response = in.readLine();
    }
    catch (Exception e)
    {
      e.printStackTrace();
    }
    return gson.fromJson(response, Order.class);
  }

}
