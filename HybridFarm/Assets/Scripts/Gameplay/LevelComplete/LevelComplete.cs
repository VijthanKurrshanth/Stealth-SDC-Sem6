using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    private bool isPaused = false;
    private bool isLevelCompleted = false;
    ObjectiveFigure objectiveFigure;

    public GameObject LevelResultBoard;

    public TextMeshProUGUI timerText; // Reference to the TextMeshProUGUI component to display the timer

    public TextMeshProUGUI LevelTimeText;

    public TextMeshProUGUI LevelScoreText;

    // private bool Level1completed =false ;
    // private bool Level2completed =false ;
    // private bool Level3completed =false ;
    //public GameObject TimerInObjectiveBoard;

    //public GameObject ResultBoxTimerObjectToDisplay;

    //private Timer timer;
    

    void Start()
    {
        objectiveFigure = FindObjectOfType<ObjectiveFigure>();
        //timer = TimerInObjectiveBoard.GetComponent<Timer>();
    }

    void Update()
    {

        
        // we should attach this script to an visible empty object beacuse the attach board will hidden initially.

        if (objectiveFigure.inIndexPostioninObjectiveItems[0]<13 &objectiveFigure.inIndexPostioninObjectiveItems[1]<13 & objectiveFigure.inIndexPostioninObjectiveItems[2]<13)
        {
            
            if (objectiveFigure.Green_Correct_Indicators[0]==true & objectiveFigure.Green_Correct_Indicators[1]==true & objectiveFigure.Green_Correct_Indicators[2]==true)
            {
                isLevelCompleted =true;
            }

            else 
            {
                isLevelCompleted =false;
            }

        }


        else if (objectiveFigure.inIndexPostioninObjectiveItems[0]<13 &objectiveFigure.inIndexPostioninObjectiveItems[1]<13 )
        {

            //Debug.Log(objectiveFigure.Green_Correct_Indicators[0]);
           
            if (objectiveFigure.Green_Correct_Indicators[0]==true & objectiveFigure.Green_Correct_Indicators[1]==true  )
            {
                
                isLevelCompleted =true;
            }

            else 
            {
                
                isLevelCompleted =false;
            }

        }

        else if (objectiveFigure.inIndexPostioninObjectiveItems[0]<13 )
        {
            
            if (objectiveFigure.Green_Correct_Indicators[0]==true )
            {
                isLevelCompleted =true;
            }

            else 
            {
                isLevelCompleted =false;
            }

        }
    



        
        if (isLevelCompleted==true)
        {
            // Toggle pause state
            isPaused = !isPaused;

            // If game is paused, freeze time
            if (isPaused)
            {
                Time.timeScale = 0f; // Set time scale to zero to pause
                LevelResultBoard.SetActive(true);

                setScore();



                //Debug.Log("Level is Completed");
            }
            // else // If game is unpaused, resume time
            // {
            //     Time.timeScale = 2f; // Set time scale back to normal
            //     Debug.Log("Game unpaused");
            // }
        }

        else
        {
            LevelResultBoard.SetActive(false);
        }


    }

    void setScore()
    {
        string timeString = timerText.text; // Get the timer text
        string[] parts = timeString.Split(':'); // Step 1: Split the string
        int minutes = int.Parse(parts[0]); // Step 2: Convert minutes to integer
        int seconds = int.Parse(parts[1]); // Step 3: Convert seconds to integer
        int totalTimeInSeconds = (minutes * 60) + seconds; // Step 4: Calculate total time in seconds

        // Calculate score based on time

        int score = 300; // Basic score for completing the level
        int maxTimeInSeconds = 300; // Maximum time assumed for the level in seconds

        // Calculate score based on time
        float timePercentage = (float)totalTimeInSeconds / maxTimeInSeconds; // Calculate the percentage of time taken
        float scoreMultiplier = 1f - timePercentage; // Calculate the score multiplier based on the time percentage
        score += Mathf.RoundToInt(scoreMultiplier * 700); // Add the score multiplier to a maximum score attainable

        // Save the score
        int level = SceneManager.GetActiveScene().buildIndex - 5; // Get the level number based on the build index level 1 is 5, level 2 is 6, etc.
        int[] levelScores = LoadIntArray("LevelScores"); // Load the level scores from PlayerPrefs
        levelScores[level] = score; // Update the score for the current level
        SaveIntArray("LevelScores", levelScores); // Save the updated level scores to PlayerPrefs

        // Display and save the score
        LevelScoreText.text = score.ToString(); // Display the score on the UI
        LevelTimeText.text = timeString; // Display the time taken on the UI
       
    }

    // Method to save an array of integers
    public void SaveIntArray(string key, int[] array)
    {
        // Convert array of integers to a single string, separated by commas
        string arrayString = string.Join(",", array);
        PlayerPrefs.SetString(key, arrayString);
        PlayerPrefs.Save(); // Make sure to save PlayerPrefs changes
    }

    // Method to load an array of integers
    public int[] LoadIntArray(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            // Retrieve the string from PlayerPrefs
            string arrayString = PlayerPrefs.GetString(key);
            // Split the string into an array of strings
            string[] stringArray = arrayString.Split(',');
            // Convert each string in the array to an integer
            int[] intArray = new int[stringArray.Length];
            for (int i = 0; i < stringArray.Length; i++)
            {
                intArray[i] = int.Parse(stringArray[i]);
            }
            return intArray;
        }
        else
        {
            // Return an empty array if the key does not exist
            return new int[15];
        }
    }

}







// below is code from chatgpt


// using UnityEngine;

// public class PauseGame : MonoBehaviour
// {
//     private bool isPaused = false;

//     void Update()
//     {
//         // Check if the 'P' key is pressed
//         if (Input.GetKeyDown(KeyCode.P))
//         {
//             // Toggle pause state
//             isPaused = !isPaused;

//             // If game is paused, freeze time
//             if (isPaused)
//             {
//                 Time.timeScale = 0f; // Set time scale to zero to pause
//                 Debug.Log("Game paused");
//             }
//             else // If game is unpaused, resume time
//             {
//                 Time.timeScale = 1f; // Set time scale back to normal
//                 Debug.Log("Game unpaused");
//             }
//         }
//     }
// }