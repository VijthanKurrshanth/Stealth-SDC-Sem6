using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oneButton : MonoBehaviour
{
    public Button AttachButton; 

    
    public int keyNo = -1; 

    ShipmentTransactions shipmentTransactions ;
    ShipmentController shipmentController;

    
    void Start()
    {
        shipmentController = FindObjectOfType<ShipmentController>();
        shipmentTransactions = FindObjectOfType<ShipmentTransactions>();
        
        AttachButton.onClick.AddListener(OnButtonClick);
    }

    
    void Update()
    {
        
        
    }

    
    void OnButtonClick()
    {
        shipmentController.clearShipmentMenu();
        shipmentController.displayItemsONShipmentMenu();
        //shipmentController.ClearDisplayedTexts() ;
        shipmentController.count=0;
        //Debug.Log("One is pressed");
        shipmentTransactions.key = keyNo;
        //Debug.Log("Button clicked, key assigned to 1");
    }
}
