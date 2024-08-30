using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelStartButton : MonoBehaviour
{
    
    public void LoadScene (String sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }

}
