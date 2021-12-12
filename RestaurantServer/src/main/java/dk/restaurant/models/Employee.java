package dk.restaurant.models;

import java.io.Serializable;


public class Employee extends User implements Serializable
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
