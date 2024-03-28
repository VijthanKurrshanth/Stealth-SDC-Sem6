-- Create the database (if it doesn't exist)
CREATE DATABASE IF NOT EXISTS questionnaire;

-- Use the questionnaire database
USE questionnaire;

DROP TABLE IF EXISTS choices;
DROP TABLE IF EXISTS general_feedbacks;
DROP TABLE IF EXISTS specific_feedbacks;
DROP TABLE IF EXISTS questions;

-- Create the questions table
CREATE TABLE questions (
  id INT PRIMARY KEY AUTO_INCREMENT,
  question TEXT NOT NULL
);

-- Create the choices table
CREATE TABLE choices (
  id INT PRIMARY KEY AUTO_INCREMENT,
  question_id INT NOT NULL,
  choice_text TEXT NOT NULL,
  is_correct BOOLEAN DEFAULT FALSE,
  FOREIGN KEY (question_id) REFERENCES questions(id)
);

-- Create the questions table
CREATE TABLE general_feedbacks (
  id INT PRIMARY KEY AUTO_INCREMENT,
  general_feedback TEXT NOT NULL
);

-- Create the choices table
CREATE TABLE specific_feedbacks (
  id INT PRIMARY KEY AUTO_INCREMENT,
  question_id INT NOT NULL,
  specific_feedback TEXT NOT NULL,
  FOREIGN KEY (question_id) REFERENCES questions(id)
);

-- Insert the questions
INSERT INTO questions (question)
VALUES
  ("What is the primary source of energy for most power grids around the world?"),
  ("How does electricity typically travel from power plants to consumers?"),
  ("Why is energy efficiency important in homes and businesses?"),
  ("What is the primary goal of demand management in energy usage?"),
  ("Which of the following is a common method used in demand management to encourage lower energy use during peak hours?"),
  ("Benefits to the consumer from demand management include:"),
  ("How does implementing demand management strategies benefit the environment?"),
  ("What can be a direct benefit of participating in a demand management program for consumers?"),
  ("Why is load shifting important in demand management?"),
  ("Which of the following electric loads can be effectively managed as part of a demand management program?");

-- Insert the choices and mark the correct answer for each question
INSERT INTO choices (question_id, choice_text, is_correct)
VALUES
  (1, "Solar power", FALSE),
  (1, "Wind power", FALSE),
  (1, "Fossil fuels", TRUE),
  (1, "Hydropower", FALSE),
  (2, "Through water pipes", FALSE),
  (2, "Via transmission and distribution networks", TRUE),
  (2, "Directly from generators to homes", FALSE),
  (2, "Through the internet", FALSE),
  (3, "It increases energy consumption", FALSE),
  (3, "It leads to higher energy costs", FALSE),
  (3, "It reduces energy bills and environmental impact", TRUE),
  (3, "It has no impact on the environment", FALSE),
  (4, "To increase the overall energy consumption", FALSE),
  (4, "To balance energy supply and demand", TRUE),
  (4, "To eliminate the use of renewable energy sources", FALSE),
  (4, "To double the energy costs for consumers", FALSE),
  (5, "Increasing energy prices during off-peak hours", FALSE),
  (5, "Providing incentives for high energy consumption", FALSE),
  (5, "Offering lower rates or incentives for using less energy during peak times", TRUE),
  (5, "Discouraging the use of energy-efficient appliances", FALSE),
  (6, "Higher energy bills", FALSE),
  (6, "Less control over their energy use", FALSE),
  (6, "Savings on their electricity bill", TRUE),
  (6, "Reduced internet connectivity", FALSE),
  (7, "By significantly increasing carbon emissions", FALSE),
  (7, "By reducing reliance on fossil fuels and lowering carbon emissions", TRUE),
  (7, "By eliminating the need for public transportation", FALSE),
  (7, "By discouraging the use of renewable energy", FALSE),
  (8, "Higher energy bills", FALSE),
  (8, "Less control over their energy use", FALSE),
  (8, "Savings on their electricity bill", TRUE),
  (8, "Reduced internet connectivity", FALSE),
  (9, "It increases the energy load during peak times", FALSE),
  (9, "It shifts energy usage to times when demand is higher", FALSE),
  (9, "It helps balance the power grid by using energy during lower-demand periods", TRUE),
  (9, "It makes energy more expensive during off-peak hours", FALSE),
  (10, "Fixed lighting systems in public areas", FALSE),
  (10, "Emergency medical equipment", FALSE),
  (10, "Residential air conditioning units", TRUE),
  (10, "Data centers that require constant cooling", FALSE);

  -- Insert the general feedback
INSERT INTO general_feedbacks (general_feedback)
VALUES
  ("While the mix of energy sources varies by region, fossil fuels remain the dominant source for electricity generation globally, though renewable sources are on the rise."),
  ("Electricity is generated at power plants and then transmitted over long distances via high-voltage transmission lines. It's then distributed to consumers through lower-voltage distribution networks."),
  ("Energy efficiency is crucial for reducing energy consumption, lowering energy bills, and minimizing the environmental footprint by decreasing greenhouse gas emissions."),
  ("Demand management aims to ensure energy is used more efficiently, balancing the supply with the fluctuating demand to maintain grid stability and reduce costs."),
  ("Lowering rates or providing incentives for reduced energy use during peak hours helps smooth out energy demand, benefiting both the grid and consumer."),
  ("Participating in demand management programs can lead to significant savings on electricity bills for consumers by incentivizing energy use during off-peak hours."),
  ("Implementing demand management strategies plays a crucial role in environmental conservation by reducing the reliance on non-renewable energy sources and minimizing carbon emissions."),
  ("Participation in demand management programs often results in direct benefits for consumers, such as savings on electricity bills, by encouraging energy use during less expensive, off-peak hours."),
  ("Load shifting is a critical component of demand management, aimed at moving energy use from peak to off-peak hours. This helps balance the power grid, reduces the need for additional power plants, and can lead to cost savings for consumers and utility providers alike."),
  ("Demand management programs focus on adjusting the usage of flexible and non-critical electric loads to optimize energy consumption. Residential air conditioning units, for example, can be adjusted without compromising safety or critical operations, making them ideal for inclusion in these programs.");

  -- Insert the choices and mark the correct answer for each question
INSERT INTO specific_feedbacks (question_id, specific_feedback)
VALUES
  (1, "Solar power is growing but is not the primary source globally."),
  (1, "Wind power is significant in some areas but not the main source worldwide."),
  (1, "Correct! Fossil fuels, including coal, natural gas, and oil, are currently the primary energy source for most power grids."),
  (1, "Hydropower is a key renewable source but not the primary source globally."),
  (2, "Water pipes are used for plumbing, not electrical transmission."),
  (2, "Correct! Transmission and distribution networks are essential for delivering electricity from power plants to consumers."),
  (2, "Electricity must be transmitted and distributed over networks; it doesn't go directly from generators to homes."),
  (2, "The internet is a network for data, not electricity."),
  (3, "Energy efficiency aims to reduce, not increase, consumption."),
  (3, "The goal of energy efficiency is to lower costs, not raise them."),
  (3, "Correct! Energy efficiency helps in saving on energy bills and reducing the environmental impact."),
  (3, "Energy efficiency has a significant positive impact on the environment by reducing emissions."),
  (4, "This is the opposite of demand management's goal, which aims to optimize, not increase, energy use."),
  (4, "Correct! Balancing energy supply and demand helps improve grid reliability and efficiency."),
  (4, "Demand management often encourages the integration of renewable energy sources, not their elimination."),
  (4, "The goal is to potentially lower or optimize costs, not increase them."),
  (5, "This approach would not encourage lower usage during peak times."),
  (5, "Incentives are typically offered for reducing consumption, not increasing it."),
  (5, "Correct! Incentives for lower usage during peak hours help manage demand effectively."),
  (5, "Energy-efficient appliances are actually encouraged as part of demand management strategies."),
  (6, "Demand management aims to reduce, not increase, consumer energy bills."),
  (6, "It actually offers more control over energy use and costs."),
  (6, "Correct! One of the key benefits for consumers is the potential for savings on their electricity bills."),
  (6, "Demand management focuses on energy consumption, not affecting internet connectivity."),
  (7, "Demand management aims to decrease, not increase, carbon emissions."),
  (7, "Correct! Reducing reliance on fossil fuels and lowering carbon emissions are key environmental benefits of demand management."),
  (7, "Demand management strategies do not involve transportation policies directly."),
  (7, "These strategies typically encourage, rather than discourage, the use of renewable energy sources."),
  (8, "The goal of demand management is to offer savings, not to increase bills."),
  (8, "Participants typically gain greater control and flexibility over their energy use."),
  (8, "Correct! Saving on electricity bills is a significant benefit for consumers who participate in demand management programs."),
  (8, "Demand management does not impact internet connectivity."),
  (9, "The purpose of load shifting is to decrease, not increase, the load during peak times to help balance energy demand."),
  (9, "Shifting energy usage to higher demand times would counteract the goals of demand management, which seeks to alleviate these peaks."),
  (9, "Correct! By shifting energy use to lower-demand periods, we can achieve a more balanced and efficient use of the power grid."),
  (9, "Load shifting is designed to take advantage of lower costs during off-peak hours, not to make energy more expensive."),
  (10, "While lighting can be managed, fixed systems in public areas often have safety implications that limit their flexibility."),
  (10, "Emergency medical equipment is critical and cannot be subject to demand management due to the risk to human life."),
  (10, "Correct! Residential air conditioning units are a significant and flexible load that can be adjusted to enhance grid efficiency without compromising comfort significantly."),
  (10, "Data centers have strict cooling requirements for operational integrity and may not offer the flexibility required for effective demand management.");