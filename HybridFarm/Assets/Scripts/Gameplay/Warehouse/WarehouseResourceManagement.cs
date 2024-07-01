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
    public int RemainingCapacityOfWarehouse = 0; 

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
        //money is omitted here and objective.collected array has all collectables other than predators.

        // No_of_chicken_inWarehouse =objective.collected_items[1];
        // No_of_pig_inWarehouse =objective.collected_items[2];
        // No_of_cow_inWarehouse =objective.collected_items[3];    
        // No_of_egg_inWarehouse = objective.collected_items[4];
        // No_of_eggPoweder_inWarehouse = objective.collected_items[5];
        // No_of_cake_inWarehouse = objective.collected_items[6];
        // No_of_meat_inWarehouse = objective.collected_items[7];
        // No_of_meatSlice_inWarehouse = objective.collected_items[8];
        // No_of_sausage_inWarehouse = objective.collected_items[9];
        // No_of_milk_inWarehouse = objective.collected_items[10];
        // No_of_curd_inWarehouse = objective.collected_items[11];
        // No_of_cheese_inWarehouse = objective.collected_items[12];

        




        
    }



    public int Remainder(string ItemName, int warehouseLevel, int RemainingSpace) 
    {
        int boxRequired =0;
        int[] RemainderCaluatedArray = {boxRequired, RemainingSpace};

        int[] warehouse1SpaceAllocations = {1,3,5,8,12,16,20,24,27};   // 
        int[] warehouse2SpaceAllocations = {1,1,2,5,7,10,14,17,21};
        int[] warehouse3SpaceAllocations = {1,3,5,8,12,16,20,24,27}; // not yet filled
        int[] warehouse4SpaceAllocations = {1,3,5,8,12,16,20,24,27};  // not yet filled
        int[] warehouse5SpaceAllocations = {1,3,5,8,12,16,20,24,27};  // not yet filled

        

        if (warehouseLevel==1) 
        
        {
            if (RemainingSpace >= warehouse1SpaceAllocations[objective.collected_items[Array.IndexOf(objective.itemsname, ItemName)]])
            {
                // RemainingSpace = RemainingSpace-
            }

        }

        return 0;
    }


}





