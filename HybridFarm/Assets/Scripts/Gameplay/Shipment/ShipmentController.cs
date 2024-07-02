using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UIElements;


public class ShipmentController : MonoBehaviour
{
    // Start is called before the first frame update
    public int vehicleLevel = 0;
    // private int colletablesPerBoxLevel0 =5;
    // private int colletablesPerBoxLevel1 =5;
    // private int colletablesPerBoxLevel2 =5;
    // private int colletablesPerBoxLevel3 =5;


    private int[] BoxPerVehicle =  {2,3,5,7};   // index 0 is for level 0 vehicle.

    private float zposistion = -2.1f;

    private List<GameObject> spawnedItems = new List<GameObject>();

    

    Objective objective;
    TruckController2D truckController2D;

    void Start()
    {
        objective = FindObjectOfType<Objective>();
        truckController2D = FindObjectOfType<TruckController2D>();


        // price list


        
    }



    void Update()
    {
        if (vehicleLevel==0)
        {
            int BoxCount = BoxPerVehicle[0];

        }

        else if (vehicleLevel==1)
        {
            int BoxCount = BoxPerVehicle[1];

        }

        else if (vehicleLevel==2)
        {
            int BoxCount = BoxPerVehicle[2];

        }

        else if (vehicleLevel==3)
        {
            int BoxCount = BoxPerVehicle[3];

        }

        else 
        {

        }


        if ( truckController2D.vehicleisPressed )
        {
            displayItemsONShipmentMenu();
        }

        else 
        {
            clearShipmentMenu();
        }




    }




    void displayItemsONShipmentMenu ()

    {
        int[] ItemsPrice = {50,500,5000,10,20,40,200,250,400,1000,2000,3000}; // index zero is money in objective arrays


        
        Vector3[] ShipmentPostitions = { 

                                    new Vector3 (1.56f ,2.77f ,zposistion), new Vector3 (1.56f ,2.3f ,zposistion),new Vector3 (1.56f ,1.84f ,zposistion),new Vector3 (-5.3f ,2.7f ,zposistion),
                                    new Vector3 (-5.3f ,2.22f ,zposistion), new Vector3 (-5.3f ,1.73f ,zposistion),new Vector3 (-5.3f ,1.3f ,zposistion),new Vector3 (-5.3f ,0.86f ,zposistion),
                                    new Vector3 (-5.3f ,0.41f ,zposistion), new Vector3 (-5.3f ,-0.04f ,zposistion),new Vector3 (-5.3f ,-0.53f ,zposistion),new Vector3 (-5.3f ,-1.01f ,zposistion),
                                    
                                     
                                    };

                                    
                                    //extraaa 
                                    //new Vector3 (-5.3f ,-1.47f ,zposistion), new Vector3 (-5.3f ,-1.91f ,zposistion),new Vector3 (-5.3f,-2.331f ,zposistion),new Vector3 (-5.3f ,-2.3f ,zposistion)

        

        int k=3;
        int l=0;

        // int[] currentItemsCountOnShipment = new int [20];     //first 12 enough for colletables and animals
        // string [] currentItemsNameOnShipment = new string [20];

        for (int i = 1 ; i< objective.collected_items.Length ; i++) //i==1 avoid money
        {
            
            if ( objective.collected_items[i] > 0 )
            {

                if (i<=2) {

                    GameObject spritespawn = Instantiate(objective.respectiveItemSprites[i], ShipmentPostitions[l] , Quaternion.identity);
                    spritespawn.transform.localScale *= 0.5f;
                    spawnedItems.Add(spritespawn);
                    l+=1;
                }

                else 
                {
                    GameObject spritespawn = Instantiate(objective.respectiveItemSprites[i], ShipmentPostitions[k] , Quaternion.identity);
                    spritespawn.transform.localScale *= 0.5f;
                    spawnedItems.Add(spritespawn);
                    k+=1;

                }

                

                // each fram check for warehouse non zero count collectables and update current ITems array
            }

            if (i== objective.collected_items.Length-1)
            {
                k=3;
                l=0;               
            }

        }
  
    
    
    
    }


    void clearShipmentMenu()
    {
        foreach (GameObject item in spawnedItems)
        {
            Destroy(item);
        }
        spawnedItems.Clear();
    }



}
