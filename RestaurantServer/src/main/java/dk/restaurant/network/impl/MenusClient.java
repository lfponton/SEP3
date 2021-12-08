package dk.restaurant.network.impl;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;
import dk.restaurant.models.Menu;
import dk.restaurant.models.Order;
import dk.restaurant.network.IMenusClient;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;

public class MenusClient implements IMenusClient
{

  final String HOST = "localhost";
  final int PORT = 2001;
  private Socket socket;
  private PrintWriter out;
  private BufferedReader in;
  private Gson gson;

  public MenusClient()
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

  @Override public synchronized List<Menu> getMenus()
  {
    out.println("Menus");
    List<Menu> menus = new ArrayList<>();
    try
    {
      out.println("getMenus");
      out.println("");
      String response = in.readLine();
      menus = gson.fromJson(response, new TypeToken<ArrayList<Menu>>()
      {
      }.getType());
    }
    catch (IOException e)
    {
      e.printStackTrace();
    }

    return menus;
  }

  @Override public synchronized Menu createMenu(Menu menu)
  {
    out.println("Menus");
    String response = "";
    try
    {
      out.println("createMenu");
      String send = gson.toJson(menu);
      out.println(send);
      response = in.readLine();
    }
    catch (IOException e)
    {
      e.printStackTrace();
    }
    return gson.fromJson(response, Menu.class);
  }

  @Override
  public synchronized Menu getMenu(int menuId) {
    String response = "";
    try
    {
      out.println("Menu");
      out.println("getMenu");
      out.println(menuId);
      response = in.readLine();
    }
    catch (Exception e)
    {
      e.printStackTrace();
    }
    return gson.fromJson(response, Menu.class);
  }


}
