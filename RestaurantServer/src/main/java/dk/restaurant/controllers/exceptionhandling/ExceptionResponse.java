package dk.restaurant.controllers.exceptionhandling;

import org.springframework.stereotype.Component;

@Component
public class ExceptionResponse {
    private int cody;
    private String message;

    public ExceptionResponse() {

    }

    public void setCody(int value) {
        this.cody = value;
    }

    public void setDescription(String message) {
        this.message = message;
    }

    public int getCody() {
        return cody;
    }

    public String getMessage() {
        return message;
    }
}
