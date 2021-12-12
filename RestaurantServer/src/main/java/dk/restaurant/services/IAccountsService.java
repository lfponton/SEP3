package dk.restaurant.services;

import dk.restaurant.models.Customer;
import dk.restaurant.models.Employee;

public interface IAccountsService
{
  Employee createEmployeeAccount(Employee employee);
  Customer createCustomerAccount(Customer customer);
  Employee getEmployeeAccount(String email, String password) throws Exception;
  Customer getCustomerAccount(String email, String password) throws Exception;
}
