using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public GameObject attackAlgorithm;
    public GameObject loadingScreen;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnLevelButtonClicked(string level)
    {
        StartCoroutine(LoadingScreen(level));
    }

    IEnumerator LoadingScreen(string level)
    {
        loadingScreen.SetActive(true);
        yield return StartCoroutine(attackAlgorithm.GetComponent<AttackAlgorithm>().GetAttackInterval((attackInterval) =>
       {
           loadingScreen.SetActive(false);
           SceneManager.LoadScene(level);
       }));
    }
}
