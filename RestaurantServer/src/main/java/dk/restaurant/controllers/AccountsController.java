package dk.restaurant.controllers;

import dk.restaurant.models.Customer;
import dk.restaurant.models.Employee;
import dk.restaurant.services.IAccountsService;
import dk.restaurant.services.IServiceFactory;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController public class AccountsController
{
  private IAccountsService service;

  public AccountsController(IServiceFactory serviceFactory)
  {
    this.service = serviceFactory.getAccountsService();
  }

  @GetMapping("/accounts/employees") public ResponseEntity<Employee> getEmployeeAccount(
      @RequestParam(value = "email") String email,
      @RequestParam(value = "password") String password) throws Exception
  {
    Employee employee = service.getEmployeeAccount(email, password);
    return new ResponseEntity<Employee>(employee, HttpStatus.OK);
  }

  @GetMapping("/accounts/customers") public ResponseEntity<Customer> getCustomerAccount(
      @RequestParam(value = "email") String email,
      @RequestParam(value = "password") String password) throws Exception
  {
    Customer customer = service.getCustomerAccount(email, password);
    return new ResponseEntity<Customer>(customer, HttpStatus.OK);
  }

  @PostMapping("/accounts/employees") @ResponseStatus(HttpStatus.CREATED) public Employee createEmployeeAccount(
      @RequestBody Employee employee)
  {
    return service.createEmployeeAccount(employee);
  }

  @PostMapping("/accounts/customers") @ResponseStatus(HttpStatus.CREATED) public Customer createEmployeeAccount(
      @RequestBody Customer customer)
  {
    return service.createCustomerAccount(customer);
  }

}

