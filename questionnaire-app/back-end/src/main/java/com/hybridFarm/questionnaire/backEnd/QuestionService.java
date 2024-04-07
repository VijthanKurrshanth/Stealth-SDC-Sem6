package com.hybridFarm.questionnaire.backEnd;

import com.hybridFarm.questionnaire.backEnd.choice.Choice;
import com.hybridFarm.questionnaire.backEnd.choice.ChoiceRepo;
import com.hybridFarm.questionnaire.backEnd.exception.ResourceNotFoundException;
import com.hybridFarm.questionnaire.backEnd.generalFeedback.GeneralFeedback;
import com.hybridFarm.questionnaire.backEnd.generalFeedback.GeneralFeedbackRepo;
import com.hybridFarm.questionnaire.backEnd.question.Question;
import com.hybridFarm.questionnaire.backEnd.question.QuestionRepo;
import com.hybridFarm.questionnaire.backEnd.specificFeedback.SpecificFeedback;
import com.hybridFarm.questionnaire.backEnd.specificFeedback.SpecificFeedbackRepo;
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
    private final SpecificFeedbackRepo specificFeedbackRepo;
    private final GeneralFeedbackRepo generalFeedbackRepo;
    private final Score score;

    public QuestionService(QuestionRepo questionRepo, ChoiceRepo choiceRepo, SpecificFeedbackRepo specificFeedbackRepo,
            GeneralFeedbackRepo generalFeedbackRepo, Score score) {
        this.questionRepo = questionRepo;
        this.choiceRepo = choiceRepo;
        this.specificFeedbackRepo = specificFeedbackRepo;
        this.generalFeedbackRepo = generalFeedbackRepo;
        this.score = score;
    }

    public QuestionDto getQuestionDto(Integer id) {
        Question question = questionRepo.findById(id).orElseThrow(ResourceNotFoundException::new);
        String questionText = question.getQuestion();
        List<String> choiceList = choiceRepo.findByQuestionIdOrderById(id).stream()
                .map(Choice::getChoiceText)
                .collect(Collectors.toList());
        return new QuestionDto(id, questionText, choiceList);
    }

    public void evaluate(Integer questionId, Integer answerId) {
        SpecificFeedback specificFeedback = specificFeedbackRepo.findById(answerId)
                .orElseThrow(ResourceNotFoundException::new);
        Choice choice = choiceRepo.findById(answerId).orElseThrow(ResourceNotFoundException::new);
        score.setSpecificFeedbacks(questionId - 1, specificFeedback.getSpecificFeedback());
        if (choice.getIsCorrect()) {
            score.setScore(questionId - 1, true);
            System.out.println("Question " + questionId + " Correct");
        } else {
            score.setScore(questionId - 1, false);
            System.out.println("Question " + questionId + " Incorrect");
        }
        if (questionId == 10) {
            score.setFinished(true);
        }
    }

    public List<Map<String, String>> getAnswerSheet() {
        List<Question> questions = questionRepo.findAll();
        Boolean[] score = this.score.getScore();
        String[] specificFeedbacks = this.score.getSpecificFeedbacks();
        List<GeneralFeedback> generalFeedbacks = generalFeedbackRepo.findAll();

        List<Map<String, String>> result = new ArrayList<>();

        for (int i = 0; i < questions.size(); i++) {
            Map<String, String> subObject = new HashMap<>();

            subObject.put("question", questions.get(i).getQuestion());
            subObject.put("specificFeedback", specificFeedbacks[i]);
            subObject.put("generalFeedback", generalFeedbacks.get(i).getGeneralFeedback());
            subObject.put("score", score[i] ? "CORRECT" : "INCORRECT");
            result.add(subObject);
        }
        return result;
    }

    public Long getScore() {
        if (!score.getFinished()) {
            return -1L;
        }
        return (long) Stream.of(score.getScore()).filter(Boolean::booleanValue).count(); // Counting the number of
                                                                                         // correct answers
    }

    public void resetScore() {
        score.resetScore();
    }
}
