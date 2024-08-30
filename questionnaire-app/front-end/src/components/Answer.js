import "../styles/Answer.css";

const ChangeColorIfWrong = ({ isCorrect, specificFeedback }) => {
  const className = isCorrect === "INCORRECT" ? "Wrong" : "Correct";

  return <div className={className}>{specificFeedback}</div>;
};

const Answer = ({ isCorrect, specificFeedback, generalFeedback }) => {
  return (
    <div className="AnswerBlock">
      <ChangeColorIfWrong
        isCorrect={isCorrect}
        specificFeedback={specificFeedback}
      />
      <p className="Body">
        <div className="Answer">{generalFeedback}</div>
      </p>
    </div>
  );
};

export default Answer;
