using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO.Compression;
using UnityEngine.Rendering;
using System.Runtime.CompilerServices;

public class FactoryPriceHandler : MonoBehaviour
{
    // Start is called before the first frame update

    private TextMeshProUGUI priceText;
    public int FactoryPrice = 200;

    public string nameOfFactory ;
    private int currentFactoryLevel;
    

    private string[] factoryLevels;

    private int[][] allFactoryLevelsCost =null;

    private int[] eggPowderfactoryLevelsCost;
    
    private int[] cakefactoryLevelsCost;
    
    private int[] meatcutterfactoryLevelsCost;
    
    private int[] sausagefactoryLevelsCost;
    
    private int[] curdfactoryLevelsCost;
    
    private int[] cheesefactoryLevelsCost;


    Objective objective;
    
    void Start()
    {

        objective = FindObjectOfType<Objective>();


        priceText = GetComponent<TextMeshProUGUI>(); // Get the TextMeshProUGUI component.
        if (priceText == null)
        {
            //Debug.LogError("requires a TextMeshProUGUI component .");
            return;
        }

        string[] factoryNames= new string [] {"EggPowderFactory","CakeFactory","MeatCutterFactory","SausagesFactory","CurdFactory","CheeseFactory"};

        int indexOfFactoryAssigned =0;
        for (int i = 0; i<=5 ;i++)
        {
            if (nameOfFactory == factoryNames[i])
            {
                indexOfFactoryAssigned = i;
            }
        }

        // indexOF factory have which factory the script was assigned to...

        currentFactoryLevel = objective.factoryNamesLevels[indexOfFactoryAssigned]; //this has factory and initial level.

        
        
        
   
        
        factoryLevels = new string[] {"level1","level2", "level3","level4fuel","level4electric","level5fuel","level5electric"};
        eggPowderfactoryLevelsCost = new int[] {150,250,350,450,500,550,600};
        cakefactoryLevelsCost = new int[] {200,300,400,500,550,600,650};
        meatcutterfactoryLevelsCost = new int[] {1500,2500,3500,4500,5000,5500,6000};
        sausagefactoryLevelsCost = new int[] {2000,3000,4000,4500,5500,6000,6500};
        curdfactoryLevelsCost = new int[] {10000,12500,15000,17500,20000,22500,25000};
        cheesefactoryLevelsCost = new int[] {12500,15000,17500,20000,22500,25000,27500};

        // allFactoryLevelsCost[0]= eggPowderfactoryLevelsCost;
        // allFactoryLevelsCost[1]= cakefactoryLevelsCost;
        // allFactoryLevelsCost[2]= meatcutterfactoryLevelsCost;
        // allFactoryLevelsCost[3]= sausagefactoryLevelsCost;
        // allFactoryLevelsCost[4]= curdfactoryLevelsCost;
        // allFactoryLevelsCost[5]= cheesefactoryLevelsCost;



       // currentFactory= null;

        UpdatePriceText(); // Call the function to update the money text when the game starts



        
    }

    // Update is called once per frame
    void Update()
    {


        //currentFactory = factoryLevels[2];
        //int factoryIndex = Array.IndexOf(factoryLevels, currentFactoryLevel);

        
        
        FactoryPrice = eggPowderfactoryLevelsCost[currentFactoryLevel];

        
      


        
        
        UpdatePriceText(); // Call the function to update the money text when money value changes


        
    }

void UpdatePriceText()
    {
        priceText.fontStyle = FontStyles.Bold;
        priceText.fontSize = 18;
        priceText.text = FactoryPrice.ToString();

    
    }




}
