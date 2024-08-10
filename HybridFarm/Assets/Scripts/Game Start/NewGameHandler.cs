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

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CheckPlayerExists()
    {
        yield return new WaitForSeconds(0.1f);
        if (PlayerPrefs.GetInt("playerExists") == 1)
        {
            Debug.Log("Player exists");
            continueButton.SetActive(true);
        }
        else
        {
            Debug.Log("Player does not exist");
            PlayerPrefs.SetInt("playerExists", 0);
            continueButtonMask.SetActive(true);
            continueButton.SetActive(false);
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
        int currentLevel = PlayerPrefs.GetInt("currentLevel", 1);
        //StartCoroutine(LoadingScreen(currentLevel + 4)); // Load the level scene based on the build index, level 1 is 5, level 2 is 6, etc. 
        Time.timeScale = 1;
        SceneManager.LoadScene(currentLevel + 4);
        Time.timeScale = 1;
    }

    public void OnConfirmButtonClicked()
    {
        string leaderBoardLastChecked = PlayerPrefs.GetString("LastCheckedTime");
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("playerExists", 0);
        PlayerPrefs.SetString("LastCheckedTime", leaderBoardLastChecked);
        SceneManager.LoadScene("7.UserProfile");
    }

    public void OnCloseButtonClicked()
    {
        warningPanel.SetActive(false);
    }

    IEnumerator LoadingScreen(int index)
    {
        // loadingScreen.SetActive(true);
        // yield return new WaitForSeconds(1f);
        // loadingScreen.SetActive(false);
        SceneManager.LoadScene(index);
        yield return null;
    }

    public void OnTestButtonClicked()
    {

    }
}
