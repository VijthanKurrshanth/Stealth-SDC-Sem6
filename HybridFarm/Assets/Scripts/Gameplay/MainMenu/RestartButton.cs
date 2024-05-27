using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    // Reference to the pause menu UI object
    
    public GameObject ensureBoard;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the ensure board is initially  visible

        if (ensureBoard != null)
        {
            ensureBoard.SetActive(false); //ensureBoard not prepared
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method to be called when the continue button is clicked
    public void OnContinueButtonClick()
    {
        // Continue the game
        Time.timeScale = 0;

        // Hide the pause menu
        if (ensureBoard != null)
        {
            ensureBoard.SetActive(false);
        }
    }



}












// }
//     // Method to be called when the restart button is clicked
//     public void OnRestartButtonClick()
//     {
//         // Reset the time scale to 1 in case the game was paused
//         Time.timeScale = 1;

//         // Reload the current scene
//         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//     }
// }
