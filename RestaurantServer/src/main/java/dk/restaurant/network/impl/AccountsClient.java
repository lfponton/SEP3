package dk.restaurant.network.impl;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;
import dk.restaurant.models.Customer;
import dk.restaurant.models.Employee;
import dk.restaurant.models.Person;
import dk.restaurant.network.IAccountsClient;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;

public class AccountsClient implements IAccountsClient
{
  final String HOST = "localhost";
  final int PORT = 2001;
  private Socket socket;
  private PrintWriter out;
  private BufferedReader in;
  private Gson gson;

  public AccountsClient()
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

  @Override public synchronized Person getAccount()
  {
    out.println("Accounts");
    String response = "";
    try
    {
      out.println("getAccount");
      out.println("");
      response = in.readLine();
    }
    catch (IOException e)
    {
      e.printStackTrace();
    }

    return gson.fromJson(response, Person.class);
  }

  @Override public Employee createEmployeeAccount(Employee employee)
  {
    out.println("Accounts");
    String response = "";
    try
    {
      out.println("createEmployeeAccount");
      String send = gson.toJson(employee);
      out.println(send);
      response = in.readLine();
    }
    catch (IOException e)
    {
      e.printStackTrace();
    }
    return gson.fromJson(response, Employee.class);
  }

  @Override public Customer createCustomerAccount(Customer customer)
  {
    out.println("Accounts");
    String response = "";
    try
    {
      out.println("createCustomerAccount");
      String send = gson.toJson(customer);
      out.println(send);
      response = in.readLine();
    }
    catch (IOException e)
    {
      e.printStackTrace();
    }
    return gson.fromJson(response, Customer.class);
  }

  @Override public Employee getEmployeeAccount(String email)
  {
    out.println("Accounts");
    String response = "";
    try
    {
      out.println("getEmployeeAccount");
      out.println(email);
      response = in.readLine();
    }
    catch (IOException e)
    {
      e.printStackTrace();
    }

    return gson.fromJson(response, Employee.class);
  }

  @Override public Customer getCustomerAccount(String email)
  {
    out.println("Accounts");
    String response = "";
    try
    {
      out.println("getCustomerAccount");
      out.println(email);
      response = in.readLine();
    }
    catch (IOException e)
    {
      e.printStackTrace();
    }

    return gson.fromJson(response, Customer.class);
  }

}

