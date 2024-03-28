package com.hybridFarm.questionnaire.backEnd.generalFeedback;

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
@Table(name = "general_feedbacks")
public class GeneralFeedback {
    @Id
    @Column(name = "id")
    private Integer id;
    @Column(name = "general_feedback")
    private String generalFeedback;
}
