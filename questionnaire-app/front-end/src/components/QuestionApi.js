const baseUrl = process.env.REACT_APP_BACKEND_BASE_URL;

function translateStatusToErrorMessage(status) {
  switch (status) {
    case 401:
      return "Authentication Failed";
    case 403:
      return "You do not have authority to view the request.";
    default:
      return "There was an error retrieving the request. Please try again.";
  }
}

function checkStatus(response) {
  if (response.ok) {
    return response;
  } else {
    const httpErrorInfo = {
      status: response.status,
      statusText: response.statusText,
      url: response.url,
    };
    console.log(
      `logging http details for debugging: ${JSON.stringify(httpErrorInfo)}`
    );

    let errorMessage = translateStatusToErrorMessage(httpErrorInfo.status);
    throw new Error(errorMessage);
  }
}

function parseJSON(response) {
  return response.json();
}

function delay(ms) {
  return function (x) {
    return new Promise((resolve) => setTimeout(() => resolve(x), ms));
  };
}

const QuestionAPI = {
  getQuestion(questionId) {
    return fetch(baseUrl + "/" + questionId)
      .then(delay(100))
      .then(checkStatus)
      .then(parseJSON)
      .catch((error) => {
        let errorMessage = translateStatusToErrorMessage(error);
        throw new Error(errorMessage);
      });
  },

  postAnswer(questionId, choice) {
    const choiceId = (questionId - 1) * 4 + choice;
    return fetch(baseUrl + "/" + questionId + "?Answer-Id=" + choiceId, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
    })
      .then((response) => {
        console.log(response);
        return response;
      })
      .then((response) => {
        if (!response.ok) throw new Error(response.statusText);
        return response;
      })
      .then((response) => console.log("Success"))
      .catch((error) => console.error("Error:", error));
  },

  getAnswers() {
    return fetch(baseUrl)
      .then(checkStatus)
      .then(parseJSON)
      .catch((error) => {
        let errorMessage = translateStatusToErrorMessage(error);
        throw new Error(errorMessage);
      });
  },

  getFinalScore() {
    return fetch(baseUrl + "/score")
      .then(checkStatus)
      .then(parseJSON)
      .catch((error) => {
        let errorMessage = translateStatusToErrorMessage(error);
        throw new Error(errorMessage);
      });
  },
};

export default QuestionAPI;
