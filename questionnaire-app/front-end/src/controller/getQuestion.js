const getQuestion = (questionId) => {
  const url = process.env.BACKEND_BASE_URL;
  return fetch(url).then((res) => res.json());
};

export default getQuestion;
