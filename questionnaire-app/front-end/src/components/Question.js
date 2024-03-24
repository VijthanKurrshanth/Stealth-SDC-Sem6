import { useState } from "react";
import "../styles/Question.css";
import { useEffect } from "react";
import Choices from "./Choices";
import LoadingScreen from "./LoadingScreen";

const Question = () => {
  const backendUrl = process.env.REACT_APP_BACKEND_BASE_URL;
  const [loading, setLoading] = useState(false);
  const [questionId, setQuestionId] = useState(1);
  const [questionText, setQuestionText] = useState("");
  const [choices, setChoices] = useState([]);
  const [error, setError] = useState(null);

  useEffect(() => {
    setLoading(true);
    fetch(backendUrl + "/" + questionId)
      .then((response) => {
        if (!response.ok) throw new Error(response.statusText);
        return response;
      })
      .then((response) => response.json())
      .then((data) => {
        setQuestionText(data.question);
        setChoices(data.choices);
        setLoading(false);
      })
      .catch((error) => {
        console.error("Error:", error);
        setError(error);
      });
  }, [backendUrl, questionId]);

  function handleChoiceClick(choice) {
    console.log(choice);
    setQuestionId(questionId + 1);
  }

  if (loading) return <LoadingScreen />;

  return (
    <div>
      <header className="BlankSpace"></header>
      <h1 className="Question">{questionText}</h1>
      <Choices handleClick={handleChoiceClick} choices={choices} />
    </div>
  );
};

export default Question;
