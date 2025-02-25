//using System.Collections;
using System.Collections.Generic;
//using System.Linq;
//using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
//using UnityEngine.UIElements;
using TMPro;


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
    private List<GameObject> spawnedTexts = new List<GameObject>();

    private List<GameObject> spawnedButtons = new List<GameObject>();


    public GameObject buttonPrefab1;
    public GameObject buttonPrefab2;

    public GameObject CoinPrefabs;

    public Transform parentPrefabforText; // for textmesh pro sprites to spawn
    public Transform parentPrefabforButtons;
    public GameObject textMeshProPrefab;

    
    //TextMeshProUGUI ObjectiveText;

    public int[] ItemsPrice = {50,500,5000,10,20,40,200,250,400,1000,2000,3000}; // index zero is money in objective arrays

    //public int[] TempCollectedItems ;

    public Vector3[] ShipmentPostitions;
    public int count;

    

    Objective objective;
    TruckController2D truckController2D;

    ShipmentTransactions shipmentTransactions;

    void Start()
    {
        //ObjectiveText = GetComponent<TextMeshProUGUI>();
        objective = FindObjectOfType<Objective>();
        truckController2D = FindObjectOfType<TruckController2D>();
        shipmentTransactions = FindObjectOfType<ShipmentTransactions>();
        //TextMeshPro textMeshPro = textObj.GetComponent<TextMeshPro>();



        // price list

        count = 0;

        ShipmentPostitions = new Vector3[] { 

                                    new Vector3 (1.56f ,2.77f ,zposistion), new Vector3 (1.56f ,2.3f ,zposistion),new Vector3 (1.56f ,1.84f ,zposistion),new Vector3 (-5.3f ,2.7f ,zposistion),
                                    new Vector3 (-5.3f ,2.22f ,zposistion), new Vector3 (-5.3f ,1.73f ,zposistion),new Vector3 (-5.3f ,1.3f ,zposistion),new Vector3 (-5.3f ,0.86f ,zposistion),
                                    new Vector3 (-5.3f ,0.41f ,zposistion), new Vector3 (-5.3f ,-0.04f ,zposistion),new Vector3 (-5.3f ,-0.53f ,zposistion),new Vector3 (-5.3f ,-1.01f ,zposistion),
                                    
                                     
                                    };


        //TempCollectedItems = objective.collected_items;

    }



    void Update()
    {

        

        ChooseWarehouse ();

        //Debug.Log(shipmentTransactions.ReadyToShipMoney);



        if ( truckController2D.vehicleisPressed && count<=0  )
        {
            
            displayItemsONShipmentMenu();
            DisplayTransactionPrice ();
            count+=1;  //only one time show .... it is not good after selling and
        }

        else if (! truckController2D.vehicleisPressed)
        {
            //TempCollectedItems = objective.collected_items;
            clearShipmentMenu();
            count=0;
        }

        else 
        {
            //TempCollectedItems = objective.collected_items;

            }

        

        //else {count =0;}

        


        

        


    }


    void ChooseWarehouse () 
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



    public void displayItemsONShipmentMenu ()

    {
        
                                    //extraaa 
                                    //new Vector3 (-5.3f ,-1.47f ,zposistion), new Vector3 (-5.3f ,-1.91f ,zposistion),new Vector3 (-5.3f,-2.331f ,zposistion),new Vector3 (-5.3f ,-2.3f ,zposistion)


        int k=3;
        int l=0;

        // int[] currentItemsCountOnShipment = new int [20];     //first 12 enough for colletables and animals
        // string [] currentItemsNameOnShipment = new string [20];

        for (int i = 1 ; i< objective.collected_items.Length ; i++) //i==1 avoid money
        {
            
            if ( objective.collected_items[i] - shipmentTransactions.quantityOfShipmentOfItems[i-1] > 0 )
            {

                if (i<=3) {

                    GameObject spritespawn = Instantiate(objective.respectiveItemSprites[i], ShipmentPostitions[l] , Quaternion.identity);
                    spritespawn.transform.localScale *= 0.5f;
                    spawnedItems.Add(spritespawn);

                    GameObject textObj = Instantiate(textMeshProPrefab, ShipmentPostitions[l] + new Vector3(1.1f, -0.14f, 0), Quaternion.identity);
                    TextMeshProUGUI textMeshPro = textObj.GetComponent<TextMeshProUGUI>();
                    textMeshPro.text = "× " + (objective.collected_items[i] - shipmentTransactions.quantityOfShipmentOfItems[i-1]).ToString()+"</b>";
                    textObj.transform.SetParent(parentPrefabforText);
                    textObj.transform.localScale = Vector3.one;
                    spawnedTexts.Add(textObj);


                    GameObject textObj2 = Instantiate(textMeshProPrefab, ShipmentPostitions[l] + new Vector3(2.15f, -0.14f, 0), Quaternion.identity);
                    TextMeshProUGUI textMeshPro2 = textObj2.GetComponent<TextMeshProUGUI>();
                    textMeshPro2.text = ItemsPrice[i-1].ToString() +"</b>";
                    textObj2.transform.SetParent(parentPrefabforText);
                    textObj2.transform.localScale = Vector3.one;
                    spawnedTexts.Add(textObj2);


                    GameObject coin = Instantiate(CoinPrefabs , ShipmentPostitions[l]+ new Vector3(2.15f, 0f, 0) , Quaternion.identity);
                    coin.transform.localScale *= 0.45f;
                    spawnedItems.Add(coin);





                    GameObject button1 = Instantiate(buttonPrefab1, ShipmentPostitions[l] + new Vector3(2.5f, 0f, 0), Quaternion.identity);
                    button1.transform.SetParent(parentPrefabforButtons);
                    button1.transform.localScale = new Vector3 (0.23f,0.23f,1f) ; // to Ensure scale is (1, 1, 1)   for Vector3.one
                    spawnedButtons.Add(button1);
                    oneButton buttonComponent1 = button1.GetComponent<oneButton>();
                    buttonComponent1.keyNo = i-1;

                    // Instantiate the second button next to the first one
                    GameObject button2 = Instantiate(buttonPrefab2, ShipmentPostitions[l] + new Vector3(2.9f , 0f, 0), Quaternion.identity);
                    button2.transform.SetParent(parentPrefabforButtons);
                    button2.transform.localScale = new Vector3 (0.23f,0.23f,1f) ;// Vector3.one; // to Ensure scale is (1, 1, 1)
                    spawnedButtons.Add(button2);
                    allButton buttonComponent2 = button2.GetComponent<allButton>();
                    buttonComponent2.keyNo = i-1;




                    l+=1;
                }

                else 
                {
                    GameObject spritespawn = Instantiate(objective.respectiveItemSprites[i], ShipmentPostitions[k] , Quaternion.identity);
                    spritespawn.transform.localScale *= 0.5f;
                    spawnedItems.Add(spritespawn);

                    GameObject textObj = Instantiate(textMeshProPrefab, ShipmentPostitions[k] + new Vector3(1.1f, -0.14f, 0), Quaternion.identity);
                    TextMeshProUGUI textMeshPro = textObj.GetComponent<TextMeshProUGUI>();
                    textMeshPro.text = "× " + (objective.collected_items[i] - shipmentTransactions.quantityOfShipmentOfItems[i-1]).ToString() +"</b>";
                    textObj.transform.SetParent(parentPrefabforText);
                    textObj.transform.localScale = Vector3.one;
                    spawnedTexts.Add(textObj);


                    GameObject textObj2 = Instantiate(textMeshProPrefab, ShipmentPostitions[k] + new Vector3(1.75f, -0.14f, 0), Quaternion.identity);
                    TextMeshProUGUI textMeshPro2 = textObj2.GetComponent<TextMeshProUGUI>();
                    textMeshPro2.text = ItemsPrice[i-1].ToString() +"</b>";
                    textObj2.transform.SetParent(parentPrefabforText);
                    textObj2.transform.localScale = Vector3.one;
                    spawnedTexts.Add(textObj2);

                    GameObject coin = Instantiate(CoinPrefabs , ShipmentPostitions[k]+ new Vector3(1.45f, 0f, 0) , Quaternion.identity);
                    coin.transform.localScale *= 0.45f;
                    spawnedItems.Add(coin);





                    GameObject button1 = Instantiate(buttonPrefab1, ShipmentPostitions[k] + new Vector3(1.78f, 0f, 0), Quaternion.identity);
                    button1.transform.SetParent(parentPrefabforButtons);
                    button1.transform.localScale = new Vector3 (0.23f,0.23f,1f) ; // to Ensure scale is (1, 1, 1)   for Vector3.one
                    spawnedButtons.Add(button1);
                    oneButton buttonComponent1 = button1.GetComponent<oneButton>();
                    buttonComponent1.keyNo = i-1;

                    // Instantiate the second button next to the first one
                    GameObject button2 = Instantiate(buttonPrefab2, ShipmentPostitions[k] + new Vector3(2.15f , 0f, 0), Quaternion.identity);
                    button2.transform.SetParent(parentPrefabforButtons);
                    button2.transform.localScale = new Vector3 (0.23f,0.23f,1f) ;// Vector3.one; // to Ensure scale is (1, 1, 1)
                    spawnedButtons.Add(button2);
                    allButton buttonComponent2 = button2.GetComponent<allButton>();
                    buttonComponent2.keyNo = i-1;


                    k+=1;

                }

                

                // each fram check for warehouse non zero count collectables and update current Items array
            }

            if (i== objective.collected_items.Length-1)
            {
                k=3;
                l=0;               
            }

        }
    
    }



    public void clearShipmentMenu()
    {
        foreach (GameObject item in spawnedItems)
        {
            Destroy(item);
        }
        spawnedItems.Clear();

        
        foreach (GameObject text in spawnedTexts)
        {
            Destroy(text);
        }
        spawnedTexts.Clear();

        foreach (GameObject item in spawnedButtons)
        {
            Destroy(item);
        }
        spawnedTexts.Clear();


        //count=0;

        
    }


    void DisplayTransactionPrice ()
    {
        GameObject textObj3 = Instantiate(textMeshProPrefab, new Vector3(3.5f ,-3.45f ,zposistion), Quaternion.identity);
        TextMeshProUGUI textMeshPro3 = textObj3.GetComponent<TextMeshProUGUI>();
        textMeshPro3.text = shipmentTransactions.ReadyToShipMoney.ToString();
        textObj3.transform.SetParent(parentPrefabforText);
        textObj3.transform.localScale = new Vector3(2,2,1); //Vector3.one;
        spawnedTexts.Add(textObj3);
        
    }


    public void ClearDisplayedTexts()
    {
        foreach (GameObject textObj in spawnedTexts)
        {
            Destroy(textObj);
        }
        spawnedTexts.Clear(); // Clear the list after destroying the objects
    }



}
