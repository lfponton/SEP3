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
    Employee employee = client.getEmployeeAccount(email);

    if (employee == null) {
      throw new NullPointerException("User not found");
    }
    else
    {
      if (employee.getPassword().equals(password))
      {
        return employee;
      }
    }
    return null;
  }

  @Override public Customer getCustomerAccount(String email, String password)
  {
    Customer customer = client.getCustomerAccount(email);

    if (customer == null) {
      throw new NullPointerException("User not found");
    }
    else
    {
      if (customer.getPassword().equals(password))
      {
        return customer;
      }
    }
    return null;
  }
}
