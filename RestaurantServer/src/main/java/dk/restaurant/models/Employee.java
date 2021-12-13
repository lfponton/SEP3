package dk.restaurant.models;

public class Employee extends User
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
