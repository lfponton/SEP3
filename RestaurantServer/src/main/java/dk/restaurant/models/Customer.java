package dk.restaurant.models;

import org.springframework.stereotype.Component;

import java.io.Serializable;

public class Customer extends Person implements Serializable
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
