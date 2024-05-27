using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    // Reference to the pause menu UI object
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the pause menu is initially not visible
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method to be called when the menu button is clicked
    public void OnMenuButtonClick()
    {
        // Pause the game
        Time.timeScale = 0;

        // Display the pause menu
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
        }
    }
}

