package com.hybridFarm.questionnaire.backEnd;

import lombok.Getter;
import lombok.Setter;
import org.springframework.http.HttpEntity;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpMethod;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.client.RestClientException;
import org.springframework.web.client.RestTemplate;

@RestController
@CrossOrigin
@RequestMapping(path = "hybridFarm/v1")
public class AuthenticationController {
    private final String authentiactionURL = System.getenv("AUTHENTICATION_URL");
    private final RestTemplate restTemplate = new RestTemplate();
    private final HttpHeaders headers = new HttpHeaders();
    @Getter
    @Setter
    private Boolean isAuthenticated = false;

    @PostMapping("authenticate")
    public ResponseEntity<?> authenticate(@RequestBody AuthenticationRequest authenticationRequest) {
        // This method will authenticate the user by sending a POST request to the authentication server
        System.out.println("Authenticating user with API key: " + authenticationRequest.apiKey());
        HttpEntity<AuthenticationRequest> requestEntity = new HttpEntity<>(authenticationRequest, headers);
        try {
            ResponseEntity<AuthenticationEntity> response = restTemplate.exchange(
                    authentiactionURL,
                    HttpMethod.POST,
                    requestEntity,
                    AuthenticationEntity.class
            );
            if (response.getStatusCode().is2xxSuccessful()) {
                isAuthenticated = true;
                return response;
            } else {
                isAuthenticated = true;
                return ResponseEntity.badRequest().build();
            }
        } catch (RestClientException e) {
            System.out.println("Authentication Failed: " + e.getMessage());
            return ResponseEntity.badRequest().build();
        }
    }

    private record AuthenticationEntity(String token) {
    }
    public record AuthenticationRequest(String apiKey){
    }
}
