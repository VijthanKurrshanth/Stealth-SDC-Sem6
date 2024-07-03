using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipmentCancelButton : MonoBehaviour
{

    public GameObject ShipmentMenuPrefabs;
    AllButtonDisableEnabler allButtonDisableEnabler;

    TruckController2D truckController2D;

    public bool ShipmentCancelisPressed =false;

    // Start is called before the first frame update
    void Start()
    {
        allButtonDisableEnabler =  FindObjectOfType<AllButtonDisableEnabler>();
        truckController2D = FindObjectOfType<TruckController2D>();
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
        ShipmentCancelisPressed =true;   // to disable all transaction 
        // Continue the game
        Time.timeScale = 1;
        allButtonDisableEnabler.EnableAllButtons();
        truckController2D.vehicleisPressed =false;

        
        if (ShipmentMenuPrefabs != null)
        {
            ShipmentMenuPrefabs.SetActive(false);
        }
    }
}

