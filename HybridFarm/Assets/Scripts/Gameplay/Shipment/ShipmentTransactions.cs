using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class ShipmentTransactions : MonoBehaviour
{
    // Start is called before the first frame update

    Objective objective;
    ShipmentController shipmentController;
    //ShipmentCancelButton shipmentCancelButton;

    public int ReadyToShipMoney = 0;
    public int [] quantityOfShipmentOfItems = {0,0,0,0,0,0,0,0,0,0,0,0};    //this will be sort like collectables items excluding Money amount.

    public int key = -1;  //any number other than  than 0-11
    public bool isTrasnferAll = false;

    public bool isDiscard = false;

    public bool OkisPressed = false;

    public bool ShipmentCancelisPressed =false;
    ShipmentBar shipmentBar;


    void Start()
    {
        objective = FindObjectOfType<Objective>();
        shipmentController = FindObjectOfType<ShipmentController>();
        shipmentBar = FindObjectOfType<ShipmentBar>();
        //shipmentCancelButton = FindObjectOfType<ShipmentCancelButton>();
        
    }

    // Update is called once per frame
    void Update()
    {




        ShipmentTransactionsProcess();
        ReadyToShipMoney = CalcualteTotalAmount(quantityOfShipmentOfItems);
        
//         Debug.Log(quantityOfShipmentOfItems[2]);
        //Displaying it on TextMeshPro in shipmentController

        if (OkisPressed) 
        {
            //shipmentBar.canTravel=true;
            Debug.Log("Ok is pressed");
            for (int i = 0; i< quantityOfShipmentOfItems.Length ;i++)
            {
                
                if (i==0)
                {
                    Debug.Log("ChickenDestroyed");
                    DestroyGameObjectsWithTag("chicken", quantityOfShipmentOfItems[i]);
                    
                    
                }

                else if (i==1)
                {
                    DestroyGameObjectsWithTag("pig", quantityOfShipmentOfItems[i]);
                    

                }

                else if (i==2)
                {
                    Debug.Log("Cow destroyed");
                    Debug.Log(quantityOfShipmentOfItems[i]);
                    DestroyGameObjectsWithTag("cow", quantityOfShipmentOfItems[i]);
                   

                }

                objective.collected_items[i+1] -= quantityOfShipmentOfItems[i];    //should be in shipmentBar Vechile

                shipmentBar.money = ReadyToShipMoney;


            }

            for (int j = 0; j< quantityOfShipmentOfItems.Length ;j++)
            {
                quantityOfShipmentOfItems[j]=0;

            }

                //objective.collected_items[0] += ReadyToShipMoney;
            

            //OkisPressed =false;
            
        }
        





        
        
    }


    public void ShipmentTransactionsProcess( )
    {
        
        for (int i =0; i<=11; i++)
        {
            if (i==key && isTrasnferAll) 
            {
                quantityOfShipmentOfItems[i]= objective.collected_items[i+1];
                //objective.collected_items[i+1]=0;
                key=-1;
                isTrasnferAll=false;
            }

            else if (i==key )
            {
                quantityOfShipmentOfItems[i]+=1;
                //objective.collected_items[i+1]-=1;
                key=-1;
                isTrasnferAll=false;
            }

            else if (isDiscard)
            {
                for (int j=0; j<=11 ; j++)
                {
                    quantityOfShipmentOfItems[j]=0;
                    //shipmentController.TempCollectedItems= objective.collected_items;
                    key=-1;
                    isTrasnferAll=false;
                }
            }

            else if  (ShipmentCancelisPressed)
            {
                for (int j=0; j<=11 ; j++)
                {
                    quantityOfShipmentOfItems[j]=0;
                    //shipmentController.TempCollectedItems= objective.collected_items;
                    key=-1;
                    isTrasnferAll=false;
                }
                ShipmentCancelisPressed = false;

            }

            else {}



        }


    }



    public int CalcualteTotalAmount( int[] quantityArray ) 
    {
        int sum=0;

        for (int i=0; i<=11; i++)
        {
            sum += quantityArray[i] * shipmentController.ItemsPrice[i];
        }

        return sum;
    }


    void DestroyGameObjectsWithTag(string tag, int count)
    {
        
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        for (int i = 0; i < Mathf.Min(count, objects.Length); i++)
        {
            Destroy(objects[i]);
        }
    }





    

}
