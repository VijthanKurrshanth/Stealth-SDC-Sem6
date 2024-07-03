using System.Collections;
using UnityEngine;
using TMPro;

public class ShipmentBar : MonoBehaviour
{
    public GameObject shipmentBarPrefab;
    public GameObject shipmentVehiclePrefab;

    public Transform PrefabParent;

    public GameObject textMeshProPrefab;
    public int vehicleLevel = 0; // Speed level for the vehicle
    //public int TimeTakenToTravel = 0; // Time taken to travel to destination in seconds
    private Vector3 destination = new Vector3(-7.9f, 4.04f, -2.5f);

    private ShipmentTransactions shipmentTransactions;
    private Objective objective;

    public int money=0;

    public bool canTravelagain=true;

    void Start()
    {
        // Initialization if needed
        shipmentTransactions = FindObjectOfType<ShipmentTransactions>();
        objective = FindObjectOfType<Objective>();
    }

    void Update()
    {
        if (shipmentTransactions.OkisPressed)
        {
            
            //shipmentTransactions.OkisPressed = false; // Prevents starting multiple coroutines
            StartCoroutine(VehicleTravelToTown());
            Debug.Log(shipmentTransactions.ReadyToShipMoney);
        }
    }

    IEnumerator VehicleTravelToTown()
    {

        canTravelagain=false;
        shipmentTransactions.OkisPressed = false;
        //money = shipmentTransactions.ReadyToShipMoney;
        //shipmentTransactions.ReadyToShipMoney=0;
        GameObject shipmentBarObject = Instantiate(shipmentBarPrefab, new Vector3(-5.69f, 4.31f, -1.5f), Quaternion.identity);
        GameObject vehicle = Instantiate(shipmentVehiclePrefab, new Vector3(-3.51f, 4.04f, -2.5f), Quaternion.identity);

        Vector3 origin = new Vector3(-3.51f, 4.04f, -2.5f);
        
        Vector3 originText = new Vector3(-3.05f, 4.34f, -2.5f);


        GameObject textObj = Instantiate(textMeshProPrefab, originText , Quaternion.identity);
        TextMeshProUGUI textMeshPro = textObj.GetComponent<TextMeshProUGUI>();
        textMeshPro.text = money.ToString() +"</b>";
        textObj.transform.SetParent(PrefabParent);
        textObj.transform.localScale = Vector3.one;
        




        float vehicleSpeed = 1f; // Adjust this speed as needed

        // Move vehicle to destination
        while (Vector3.Distance(vehicle.transform.position, destination) > 0.01f)

        
        {   
            

            vehicle.transform.position = Vector3.MoveTowards(vehicle.transform.position, destination , Time.deltaTime * vehicleSpeed);
            textObj.transform.position = Vector3.MoveTowards(textObj.transform.position, new Vector3(-7.34f,4.34f,-2.5f), Time.deltaTime * vehicleSpeed);
            yield return null;
        }

        // Wait at destination
        //yield return new WaitForSeconds(TimeTakenToTravel);

        // Flip vehicle direction (optional)
        vehicle.transform.localScale = new Vector3(-vehicle.transform.localScale.x, vehicle.transform.localScale.y, vehicle.transform.localScale.z);

        // Move vehicle back to the origin

        while (Vector3.Distance(vehicle.transform.position, origin) > 0.01f)
        {
            vehicle.transform.position = Vector3.MoveTowards(vehicle.transform.position, origin, Time.deltaTime * vehicleSpeed);
            textObj.transform.position = Vector3.MoveTowards(textObj.transform.position, originText, Time.deltaTime * vehicleSpeed);
            yield return null;
        }

        // Destroy vehicle after returning
        Destroy(vehicle);
        Destroy(shipmentBarObject);
        Destroy(textObj);

        // Example: Storing collected items in an objective
        
        
        objective.collected_items[0] += money;
        canTravelagain=true;
        money=0;
        
        

        
    }
}
