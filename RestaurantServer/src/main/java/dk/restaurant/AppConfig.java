package dk.restaurant;

import dk.restaurant.network.IClient;
import dk.restaurant.network.impl.Client;
import dk.restaurant.services.ITableBookingService;
import dk.restaurant.services.impl.TableBookingService;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class AppConfig
{
  @Bean
  public IClient Client()
  {
    return new Client();
  }
  @Bean
  ITableBookingService TableBookingsService()
  {
    return new TableBookingService(Client());}
  }

