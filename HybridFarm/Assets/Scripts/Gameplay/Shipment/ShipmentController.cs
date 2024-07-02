using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class ShipmentController : MonoBehaviour
{
    // Start is called before the first frame update
    public int vehicleLevel = 0;
    private int colletablesPerBoxLevel0 =5;
    private int colletablesPerBoxLevel1 =5;
    private int colletablesPerBoxLevel2 =5;
    private int colletablesPerBoxLevel3 =5;


    private int[] BoxPerVehicle =  {2,3,5,7};   // index 0 is for level 0 vehicle.


    Objective objective;

    void Start()
    {
        objective = FindObjectOfType<Objective>();
        
        
    }

    // Update is called once per frame
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





        
    }




    void displayItemsONShipmentMenu ()

    {
        int[] currentItemsCountOnShipment = new int [20];     //first 12 enough for colletables and animals
        string [] currentItemsNameOnShipment = new string [20];

        for (int i = 1 ; i< objective.collected_items.Length ; i++)
        {
            int k=
            if ( objective.collected_items[i] > 0 )
            {
                
                currentItemsCountOnShipment[k] = objective.collected_items[i];
                currentItemsNameOnShipment[k]  = objective.itemsname[i];

                k+=1;


            }

        }




        
    }



}
