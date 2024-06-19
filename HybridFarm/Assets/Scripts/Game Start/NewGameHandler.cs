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
        StartCoroutine(LoadingScreen());
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

    IEnumerator LoadingScreen()
    {
        loadingScreen.SetActive(true);
        yield return StartCoroutine(attackAlgorithm.GetComponent<AttackAlgorithm>().GetAttackInterval((attackInterval) =>
        {
            loadingScreen.SetActive(false);
            SceneManager.LoadScene("1. Level_1");
        }));
    }

    public void OnTestButtonClicked()
    {
        // List<int> array = attackAlgorithm.GetComponent<AttackAlgorithm>().GetPredatorArray(0.05f);
        // PrintList(array);

        // void PrintList(List<int> list)
        // {
        //     foreach (int num in list)
        //     {
        //         Debug.Log(num);
        //     }
        // }
        //PlayerPrefs.SetString("currentConsumption", "348091.79162336694");
        //StartCoroutine(attackAlgorithm.GetComponent<AttackAlgorithm>().SendPredatorAttack());
    }
}
