package dk.restaurant.network.impl;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;
import dk.restaurant.models.MenuItem;
import dk.restaurant.network.IMenuItemsClient;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;

public class MenuItemsClient implements IMenuItemsClient
{
  final String HOST = "localhost";
  final int PORT = 2001;
  private Socket socket;
  private PrintWriter out;
  private BufferedReader in;
  private Gson gson;

  public MenuItemsClient()
  {
    try
    {
      socket = new Socket(HOST, PORT);
      in = new BufferedReader(new InputStreamReader(socket.getInputStream()));
      out = new PrintWriter(socket.getOutputStream(), true);
      gson = new GsonBuilder().setDateFormat("yyyy-MM-dd'T'HH:mm:ssZ").create();
    } catch (IOException e)
    {
      e.printStackTrace();
    }

  }

  @Override public synchronized List<MenuItem> getMenuItems(int menuId){
    out.println("MenuItems");
    List<MenuItem> menuItems = new ArrayList<>();
    try {
    out.println("getMenuItems");
    out.println(menuId);
    String response = in.readLine();
    menuItems = gson.fromJson(response, new TypeToken<ArrayList<MenuItem>>() {}.getType());
    } catch (IOException e)
    {
      e.printStackTrace();
    }
    return menuItems;
  }

}
