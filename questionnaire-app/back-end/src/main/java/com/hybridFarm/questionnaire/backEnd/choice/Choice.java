package com.hybridFarm.questionnaire.backEnd.choice;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.persistence.Table;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Setter
@Getter
@NoArgsConstructor
@AllArgsConstructor
@Entity
@Table(name = "choices")
public class Choice {
    @Id
    @Column(name = "id")
    private Integer id;
    @Column(name = "question_id")
    private Integer questionId;
    @Column(name = "choice_text")
    private String choiceText;
    @Column(name = "is_correct")
    private Boolean isCorrect;
}
