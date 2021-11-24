package dk.restaurant.models;

import java.io.Serializable;

public class Customer extends Person implements Serializable
{
  public Customer()
  {
  }

  public Customer(long customerId, String email, String firstName,
      String lastName)
  {
    super(customerId, email, firstName, lastName);
  }

}
