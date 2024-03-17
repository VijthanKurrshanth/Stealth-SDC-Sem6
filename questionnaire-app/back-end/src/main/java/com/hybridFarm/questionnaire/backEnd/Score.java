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
    private Boolean[] score;

    public Score() {
        this.score = new Boolean[this.noOfQuestions];
        Arrays.fill(score, false);
    }

    public void setScore(int index, Boolean value) {
        score[index] = value;
    }
}
