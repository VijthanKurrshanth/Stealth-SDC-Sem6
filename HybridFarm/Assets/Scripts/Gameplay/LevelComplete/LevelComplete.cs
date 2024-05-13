using System.Collections;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    private bool isPaused = false;
    private bool isLevelCompleted = false;
    ObjectiveFigure objectiveFigure;

    public GameObject LevelResultBoard;

    void Start()
    {
        objectiveFigure = FindObjectOfType<ObjectiveFigure>();
    }

    void Update()
    {

        
        // we should attach this scrtipt a an visible empty object beacuse the attach board will hidden initially.

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
                Debug.Log("Level is Completed");
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