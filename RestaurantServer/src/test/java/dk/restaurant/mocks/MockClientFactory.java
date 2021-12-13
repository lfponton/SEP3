package dk.restaurant.mocks;

import dk.restaurant.network.*;
import org.apache.commons.lang3.NotImplementedException;

public class MockClientFactory implements IClientFactory
{
  MockOrdersClient mockOrderClient;

  public MockClientFactory()
  {
  }

  public MockOrdersClient getOrdersClient()
  {
    if (mockOrderClient == null)
    {
      mockOrderClient = new MockOrdersClient();
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
