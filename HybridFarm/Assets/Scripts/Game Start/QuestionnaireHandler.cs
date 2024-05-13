using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionnaireHandler : MonoBehaviour
{
    public GameObject waitingPanel;
    public TextMeshProUGUI waitingText;
    public bool finished = false;

    public void OnSaveButtonClick()
    {
        if (PlayerPrefs.GetInt("playerExists") == 0)
        {
            waitingPanel.SetActive(true); // Show the waiting panel while the questionnaire is being done
        }
    }

    public void OnCloseWaitButtonClick()
    {
        StartCoroutine(ApiController.GetScore((score) =>
        {
            if (score == -1)
            {
                waitingText.text = "Please finish the questionnaire";
            }
            else if (score == -2)
            {
                waitingText.text = "Connection Issue";
            }
            else
            {
                if (!finished)
                {
                    waitingText.text = $"Your score is: {score} \n Press close button again.";
                    PlayerPrefs.SetInt("playerBoostPoints", score);
                    finished = true;
                }
                else
                {
                    finished = false;
                    waitingPanel.SetActive(false); // Hide the waiting panel
                    SceneManager.LoadScene("4.GameplayEnvironment");
                }
            }
        }));
    }
}
