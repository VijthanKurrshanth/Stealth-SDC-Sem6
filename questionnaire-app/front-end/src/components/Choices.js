import "../styles/Choices.css";

import choiceBoard from "../images/choices-background.png";

const Choices = () => {
  return (
    <div className="Container">
      <img
        src={choiceBoard}
        alt="background for choices"
        className="ChoiceBoardImg"
      />
      <div className="Choices">
        <button className="Choice">
          Choice 1 Choice 1 Choice 1 Choice 1 Choice 1 Choice 1 Choice 1 Choice
          1
        </button>
        <button className="Choice">
          Choice 2 Choice 2 Choice 2 Choice 2 Choice 2 Choice 2 Choice 2 Choice
          2
        </button>
        <button className="Choice">
          Choice 3 Choice 3 Choice 3 Choice 3 Choice 3 Choice 3 Choice 3 Choice
          3
        </button>
        <button className="Choice">
          Choice 4 Choice 4 Choice 4 Choice 4 Choice 4 Choice 4 Choice 4 Choice
          4
        </button>
      </div>
    </div>
  );
};

export default Choices;
