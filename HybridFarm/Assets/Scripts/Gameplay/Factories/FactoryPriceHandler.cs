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
    private int FactoryPrice = 200;

    public string nameOfFactory ;
    private int currentFactoryLevel;

    //public bool electric = false;
    

    private string[] factoryLevels;

    private int[][] allFactoryLevelsCost =null;

    public int[] eggPowderfactoryLevelsCost;
    
    public int[] cakefactoryLevelsCost;
    
    public int[] meatcutterfactoryLevelsCost;
    
    public int[] sausagefactoryLevelsCost;
    
    public int[] curdfactoryLevelsCost;
    
    public int[] cheesefactoryLevelsCost;


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


        
    
        //factoryLevels = new string[] {"level1fuel","level1electric","level2fuel","level2electic", "level3fuel","level3electric","level4fuel","level4electric","level5fuel","level5electric"};
        eggPowderfactoryLevelsCost = new int[] {150,200,250,300,350,400,450,500,550,600};
        cakefactoryLevelsCost = new int[] {200,250,300,350,400,450,500,550,600,650};
        meatcutterfactoryLevelsCost = new int[] {1500,2000,2500,3000,3500,4000,4500,5000,5500,6000};
        sausagefactoryLevelsCost = new int[] {2000,2500,3000,3500,4000,4500,5000,5500,6000,6500};
        curdfactoryLevelsCost = new int[] {10000,11000,12500,13500,15000,16000,17500,20000,22500,25000};
        cheesefactoryLevelsCost = new int[] {12500,13500,15000,16000,17500,18500,20000,22500,25000,27500};

        //allFactoryLevelsCost[0]= eggPowderfactoryLevelsCost;
        //allFactoryLevelsCost[1]= cakefactoryLevelsCost;
        //allFactoryLevelsCost[2]= meatcutterfactoryLevelsCost;
        //allFactoryLevelsCost[3]= sausagefactoryLevelsCost;
        //allFactoryLevelsCost[4]= curdfactoryLevelsCost;
        //allFactoryLevelsCost[5]= cheesefactoryLevelsCost;



       // currentFactory= null;

        UpdatePriceText(); // Call the function to update the money text when the game starts



        
    }

    // Update is called once per frame
    void Update()
    {

        priceText.raycastTarget = false;
        string[] factoryNames= new string [] {"EggPowderFactoryFuel","EggPowderFactoryElectric","CakeFactoryFuel","CakeFactoryElectric","MeatCutterFactoryFuel","MeatCutterFactoryElectric","SausagesFactoryFuel","SausagesFactoryElectric","CurdFactory","CurdFactoryFuel","CheeseFactoryFuel","CheeseFactoryElectric"};

        int indexOfFactoryAssigned =0;
        for (int i = 0; i<=11 ;i++)   // 9 ->11
        {
            if (nameOfFactory == factoryNames[i])
            {
                indexOfFactoryAssigned = i;
            }
        }

        //Debug.Log("" + indexOfFactoryAssigned);

        // indexOF factory have which factory the script was assigned to...

        //currentFactoryLevel = objective.factoryNamesLevels[indexOfFactoryAssigned]; //this has factory and initial level.
       


        //currentFactory = factoryLevels[2];
        //int factoryIndex = Array.IndexOf(factoryLevels, currentFactoryLevel);

        
        if (indexOfFactoryAssigned ==0 || indexOfFactoryAssigned==1)
        {
            if (indexOfFactoryAssigned % 2 == 1)
            {
                FactoryPrice = eggPowderfactoryLevelsCost[currentFactoryLevel+1];
            }
            else 
            {
                FactoryPrice = eggPowderfactoryLevelsCost[currentFactoryLevel];
            }

        }

        else if (indexOfFactoryAssigned ==2 || indexOfFactoryAssigned==3)
        {
            if (indexOfFactoryAssigned % 2 == 1)
            {
                FactoryPrice = cakefactoryLevelsCost[currentFactoryLevel+1];
            }
            else 
            {
                FactoryPrice = cakefactoryLevelsCost[currentFactoryLevel];
            }
            
            
        }


        else if (indexOfFactoryAssigned ==4 || indexOfFactoryAssigned==5)
        {
            if (indexOfFactoryAssigned % 2 == 1)
            {
                FactoryPrice = meatcutterfactoryLevelsCost[currentFactoryLevel+1];
            }
            else 
            {
                FactoryPrice = meatcutterfactoryLevelsCost[currentFactoryLevel];
            }
            
            
        }


        else if (indexOfFactoryAssigned ==6 || indexOfFactoryAssigned==7)
        {
            if (indexOfFactoryAssigned % 2 == 1)
            {
                FactoryPrice = sausagefactoryLevelsCost[currentFactoryLevel+1];
            }
            else 
            {
                FactoryPrice = sausagefactoryLevelsCost[currentFactoryLevel];
            }
            
            
        }



        else if (indexOfFactoryAssigned ==8 || indexOfFactoryAssigned==9)
        {
            if (indexOfFactoryAssigned % 2 == 1)
            {
                FactoryPrice = curdfactoryLevelsCost[currentFactoryLevel+1];
            }
            else 
            {
                FactoryPrice = curdfactoryLevelsCost[currentFactoryLevel];
            }
            
            
        }



        else if (indexOfFactoryAssigned ==10 || indexOfFactoryAssigned==11)
        {
            if (indexOfFactoryAssigned % 2 == 1)
            {
                FactoryPrice = cheesefactoryLevelsCost[currentFactoryLevel+1];
            }
            else 
            {
                FactoryPrice = cheesefactoryLevelsCost[currentFactoryLevel];
            }
            
            
        }
        

        else 
        {
            Debug.Log("Not Assigned Factory");
        }

        
        

        
      


        
        
        UpdatePriceText(); // Call the function to update the money text when money value changes


        
    }

void UpdatePriceText()
    {
        priceText.fontStyle = FontStyles.Bold;
        priceText.fontSize = 18;
        priceText.text = FactoryPrice.ToString();
        priceText.color = Color.white; 


    
    }




}
