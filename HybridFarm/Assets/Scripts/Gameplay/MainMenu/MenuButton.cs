using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    // Reference to the pause menu UI object
    public GameObject pauseMenu;

    AllButtonDisableEnabler allButtonDisableEnabler;

    // Start is called before the first frame update
    void Start()
    {
        allButtonDisableEnabler =  FindObjectOfType<AllButtonDisableEnabler>();
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
        allButtonDisableEnabler.DisableAllButtons();
        //allButtonDisableEnabler.EnableChildButtons(pauseMenu);

        // Display the pause menu
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
        }
    }



    // private void DisableAllButtons()
    // {
    //     // Find all button components in the scene and disable them
    //     Button[] buttons = FindObjectsOfType<Button>();
    //     foreach (Button button in buttons)
    //     {
    //         button.interactable = false;
    //     }
    // }

    // private void EnableAllButtons()
    // {
    //     // Find all button components in the scene and enable them
    //     Button[] buttons = FindObjectsOfType<Button>();
    //     foreach (Button button in buttons)
    //     {
    //         button.interactable = true;
    //     }
    // }
}
