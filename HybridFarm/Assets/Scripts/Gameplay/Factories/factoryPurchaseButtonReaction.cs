using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryPurchaseButtonReaction : MonoBehaviour
{
    // Reference to MoneyScript
    private MoneyScript moneyScript;

    private FactoryPriceHandler factoryPriceHandler;

    private Objective objective;

    [SerializeField] string nameOfFactory;

    // Reference to the GameObject that represents the button
    public GameObject buttonGameObject;

    public int currentFactoryLevel=0;


    //private string[] choosenFacotryArray;

    //public string nameOfFactory;

    // Cost of the factory
    public int indexOfFactoryAssigned;
    public int CostOfFactory;
    //private bool isElectricFactory =  false;


    void Start()
    {
        
        moneyScript = FindObjectOfType<MoneyScript>();  //to find money current value
        factoryPriceHandler = FindObjectOfType<FactoryPriceHandler>();
        objective = FindObjectOfType<Objective>();

        
        if (buttonGameObject != null)
        {
            buttonGameObject.SetActive(false);
        }

        
    }

    void Update()
    {


        string[] factoryNames= new string [] {"EggPowderFactoryFuel","EggPowderFactoryElectric","CakeFactoryFuel","CakeFactoryElectric","MeatCutterFactoryFuel","MeatCutterFactoryElectric","SausagesFactoryFuel","SausagesFactoryElectric","CurdFactoryFuel","CurdFactoryElectric","CheeseFactoryFuel","CheeseFactoryElectric"};

        
        // to find which factory was assigned to this script.....
        //indexOfFactoryAssigned =0;
        for (int i = 0; i<=11 ;i++)
        {
            if (nameOfFactory == factoryNames[i])
            {
                indexOfFactoryAssigned = i; // i has index of factory script assigned...
            }
        }
        

        //currentFactoryLevel = objective.factoryNamesLevels[indexOfFactoryAssigned]; // get corrosponding current factory level from objective script.



        if (indexOfFactoryAssigned ==0 || indexOfFactoryAssigned==1)
        {
            if (indexOfFactoryAssigned % 2 == 1)
            {
                CostOfFactory = factoryPriceHandler.eggPowderfactoryLevelsCost[currentFactoryLevel+1]; //display factory price on upgrade board based on selected factory...
            }

            else
            {
                CostOfFactory = factoryPriceHandler.eggPowderfactoryLevelsCost[currentFactoryLevel];
            }
     
        }


        else if (indexOfFactoryAssigned ==2 || indexOfFactoryAssigned==3)
        {
            if (indexOfFactoryAssigned % 2 == 1)
            {
                CostOfFactory = factoryPriceHandler.cakefactoryLevelsCost[currentFactoryLevel+1]; //display factory price on upgrade board based on selected factory...
            }

            else
            {
                CostOfFactory = factoryPriceHandler.cakefactoryLevelsCost[currentFactoryLevel];
            }
     
        }

        
        else if (indexOfFactoryAssigned ==4 || indexOfFactoryAssigned==5)
        {
            if (indexOfFactoryAssigned % 2 == 1)
            {
                CostOfFactory = factoryPriceHandler.meatcutterfactoryLevelsCost[currentFactoryLevel+1]; //display factory price on upgrade board based on selected factory...
            }

            else
            {
                CostOfFactory = factoryPriceHandler.meatcutterfactoryLevelsCost[currentFactoryLevel];
            }
     
        }


        
        else if (indexOfFactoryAssigned ==6 || indexOfFactoryAssigned==7)
        {
            if (indexOfFactoryAssigned % 2 == 1)
            {
                CostOfFactory = factoryPriceHandler.sausagefactoryLevelsCost[currentFactoryLevel+1]; //display factory price on upgrade board based on selected factory...
            }

            else
            {
                CostOfFactory = factoryPriceHandler.sausagefactoryLevelsCost[currentFactoryLevel];
            }
     
        }



        
        else if (indexOfFactoryAssigned ==8 || indexOfFactoryAssigned==9)
        {
            if (indexOfFactoryAssigned % 2 == 1)
            {
                CostOfFactory = factoryPriceHandler.curdfactoryLevelsCost[currentFactoryLevel+1]; //display factory price on upgrade board based on selected factory...
            }

            else
            {
                CostOfFactory = factoryPriceHandler.curdfactoryLevelsCost[currentFactoryLevel];
            }
     
        }


        
        else if (indexOfFactoryAssigned ==10 || indexOfFactoryAssigned==11)
        {
            if (indexOfFactoryAssigned % 2 == 1)
            {
                CostOfFactory = factoryPriceHandler.cheesefactoryLevelsCost[currentFactoryLevel+1]; //display factory price on upgrade board based on selected factory...
            }

            else
            {
                CostOfFactory = factoryPriceHandler.cheesefactoryLevelsCost[currentFactoryLevel];
            }
     
        }

        else 
        {
            Debug.Log("Not Assigned Factory");
        }

        




        
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
