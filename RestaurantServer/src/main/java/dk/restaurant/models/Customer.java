package dk.restaurant.models;

public class Customer extends User
{
  public Customer()
  {
  }

  public Customer(long customerId, String email, String firstName,
      String lastName, String password)
  {
    super(customerId, email, firstName, lastName, password);
  }

}
