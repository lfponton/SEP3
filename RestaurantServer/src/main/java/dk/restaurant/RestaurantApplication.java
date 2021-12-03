package dk.restaurant;


import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;



@SpringBootApplication
public class RestaurantApplication {
	private static final Logger LOGGER = LoggerFactory.getLogger(
			RestaurantApplication.class);

	public static void main(String[] args) {
		SpringApplication.run(RestaurantApplication.class, args);
		LOGGER.info("Swagger-UI at: http://localhost:8080/swagger-ui.html");
	}

}
