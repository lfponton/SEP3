package dk.restaurant.models;

import java.io.Serializable;

public class DeliveryDriver extends Person implements Serializable
{
  public DeliveryDriver(int deliveryDriverId, String email, String firstName,
      String lastName, String password)
  {
    super(deliveryDriverId, email, firstName, lastName, password);
  }

  public DeliveryDriver()
  {
  }

}
