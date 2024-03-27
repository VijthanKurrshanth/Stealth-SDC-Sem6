package com.hybridFarm.questionnaire.backEnd;

import com.hybridFarm.questionnaire.backEnd.choice.Choice;
import com.hybridFarm.questionnaire.backEnd.choice.ChoiceRepo;
import com.hybridFarm.questionnaire.backEnd.exception.ResourceNotFoundException;
import com.hybridFarm.questionnaire.backEnd.question.Question;
import com.hybridFarm.questionnaire.backEnd.question.QuestionRepo;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
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
        List<String> choiceMap = choiceStream.collect(Collectors.toMap(Choice::getId, Choice::getChoiceText)).entrySet().stream()
                .toList().stream().map(Map.Entry::getValue).collect(Collectors.toList());

        return new QuestionDto(id, questionText, choiceMap);
    }

    public void evaluate(Integer questionId, Integer answerId) {
        Choice choice = choiceRepo.findById(answerId).orElseThrow(ResourceNotFoundException::new);
        score.setChoices(questionId-1, choice.getChoiceText());
        if (choice.getIsCorrect()) {
            score.setScore(questionId-1, true);
            System.out.println("Question " + questionId + " Correct");
        } else {
            score.setScore(questionId-1, false);
            System.out.println("Question " + questionId + " Incorrect");
        }
    }

    public List<Map<String, String>> getAnswerSheet() {
        List<Question> questions = questionRepo.findAll();
        List<Choice> answers = choiceRepo.findByIsCorrect(true);
        Boolean[] score = this.score.getScore();
        String[] choices = this.score.getChoices();

        List<Map<String, String>> result = new ArrayList<>();

        for (int i = 0; i < questions.size(); i++) {
            Map<String, String> subObject = new HashMap<>();

            subObject.put("Question", questions.get(i).getQuestion());
            subObject.put("Your-Answer", choices[i]);
            subObject.put("Correct-Answer", answers.get(i).getChoiceText());
            subObject.put("Score", score[i]? "CORRECT" : "INCORRECT");
            result.add(subObject);
        }
        return result;
    }

    public Long getScore() {
        return (long) Stream.of(score.getScore()).filter(Boolean::booleanValue).count(); // Counting the number of correct answers
    }
}
