package com.hybridFarm.questionnaire.backEnd;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Map;

@RestController
@CrossOrigin
@RequestMapping(path = "hybridFarm/v1")
public class QuestionController {
    private final QuestionService questionService;
    private final AuthenticationController authenticationController;

    @Autowired
    public QuestionController(QuestionService questionService, AuthenticationController authenticationController) {
        this.questionService = questionService;
        this.authenticationController = authenticationController;
    }

    // Get Question REST API
    @GetMapping("{id}")
    public ResponseEntity<?> getQuestion(@PathVariable("id") Integer id) {
        if (!authenticationController.getIsAuthenticated()) {
            return ResponseEntity.status(HttpStatus.UNAUTHORIZED).build();
        }
        QuestionDto questionDto = questionService.getQuestionDto(id);
        return ResponseEntity.ok(questionDto);
    }

    // Get Answer Sheet REST API
    @GetMapping
    public ResponseEntity<?> getAnswerSheet() {
        if (!authenticationController.getIsAuthenticated()) {
            return ResponseEntity.status(HttpStatus.UNAUTHORIZED).build();
        }
        List<Map<String, String>> response = questionService.getAnswerSheet();
        return ResponseEntity.ok(response);
    }

    // Get Final Score REST API
    @GetMapping("score")
    public ResponseEntity<?> getScore() {
        if (!authenticationController.getIsAuthenticated()) {
            return ResponseEntity.status(HttpStatus.UNAUTHORIZED).build();
        }
        return ResponseEntity.ok(questionService.getScore());
    }

    // Receive Answer REST API
    @PostMapping("{id}")
    public ResponseEntity<?> receiveAnswer(@PathVariable("id") Integer questionId, @RequestParam("Answer-Id") Integer answerId){
        if (!authenticationController.getIsAuthenticated()) {
            return ResponseEntity.status(HttpStatus.UNAUTHORIZED).build();
        }
        questionService.evaluate(questionId, answerId);
        return ResponseEntity.status(HttpStatus.CREATED).build();
    }

    @PostMapping("reset")
    public ResponseEntity<?> resetScore(){
        if (!authenticationController.getIsAuthenticated()) {
            return ResponseEntity.status(HttpStatus.UNAUTHORIZED).build();
        }
        questionService.resetScore();
        authenticationController.setIsAuthenticated(false);
        return ResponseEntity.status(HttpStatus.CREATED).build();
    }
}
