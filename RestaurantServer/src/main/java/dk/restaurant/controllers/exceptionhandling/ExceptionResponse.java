package dk.restaurant.controllers.exceptionhandling;

import org.springframework.stereotype.Component;

@Component
public class ExceptionResponse {
    private int code;
    private String message;

    public ExceptionResponse() {

    }

    public void setCode(int value) {
        this.code = value;
    }

    public void setDescription(String message) {
        this.message = message;
    }

    public int getCode() {
        return code;
    }

    public String getMessage() {
        return message;
    }
}
