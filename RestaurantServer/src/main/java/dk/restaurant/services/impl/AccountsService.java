package dk.restaurant.services.impl;

import dk.restaurant.models.Customer;
import dk.restaurant.models.Employee;
import dk.restaurant.models.Person;
import dk.restaurant.network.IAccountsClient;
import dk.restaurant.network.IClientFactory;
import dk.restaurant.network.IMenuItemsSelectionsClient;
import dk.restaurant.services.IAccountsService;

public class AccountsService implements IAccountsService
{
  private IAccountsClient client;

  public AccountsService(IClientFactory clientFactory) {
    this.client = clientFactory.getAccountsClient();
  }

  @Override public Employee createEmployeeAccount(Employee employee)
  {
    return client.createEmployeeAccount(employee);
  }

  @Override public Customer createCustomerAccount(Customer customer)
  {
    return client.createCustomerAccount(customer);
  }

  @Override public Employee getEmployeeAccount(String email, String password)
  {
    Employee employee = new Employee();
    try
    {
      employee = client.getEmployeeAccount(email);
      validateEmployee(employee, password);
    } catch (Exception e)
    {
      throw e;
    }
    return employee;
  }

  private void validateEmployee(Employee employee, String password)
  {
    if (employee == null)
    {
      throw new IllegalArgumentException("User not found");
    }
    else
    {
      if (!employee.getPassword().equals(password))
      {
        throw new IllegalArgumentException("Incorrect password");
      }
    }
  }

  @Override public Customer getCustomerAccount(String email, String password)
  {
    Customer customer = new Customer();
    try
    {
      customer = client.getCustomerAccount(email);
      validateEmployee(customer, password);
    } catch (Exception e)
    {
      throw e;
    }
    return customer;
  }

  private void validateEmployee(Customer customer, String password)
  {
    if (customer == null)
    {
      throw new IllegalArgumentException("User not found");
    }
    else
    {
      if (!customer.getPassword().equals(password))
      {
        throw new IllegalArgumentException("Incorrect password");
      }
    }
  }
}
