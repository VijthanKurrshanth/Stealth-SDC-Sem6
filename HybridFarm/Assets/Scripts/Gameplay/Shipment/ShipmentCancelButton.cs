using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipmentCancelButton : MonoBehaviour
{

    public GameObject ShipmentMenuPrefabs;
    AllButtonDisableEnabler allButtonDisableEnabler;

    // Start is called before the first frame update
    void Start()
    {
        allButtonDisableEnabler =  FindObjectOfType<AllButtonDisableEnabler>();
        // Ensure the pause menu is initially  visible
        if (ShipmentMenuPrefabs != null)
        {
            ShipmentMenuPrefabs.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method to be called when the continue button is clicked
    public void OnButtonClick()
    {
        // Continue the game
        Time.timeScale = 1;
        allButtonDisableEnabler.EnableAllButtons();

        
        if (ShipmentMenuPrefabs != null)
        {
            ShipmentMenuPrefabs.SetActive(false);
        }
    }
}

