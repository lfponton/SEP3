package dk.restaurant.models;

import org.springframework.stereotype.Component;

import java.io.Serializable;

@Component
public class Employee extends Person implements Serializable
{
  public Employee()
  {
  }

  public Employee(long employeeId, String email, String firstName,
      String lastName, String password)
  {
    super(employeeId, email, firstName, lastName, password);
  }
}
