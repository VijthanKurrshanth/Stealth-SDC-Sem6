import "../styles/Question.css";

import { useState } from "react";
import { useEffect } from "react";

import Choices from "./Choices";
import LoadingScreen from "./LoadingScreen";
import QuestionAPI from "./QuestionApi";
import Answer from "./Answer";

const Question = () => {
  const [loading, setLoading] = useState(false);
  const [finished, setFinished] = useState(false);
  const [reviewFinished, setReviewFinished] = useState(false);
  const [clickedToSeeAns, setClickedToSeeAns] = useState(false);
  const [questionId, setQuestionId] = useState(1);
  const [questionText, setQuestionText] = useState("");
  const [choices, setChoices] = useState([]);
  const [error, setError] = useState(null);

  const [answers, setAnswers] = useState([]);
  const [finalScore, setFinalScore] = useState(0);

  useEffect(() => {
    if (reviewFinished) {
      setLoading(true);

      QuestionAPI.getFinalScore()
        .then((data) => {
          setFinalScore(data);
          console.log(data);
          setLoading(false);
        })
        .catch((error) => {
          console.error("Error:", error);
          setError(error);
          setLoading(false);
        });
    } else if (finished) {
      if (!clickedToSeeAns) setQuestionText("You have finished the quiz!");
      return;
    } else {
      setLoading(true);

      if (questionId > 10) {
        setFinished(true);
        setQuestionId(0);

        QuestionAPI.getAnswers()
          .then((data) => {
            setAnswers(data);
            console.log(data);
            setLoading(false);
          })
          .catch((error) => {
            console.error("Error:", error);
            setError(error);
            setLoading(false);
          });
      } else {
        QuestionAPI.getQuestion(questionId)
          .then((data) => {
            setQuestionText(data.question);
            setChoices(data.choices);
            setLoading(false);
          })
          .catch((error) => {
            console.error("Error:", error);
            setError(error);
            setLoading(false);
          });
      }
    }
  }, [clickedToSeeAns, finished, questionId, reviewFinished]);

  // useEffect(() => {
  //   if (questionId === 6) {
  //     window.location.href = "/results";
  //   }
  // }, [questionId]);

  function handleChoiceClick(choice) {
    console.log(choice);
    QuestionAPI.postAnswer(questionId, choice);
    setQuestionId(questionId + 1);
  }

  function handleFinish() {
    setClickedToSeeAns(true);
    if (questionId === 10) {
      setReviewFinished(true);
    } else {
      setQuestionId(questionId + 1);
      setQuestionText(answers[questionId]["question"]);
    }
  }

  if (error)
    return (
      <div className="ErrorMessage">
        There was an error loading the question: {error.message}
      </div>
    );
  else if (loading) return <LoadingScreen />;
  else {
    if (reviewFinished) {
      return (
        <div>
          <header className="BlankSpace"></header>
          <h1 className="Question">Your final score is {finalScore}</h1>
          <button className="FinalButton" onClick={() => {}}></button>
        </div>
      );
    } else if (finished) {
      if (clickedToSeeAns) {
        return (
          <div>
            <header className="BlankSpace"></header>
            <h1 className="Question">{questionText}</h1>
            <Answer
              isCorrect={answers[questionId - 1]["score"]}
              specificFeedback={answers[questionId - 1]["specificFeedback"]}
              generalFeedback={answers[questionId - 1]["generalFeedback"]}
            />
            <button
              className="FinishButton"
              onClick={() => handleFinish()}
            ></button>
          </div>
        );
      }

      return (
        <div>
          <header className="BlankSpace"></header>
          <h1 className="Question">{questionText}</h1>
          <button
            className="ReviewButton"
            onClick={() => handleFinish()}
          ></button>
        </div>
      );
    }

    return (
      <div>
        <header className="BlankSpace"></header>
        <h1 className="Question">{questionText}</h1>
        <Choices handleClick={handleChoiceClick} choices={choices} />
      </div>
    );
  }
};

export default Question;
