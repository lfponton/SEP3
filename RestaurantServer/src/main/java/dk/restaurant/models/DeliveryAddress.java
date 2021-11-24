package dk.restaurant.models;

public class DeliveryAddress
{
  private int deliveryAddressId;
  private String city;
  private String streetName;
  private String postNumber;
  private String addressNumber;
  private String door;

  public DeliveryAddress(int addressId, String city, String streetName,
      String postNumber, String addressNumber, String door)
  {
    this.deliveryAddressId = addressId;
    this.city = city;
    this.streetName = streetName;
    this.postNumber = postNumber;
    this.addressNumber = addressNumber;
    this.door = door;
  }

  public DeliveryAddress()
  {
  }

  public int getDeliveryAddressId()
  {
    return deliveryAddressId;
  }

  public void setDeliveryAddressId(int deliveryAddressId)
  {
    this.deliveryAddressId = deliveryAddressId;
  }

  public String getCity()
  {
    return city;
  }

  public void setCity(String city)
  {
    this.city = city;
  }

  public String getStreetName()
  {
    return streetName;
  }

  public void setStreetName(String streetName)
  {
    this.streetName = streetName;
  }

  public String getPostNumber()
  {
    return postNumber;
  }

  public void setPostNumber(String postNumber)
  {
    this.postNumber = postNumber;
  }

  public String getAddressNumber()
  {
    return addressNumber;
  }

  public void setAddressNumber(String addressNumber)
  {
    this.addressNumber = addressNumber;
  }

  public String getDoor()
  {
    return door;
  }

  public void setDoor(String door)
  {
    this.door = door;
  }
}
