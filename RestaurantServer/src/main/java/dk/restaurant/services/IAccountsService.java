package dk.restaurant.services;

import dk.restaurant.models.Customer;
import dk.restaurant.models.Employee;
import dk.restaurant.models.Person;

public interface IAccountsService
{
  Employee createEmployeeAccount(Employee employee);
  Customer createCustomerAccount(Customer customer);
  Employee getEmployeeAccount(String email, String password);
  Customer getCustomerAccount(String email, String password);
}
