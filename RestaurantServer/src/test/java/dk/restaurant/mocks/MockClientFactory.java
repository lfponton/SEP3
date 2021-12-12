package dk.restaurant.mocks;

import dk.restaurant.network.*;
import dk.restaurant.network.impl.*;
import org.apache.commons.lang3.NotImplementedException;

public class MockClientFactory implements IClientFactory
{
  MockOrderClient mockOrderClient;

  public MockClientFactory()
  {
  }

  public MockOrderClient getOrdersClient()
  {
    if (mockOrderClient == null)
    {
      mockOrderClient = new MockOrderClient();
    }

    return mockOrderClient;
  }

  @Override public IMenusClient getMenusClient()
  {
    throw new NotImplementedException();
  }

  @Override public IMenuItemsClient getMenuItemsClient()
  {
    throw new NotImplementedException();
  }

  @Override public IMenuItemsSelectionsClient getMenuItemsSelectionsClient()
  {
    throw new NotImplementedException();
  }

  @Override
  public ITableBookingsClient getTableBookingsClient() {
    throw new NotImplementedException();
  }

  @Override public IAccountsClient getAccountsClient()
  {
    throw new NotImplementedException();
  }

  @Override
  public IRestaurantClient getRestaurantClient() {
    throw new NotImplementedException();
  }

}
