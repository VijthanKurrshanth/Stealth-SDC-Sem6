using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryPurchaseButton : MonoBehaviour
{
    // Reference to MoneyScript
    private MoneyScript moneyScript;

    // Reference to the GameObject that represents the button
    public GameObject buttonGameObject;

    private string[] choosenFacotryArray;

    public string nameOfFactory;

    // Cost of the factory
    public int CostOfFactory = 100;


    void Start()
    {
        //to find money current value
        moneyScript = FindObjectOfType<MoneyScript>();

        // Set initial state of the button
        if (buttonGameObject != null)
        {
            buttonGameObject.SetActive(false);
        }
    }

    void Update()
    {
        
        // Check if money value is sufficient to enable the button
        if (moneyScript != null && buttonGameObject != null)
        {
            if (moneyScript.moneyValue >= CostOfFactory)
            {
                buttonGameObject.SetActive(true);
            }
            else
            {
                buttonGameObject.SetActive(false);
            }
        }
    }
}
