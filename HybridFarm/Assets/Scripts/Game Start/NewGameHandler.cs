using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameHandler : MonoBehaviour
{
    public GameObject continueButton;
    public GameObject continueButtonMask;
    public GameObject warningPanel;
    public GameObject attackAlgorithm;
    public GameObject loadingScreen;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckPlayerExists());
    }

    // This method is used to check if the player exists
    IEnumerator CheckPlayerExists()
    {
        yield return new WaitForSeconds(0.1f);
        if (PlayerPrefs.GetInt("playerExists") == 1)
        {
            Debug.Log("Player exists");
            continueButton.SetActive(true); // Show the continue button
        }
        else
        {
            Debug.Log("Player does not exist");
            PlayerPrefs.SetInt("playerExists", 0);
            continueButtonMask.SetActive(true); // Mask the continue button
            continueButton.SetActive(false); // Hide the continue button
        }
    }

    public void OnNewGameButtonClicked()
    {
        if (PlayerPrefs.GetInt("playerExists") == 1)
        {
            warningPanel.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("playerExists", 0);
            SceneManager.LoadScene("7.UserProfile");
        }
    }

    public void OnContinueButtonClicked()
    {
        StartCoroutine(LoadingScreen());
    }

    public void OnConfirmButtonClicked()
    {
        PlayerPrefs.SetInt("playerExists", 0);
        PlayerPrefs.SetInt("playerBoostPoints", 0);
        SceneManager.LoadScene("7.UserProfile");
    }

    public void OnCloseButtonClicked()
    {
        warningPanel.SetActive(false);
    }

    IEnumerator LoadingScreen()
    {
        loadingScreen.SetActive(true);
        while (attackAlgorithm.GetComponent<AttackAlgorithm>().GetAttackInterval() == 0)
        {
            yield return new WaitForSeconds(1f);
        }
        loadingScreen.SetActive(false);
        SceneManager.LoadScene("4.GameplayEnvironment");
    }
}
