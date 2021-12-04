package dk.restaurant.network.impl;

import dk.restaurant.models.Customer;

public interface IAccountClient
{
  
  Customer updateCustomer(Customer customer);
  void  deleteCustomer(long id);
}
