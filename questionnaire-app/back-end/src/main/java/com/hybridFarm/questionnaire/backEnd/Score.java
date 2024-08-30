package com.hybridFarm.questionnaire.backEnd;

import lombok.Getter;
import lombok.Setter;
import org.springframework.stereotype.Component;

import java.util.Arrays;


@Getter
@Component
public class Score {
    @Setter
    private Integer noOfQuestions = 10;
    @Getter
    @Setter
    private Boolean finished = false;
    private String[] specificFeedbacks;
    private Boolean[] score;

    public Score() {
        this.score = new Boolean[this.noOfQuestions];
        Arrays.fill(score, false);
        this.specificFeedbacks = new String[this.noOfQuestions];
        Arrays.fill(specificFeedbacks, "");
    }

    public void setScore(int index, Boolean value) {
        score[index] = value;
    }

    public void setSpecificFeedbacks(int index, String value) {
        specificFeedbacks[index] = value;
    }

    public void resetScore(){
        Arrays.fill(score, false);
        Arrays.fill(specificFeedbacks, "");
        finished = false;
    }
}
