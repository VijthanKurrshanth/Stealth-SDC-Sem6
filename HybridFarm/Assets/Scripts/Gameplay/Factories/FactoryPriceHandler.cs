using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO.Compression;

public class FactoryPriceHandler : MonoBehaviour
{
    // Start is called before the first frame update

    private TextMeshProUGUI priceText;
    public int FactoryPrice = 200;

    private string[] factoryLevels;
    private int[] factoryLevelsCost;
    private string currentFactory;
    void Start()
    {
        priceText = GetComponent<TextMeshProUGUI>(); // Get the TextMeshProUGUI component attached to the same GameObject
        if (priceText == null)
        {
            //Debug.LogError("requires a TextMeshProUGUI component attached to the same GameObject.");
            return;
        }

        factoryLevels = new string[] {"level1","level2", "level3fuel", "level3electric","level4fuel","level4electric","level5fuel","level5electric"};
        factoryLevelsCost = new int[] {150,250,350,400,450,500,550,600};
        currentFactory= null;

        UpdatePriceText(); // Call the function to update the money text when the game starts



        
    }

    // Update is called once per frame
    void Update()
    {

        currentFactory = factoryLevels[2];
        int factoryIndex = Array.IndexOf(factoryLevels, currentFactory);

        if (factoryIndex + 1 <= 8)
        {
        FactoryPrice = factoryLevelsCost[factoryIndex+1];
        }
        else
        {
         // remove buy button 
        }


        
        
        UpdatePriceText(); // Call the function to update the money text when money value changes


        
    }

void UpdatePriceText()
    {
        priceText.fontStyle = FontStyles.Bold;
        priceText.fontSize = 18;
        priceText.text = FactoryPrice.ToString();

    
    }




}
