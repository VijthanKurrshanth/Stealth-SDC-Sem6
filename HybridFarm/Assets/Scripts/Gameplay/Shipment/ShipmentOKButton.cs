using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipmentOKButton : MonoBehaviour
{
    public GameObject ShipmentMenuPrefabs;
    public Button shipmentOkButton; 

    AllButtonDisableEnabler allButtonDisableEnabler;
    TruckController2D truckController2D;
    ShipmentTransactions shipmentTransactions;

    void Start()
    {
        allButtonDisableEnabler = FindObjectOfType<AllButtonDisableEnabler>();
        truckController2D = FindObjectOfType<TruckController2D>();
        shipmentTransactions = FindObjectOfType<ShipmentTransactions>();

        
        if (ShipmentMenuPrefabs != null)
        {
            ShipmentMenuPrefabs.SetActive(true);
        }

        UpdateButtonState();
    }

    // Update is called once per frame
    void Update()
    {
        
        UpdateButtonState();
    }

   
    public void OnButtonClick()
    {
        shipmentTransactions.OkisPressed = true;   // to successfully pass the transaction
        // Continue the game
        Time.timeScale = 1;
        allButtonDisableEnabler.EnableAllButtons();
        truckController2D.vehicleisPressed = false;

        if (ShipmentMenuPrefabs != null)
        {
            ShipmentMenuPrefabs.SetActive(false);
        }
    }

    void UpdateButtonState()
    {
        if (shipmentTransactions.ReadyToShipMoney <= 0)
        {
            shipmentOkButton.interactable = false;
            shipmentOkButton.image.color = new Color(0.2f, 0.2f, 0.2f, 1f); // Dark color
        }
        else
        {
            shipmentOkButton.interactable = true;
            shipmentOkButton.image.color = new Color(1f, 1f, 1f, 1f); // White color
        }

    }
}
