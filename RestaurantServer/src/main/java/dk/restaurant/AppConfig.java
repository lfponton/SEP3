package dk.restaurant;

import dk.restaurant.network.IClient;
import dk.restaurant.network.impl.Client;
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
}
