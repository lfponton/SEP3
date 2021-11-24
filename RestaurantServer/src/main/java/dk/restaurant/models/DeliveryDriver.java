package dk.restaurant.models;

import java.io.Serializable;

public class DeliveryDriver extends Person implements Serializable
{
  public DeliveryDriver(int deliveryDriverId, String email, String firstName,
      String lastName)
  {
    super(deliveryDriverId, email, firstName, lastName);
  }

  public DeliveryDriver()
  {
  }

}
