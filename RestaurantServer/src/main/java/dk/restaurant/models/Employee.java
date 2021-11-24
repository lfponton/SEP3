package dk.restaurant.models;

import java.io.Serializable;

public class Employee extends Person implements Serializable
{
  public Employee()
  {
  }

  public Employee(long employeeId, String email, String firstName,
      String lastName)
  {
    super(employeeId, email, firstName, lastName);
  }
}
