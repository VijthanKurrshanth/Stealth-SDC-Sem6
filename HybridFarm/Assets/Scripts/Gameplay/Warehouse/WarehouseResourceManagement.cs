using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class WarehouseResourceManagement : MonoBehaviour
{
    
    // Start is called before the first frame update

    Objective objective;

    [SerializeField] int CapacityOfWarehouse = 44;
    public int RemainingCapacityOfWarehouse = 44; 

    public int warehouseLevel = 0;


    // public int[] warehouse_items;

    // public int No_of_chicken_inWarehouse =0;
    // public int No_of_pig_inWarehouse =0;
    // public int No_of_cow_inWarehouse =0;    
    // public int No_of_egg_inWarehouse = 0;
    // public int No_of_eggPoweder_inWarehouse = 0 ;
    // public int No_of_cake_inWarehouse = 0 ;
    // public int No_of_meat_inWarehouse = 0 ;
    // public int No_of_meatSlice_inWarehouse = 0;
    // public int No_of_sausage_inWarehouse = 0 ;
    // public int No_of_milk_inWarehouse = 0 ;
    // public int No_of_curd_inWarehouse = 0 ;
    // public int No_of_cheese_inWarehouse = 0;

    public int No_of_fox_inWarehouse = 0 ;
    public int No_of_lynx_inWarehouse = 0 ;
    public int No_of_couguar_inWarehouse = 0;
    public int No_of_wolf_inWarehouse = 0 ;
    public int No_of_snowleopard_inWarehouse = 0 ;



    void Start()
    {
       
        //objective_items = new int[] { No_of_egg, No_of_eggPoweder, No_of_cake, No_of_meat, No_of_meatSlice, No_of_sausage, No_of_milk, No_of_curd, No_of_cheese };
        objective = FindObjectOfType<Objective>();


    }



    void Update()
    {
        
        //Debug.Log(RemainingCapacityOfWarehouse);
    }


    //tupple that has mixed data types taken as input and return remaining , box allocation and can collect

    public (int BoxRequired, bool CanCollect) SpaceAllocationWarehouse(string ItemName, int warehouseLevel) 
    {
        int boxRequired = 0;
        bool canCollect = false;

        int[] warehouse1SpaceAllocations = { 1, 3, 5, 8, 12, 16, 20, 24, 27 };
        int[] warehouse2SpaceAllocations = { 1, 1, 2, 5, 7, 10, 14, 17, 21 };
        int[] warehouse3SpaceAllocations = { 1, 3, 5, 8, 12, 16, 20, 24, 27 };
        int[] warehouse4SpaceAllocations = { 1, 3, 5, 8, 12, 16, 20, 24, 27 };
        int[] warehouse5SpaceAllocations = { 1, 3, 5, 8, 12, 16, 20, 24, 27 };

        int[][] warehouseSpaceAllocations = {
            warehouse1SpaceAllocations,
            warehouse2SpaceAllocations,
            warehouse3SpaceAllocations,
            warehouse4SpaceAllocations,
            warehouse5SpaceAllocations
        };

        if (warehouseLevel >= 1 && warehouseLevel <= warehouseSpaceAllocations.Length) 
        {
            int[] selectedWarehouseAllocations = warehouseSpaceAllocations[warehouseLevel - 1];
            

             

            int itemIndex = Array.IndexOf(objective.itemsname, ItemName); // itemsname is list of String in Objective.cs
            
            //Debug.Log("" + itemIndex);
            if (itemIndex >= 0 && itemIndex < selectedWarehouseAllocations.Length)
            {
                int ItemSpace = selectedWarehouseAllocations[objective.collected_items[itemIndex]];
                if (RemainingCapacityOfWarehouse >= ItemSpace)
                {
                    canCollect = true;
                    boxRequired = warehouse1SpaceAllocations[itemIndex-4];
                }
            }
        }

        return (boxRequired, canCollect);
    }


    //This code not completed 


    public void warehouseAllignment(int boxRequired) 
    {

        int startposition =0;
        int endposition =0;

        startposition = CapacityOfWarehouse - RemainingCapacityOfWarehouse+1 ;
        endposition = startposition + boxRequired-1;

        Debug.Log(""+ startposition);
        Debug.Log("" + endposition);


        



        
    } 



}





