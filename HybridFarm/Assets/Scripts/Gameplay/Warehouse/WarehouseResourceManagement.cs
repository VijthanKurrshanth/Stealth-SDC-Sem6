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
    public GameObject ArrowIndicatorOfWareHouse;
    

    [SerializeField] int CapacityOfWarehouse = 44;  // it should be 44 for all warehouse but for not implemented yet
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
        //bool canCollect = false;

        int[] warehouse1SpaceAllocations = {1,1,1,1,1,1,1,1,1};   //{ 1, 3, 5, 8, 12, 16, 20, 24, 27 };
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
            //Debug.Log("" + itemIndex);
            if (itemIndex >= 0) // to confirm item is not money which not is warehouse
            {
                int ItemSpace = selectedWarehouseAllocations[itemIndex-4];
                
                //Debug.Log("" + ItemSpace);

                if (RemainingCapacityOfWarehouse >= ItemSpace)
                {
                    //canCollect = true;
                    boxRequired = warehouse1SpaceAllocations[itemIndex-4];
                }

                else
                {

                    StartCoroutine(SpawnBlinkPrefab());

                    
                    
                    
                }
            }
        }

        return (boxRequired, true ); //cancollected);
    }


    //This code not completed 


    public void warehouseAllignment(int boxRequired, GameObject prefabToSpawnInWareHouse) 
    {

        int startposition =0;
        int endposition =0;

        startposition = CapacityOfWarehouse - RemainingCapacityOfWarehouse+1 ;
        endposition = startposition + boxRequired-1;



        // if (RemainingCapacityOfWarehouse<=20)
        // {
        //     RemainingCapacityOfWarehouse =44;
        // }

        //Debug.Log(startposition);
        //Debug.Log(endposition);
        
        
        
        float zposistion= 4f;  // z position of warehouse product arrangement
        
        Vector3[] AllPostitions = { 

                                    new Vector3 (-1.3f ,-4.34f ,zposistion), new Vector3 (-1.3f ,-4.126f ,zposistion),new Vector3 (-1.3f ,-3.913f ,zposistion),new Vector3 (-1.3f ,-3.6991f ,zposistion),
                                    new Vector3 (-1.0957f ,-4.34f ,zposistion), new Vector3 (-1.0957f ,-4.1268f ,zposistion),new Vector3 (-1.0957f ,-3.913f ,zposistion),new Vector3 (-1.0957f ,-3.6991f ,zposistion),
                                    new Vector3 (-0.8917f ,-4.34f ,zposistion), new Vector3 (-0.8917f ,-4.1262f ,zposistion),new Vector3 (-0.8917f ,-3.913f ,zposistion),new Vector3 (-0.8917f ,-3.6991f ,zposistion),
                                    new Vector3 (-0.6882f ,-4.34f ,zposistion), new Vector3 (-0.6882f ,-4.126f ,zposistion),new Vector3 (-0.6882f ,-3.913f ,zposistion),new Vector3 (-0.6882f ,-3.6991f ,zposistion),
                                    new Vector3 (-0.484f ,-4.34f ,zposistion), new Vector3 (-0.484f ,-4.126f ,zposistion),new Vector3 (-0.484f ,-3.913f ,zposistion),new Vector3 (-0.484f ,-3.6991f ,zposistion),
                                    new Vector3 (-0.281f ,-4.34f ,zposistion), new Vector3 (-0.281f ,-4.126f ,zposistion),new Vector3 (-0.281f ,-3.913f ,zposistion),new Vector3 (-0.281f ,-3.6991f ,zposistion),
                                    new Vector3 (-0.075f ,-4.34f ,zposistion), new Vector3 (-0.075f ,-4.126f ,zposistion),new Vector3 (-0.075f ,-3.913f ,zposistion),new Vector3 (-0.075f ,-3.6991f ,zposistion),
                                    new Vector3 (0.128f ,-4.34f ,zposistion), new Vector3 (0.128f ,-4.126f ,zposistion),new Vector3 (0.128f ,-3.913f ,zposistion),new Vector3 (0.128f ,-3.6991f ,zposistion),
                                    new Vector3 (0.331f ,-4.34f ,zposistion), new Vector3 (0.331f ,-4.126f ,zposistion),new Vector3 (0.331f ,-3.913f ,zposistion),new Vector3 (0.331f ,-3.6991f ,zposistion),
                                    new Vector3 (0.537f ,-4.34f ,zposistion), new Vector3 (0.537f ,-4.126f ,zposistion),new Vector3 (0.537f ,-3.913f ,zposistion),new Vector3 (0.537f ,-3.6991f ,zposistion),
                                    new Vector3 (0.74f ,-4.34f ,zposistion), new Vector3 (0.74f ,-4.126f ,zposistion),new Vector3 (0.74f ,-3.913f ,zposistion),new Vector3 (0.74f ,-3.6991f ,zposistion),
                                    
                                     
                                     
                                    };

        for (int i = startposition-1 ; i <= endposition-1; i++) 
        {

            if (endposition>=40)
            {
                startposition=0;
                endposition = startposition + boxRequired-1;
                i=0;
            }
            
            Instantiate(prefabToSpawnInWareHouse, AllPostitions[i], Quaternion.identity);

        }




        
    } 



    IEnumerator SpawnBlinkPrefab()
        {
            Vector3 spawnPosition = new Vector3(0.92f, -2.83f, 3.8f); 
            Quaternion spawnRotation = Quaternion.Euler(0, 0, -131.973f);

            float elapsedTime = 0f;
            float blinkDuration = 2f;

            while (elapsedTime < blinkDuration)
            {
                
                GameObject blinkObject = Instantiate(ArrowIndicatorOfWareHouse, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(0.25f);
                Destroy(blinkObject);
                // Wait for another 0.25 
                yield return new WaitForSeconds(0.25f);
                elapsedTime += 0.5f; // Since we wait for 0.25 + 0.25 = 0.5 seconds each cycle
            }

        }
 

}









