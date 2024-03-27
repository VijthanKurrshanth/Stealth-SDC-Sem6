import "../styles/Answer.css";

const ChangeColorIfWrong = ({ isCorrect }) => {
  const className = isCorrect === "INCORRECT" ? "Wrong" : "Correct";

  return <div className={className}>Your answer is: {isCorrect}</div>;
};

const Answer = ({ isCorrect, yourAnswer, correctAnswer }) => {
  return (
    <div className="AnswerBlock">
      <ChangeColorIfWrong isCorrect={isCorrect} />
      <p className="Body">
        You chose : <div className="Answer">{yourAnswer}</div>
      </p>
      <p className="Body">
        Correct answer is : <div className="Answer">{correctAnswer}</div>
      </p>
    </div>
  );
};

export default Answer;
