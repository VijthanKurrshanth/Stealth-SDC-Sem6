using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    // Reference to the pause menu UI object
    public GameObject pauseMenu;
    AllButtonDisableEnabler allButtonDisableEnabler;

    // Start is called before the first frame update
    void Start()
    {
        allButtonDisableEnabler =  FindObjectOfType<AllButtonDisableEnabler>();
        // Ensure the pause menu is initially  visible
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
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
        Time.timeScale = 1;
        allButtonDisableEnabler.EnableAllButtons();

        // Hide the pause menu
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
    }
}
