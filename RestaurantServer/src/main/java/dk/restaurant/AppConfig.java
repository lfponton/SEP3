package dk.restaurant;

import dk.restaurant.controllers.ErrorHandlingController;
import dk.restaurant.controllers.exceptionhandling.ExceptionResponse;
import dk.restaurant.network.IClientFactory;
import dk.restaurant.network.impl.ClientFactory;
import dk.restaurant.services.IServiceFactory;
import dk.restaurant.services.ITableBookingService;
import dk.restaurant.services.impl.ServiceFactory;
import dk.restaurant.services.impl.TableBookingService;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration public class AppConfig
{
  @Bean public IClientFactory ClientFactory()
  {
    return new ClientFactory();
  }

  @Bean public IServiceFactory ServiceFactory()
  {
    return new ServiceFactory(ClientFactory());
  }

  @Bean public ExceptionResponse ExceptionResponse(){return new ExceptionResponse();}

  @Bean public ErrorHandlingController ErrorController(){return new ErrorHandlingController();}
}

