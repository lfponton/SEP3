package dk.restaurant.network;

import dk.restaurant.models.Customer;
import dk.restaurant.models.Employee;
import dk.restaurant.models.User;

public interface IAccountsClient
{
  User getAccount();
  Employee createEmployeeAccount(Employee employee);
  Customer createCustomerAccount(Customer customer);
  Employee getEmployeeAccount(String email);
  Customer getCustomerAccount(String email);
}
