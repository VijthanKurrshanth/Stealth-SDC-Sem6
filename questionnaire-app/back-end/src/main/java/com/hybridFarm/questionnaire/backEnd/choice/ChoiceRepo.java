package com.hybridFarm.questionnaire.backEnd.choice;

import org.springframework.data.jpa.repository.JpaRepository;

import java.util.Collection;
import java.util.List;

public interface ChoiceRepo extends JpaRepository<Choice, Integer> {
    Collection<Choice> findByQuestionId(Integer id);

    List<Choice> findByIsCorrect(boolean b);
}
