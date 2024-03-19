package com.hybridFarm.questionnaire.backEnd;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.Map;

@RestController
@CrossOrigin
@RequestMapping(path = "hybridFarm/v1")
public class QuestionController {
    private final QuestionService questionService;

    @Autowired
    public QuestionController(QuestionService questionService) {
        this.questionService = questionService;
    }

    // Get Question REST API
    @GetMapping("{id}")
    public ResponseEntity<?> getQuestion(@PathVariable("id") Integer id) {
        QuestionDto questionDto = questionService.getQuestionDto(id);
        return ResponseEntity.ok(questionDto);
    }

    // Get Answer Sheet REST API
    @GetMapping
    public ResponseEntity<?> getAnswerSheet() {
        Map<Integer, Map<String, String>> response = questionService.getAnswerSheet();
        return ResponseEntity.ok(response);
    }

    // Receive Answer REST API
    @PostMapping("{id}")
    public ResponseEntity<?> receiveAnswer(@PathVariable("id") Integer questionId, @RequestParam("Answer-Id") Integer answerId){
        questionService.evaluate(questionId, answerId);
        return ResponseEntity.status(HttpStatus.CREATED).build();
    }
}
