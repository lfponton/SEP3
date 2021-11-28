package dk.restaurant.network.impl;

import com.google.gson.*;
import com.google.gson.reflect.TypeToken;
import dk.restaurant.models.OrderItem;
import dk.restaurant.network.IOrderItemsClient;

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

public class OrderItemsClient implements IOrderItemsClient
{
  final String HOST = "localhost";
  final int PORT = 2001;
  private Socket socket;
  private PrintWriter out;
  private BufferedReader in;
  private Gson gson;

  public OrderItemsClient()
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

  @Override public synchronized OrderItem createOrderItem(OrderItem orderItem)
  {
    String response = "";

    try
    {
      out.println("Orders");
      out.println("createOrderItem");
      String send = gson.toJson(orderItem);
      out.println(send);
      response = in.readLine();
      System.out.println("OrderItemControllerResponse->" + response);
    }
    catch (IOException e)
    {
      e.printStackTrace();
    }
    return gson.fromJson(response, OrderItem.class);
  }

  @Override public synchronized List<OrderItem> getOrderItems(long orderId)
  {
    List<OrderItem> orderItems = new ArrayList<>();
    try
    {
      out.println("Orders");
      out.println("getOrderItems");
      String send = gson.toJson(orderId);
      out.println(send);
      String response = in.readLine();
      System.out.println(response);
      orderItems = gson.fromJson(response, new TypeToken<ArrayList<OrderItem>>()
      {
      }.getType());
    }
    catch (IOException e)
    {
      e.printStackTrace();
    }
    return orderItems;
  }

  @Override public synchronized void deleteOrderItem(long orderItemId)
  {
    out.println("deleteOrderItem");
    String send = gson.toJson(orderItemId);
    out.println(send);
  }
}
