using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveScore : MonoBehaviour
{
    public GameObject levelComplete;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnOkButtonClicked()
    {
        int playerScore = PlayerPrefs.GetInt("PlayerScore"); // Get the previous score from PlayerPrefs
        Debug.Log("Player Score: " + playerScore); // Log the player score
        int[] levelScores = levelComplete.GetComponent<LevelComplete>().LoadIntArray("LevelScores"); // Load the level scores from PlayerPrefs
        int sum = 0;
        foreach (int score in levelScores)
        {
            sum += score;
        }
        Debug.Log("Sum of Level Scores: " + sum);
        playerScore = sum; // Update the player score with the sum of level scores
        PlayerPrefs.SetInt("PlayerScore", playerScore); // Save the updated score to PlayerPrefs

        int level = SceneManager.GetActiveScene().buildIndex - 4; // Get the level number based on the build index level 1 is 5, level 2 is 6, etc.
        PlayerPrefs.SetInt("currentLevel", level); // Set the current level to next level
        PlayerPrefs.Save(); // Save the PlayerPrefs data
        Debug.Log("Player Score: " + PlayerPrefs.GetInt("PlayerScore")); // Log the player score
    }
}
