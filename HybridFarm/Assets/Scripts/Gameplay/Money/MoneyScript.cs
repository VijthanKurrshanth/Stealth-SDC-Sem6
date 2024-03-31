using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // This is required for using UI elements
using TMPro;

public class MoneyScript : MonoBehaviour
{
    public int moneyValue = 0; // Variable to hold the money value
    public TextMeshProUGUI moneyText; // Reference to the UI text element to display the money value

    // Start is called before the first frame update
    void Start()
    {
        moneyText = FindObjectOfType<TextMeshProUGUI>();
        moneyValue = 100;
        UpdateMoneyText(); // Call the function to update the money text when the game starts
        
    }

    // Update is called once per frame
    void Update()
    {
        // Example: Increase money value by 1 every frame (you should implement your own logic)
        // moneyValue += 1;
        if (moneyValue < 0)
        {
            moneyValue = 0;
        }
        
        UpdateMoneyText(); // Call the function to update the money text when money value changes
    }

    void UpdateMoneyText()
    {
        moneyText.fontStyle = FontStyles.Bold;
        moneyText.fontSize = 50;
        moneyText.text = moneyValue.ToString();

    
    }


    int getMoneyValue()
    {
        return moneyValue;
    }
}
