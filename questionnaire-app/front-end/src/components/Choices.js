import "../styles/Choices.css";

const Choices = ({ handleClick, choices }) => {
  return (
    <div className="Choices">
      <button className="Choice" onClick={() => handleClick(1)}>
        {choices[0]}
      </button>
      <button className="Choice" onClick={() => handleClick(2)}>
        {choices[1]}
      </button>
      <button className="Choice" onClick={() => handleClick(3)}>
        {choices[2]}
      </button>
      <button className="Choice" onClick={() => handleClick(4)}>
        {choices[3]}
      </button>
    </div>
  );
};

export default Choices;
