package com.hybridFarm.questionnaire.backEnd;

import com.hybridFarm.questionnaire.backEnd.choice.Choice;
import com.hybridFarm.questionnaire.backEnd.choice.ChoiceRepo;
import com.hybridFarm.questionnaire.backEnd.exception.ResourceNotFoundException;
import com.hybridFarm.questionnaire.backEnd.question.Question;
import com.hybridFarm.questionnaire.backEnd.question.QuestionRepo;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;
import java.util.stream.Stream;

@Service
public class QuestionService {
    private final QuestionRepo questionRepo;
    private final ChoiceRepo choiceRepo;
    private final Score score;

    @Autowired
    public QuestionService(QuestionRepo questionRepo, ChoiceRepo choiceRepo, Score score) {
        this.questionRepo = questionRepo;
        this.choiceRepo = choiceRepo;
        this.score = score;
    }

    public QuestionDto getQuestionDto(Integer id) {
        Question question = questionRepo.findById(id).orElseThrow(ResourceNotFoundException::new);
        String questionText = question.getQuestion();
        Stream<Choice> choiceStream = choiceRepo.findByQuestionId(id).stream();
        Map<Integer, String> choiceMap = choiceStream.collect(Collectors.toMap(Choice::getId, Choice::getChoiceText));

        return new QuestionDto(id, questionText, choiceMap);
    }

    public void evaluate(Integer questionId, Integer answerId) {
        Choice choice = choiceRepo.findById(answerId).orElseThrow(ResourceNotFoundException::new);
        if (choice.getIsCorrect()) {
            score.setScore(questionId-1, true);
            System.out.println("Question " + questionId + " Correct");
        } else {
            score.setScore(questionId-1, false);
            System.out.println("Question " + questionId + " Incorrect");
        }
    }

    public Map<Integer, Map<String, String>> getAnswerSheet() {
        List<Question> questions = questionRepo.findAll();
        List<Choice> answers = choiceRepo.findByIsCorrect(true);
        Boolean[] score = this.score.getScore();

        Map<Integer, Map<String, String>> result = new HashMap<>();

        for (int i = 0; i < questions.size(); i++) {
            Map<String, String> subObject = new HashMap<>();

            subObject.put("Question", questions.get(i).getQuestion());
            subObject.put("Correct-Answer", answers.get(i).getChoiceText());
            subObject.put("Score", score[i]? "CORRECT" : "INCORRECT");
            result.put(i+1, subObject);
        }
        return result;
    }
}
