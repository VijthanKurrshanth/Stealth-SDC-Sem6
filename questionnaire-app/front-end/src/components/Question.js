import { useState } from "react";
import "../styles/Question.css";
import { useEffect } from "react";
import Choices from "./Choices";

const Question = () => {
  const backendUrl = process.env.REACT_APP_BACKEND_BASE_URL;
  const [questionId, setQuestionId] = useState(1);
  const [questionText, setQuestionText] = useState("");
  const [choices, setChoices] = useState([]);

  useEffect(() => {
    fetch(backendUrl + "/" + questionId)
      .then((response) => response.json())
      .then((data) => {
        setQuestionText(data.question);
        setChoices(data.choices);
      })
      .catch((error) => console.error("Error:", error));
  }, [backendUrl, questionId]);

  function handleChoiceClick(choice) {
    console.log(choice);
    setQuestionId(questionId + 1);
  }

  return (
    <div>
      <header className="blankSpace"></header>
      <h1 className="Question">{questionText}</h1>
      <Choices handleClick={handleChoiceClick} choices={choices} />
    </div>
  );
};

export default Question;
