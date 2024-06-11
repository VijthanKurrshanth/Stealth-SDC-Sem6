using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COkButton : MonoBehaviour
{
    // Reference to the pause menu UI object
    public GameObject ShipmentMenu;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);

        // Ensure the pause menu is initially  visible
        if (ShipmentMenu != null)
        {
            ShipmentMenu.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method to be called when the continue button is clicked
    public void OnOKButtonClick()
    {
        // Continue the game
        Time.timeScale = 1;
        gameObject.SetActive(false);

        // Hide the pause menu
        if (ShipmentMenu != null)
        {
            ShipmentMenu.SetActive(false);
        }
    }
}

