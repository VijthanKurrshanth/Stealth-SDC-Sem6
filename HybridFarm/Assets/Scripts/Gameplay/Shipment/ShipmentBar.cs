using System.Collections;
using UnityEngine;

public class ShipmentBar : MonoBehaviour
{
    public GameObject shipmentBarPrefab;
    public GameObject shipmentVehiclePrefab;
    public int vehicleLevel = 0; // Speed level for the vehicle
    //public int TimeTakenToTravel = 0; // Time taken to travel to destination in seconds
    private Vector3 destination = new Vector3(-7.9f, 4.04f, -2.1f);

    private ShipmentTransactions shipmentTransactions;
    private Objective objective;

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
        }
    }

    IEnumerator VehicleTravelToTown()
    {
        GameObject shipmentBarObject = Instantiate(shipmentBarPrefab, new Vector3(-5.69f, 4.31f, -1.5f), Quaternion.identity);
        GameObject vehicle = Instantiate(shipmentVehiclePrefab, new Vector3(-3.51f, 4.04f, -2.1f), Quaternion.identity);

        float vehicleSpeed = 1f; // Adjust this speed as needed

        // Move vehicle to destination
        while (Vector3.Distance(vehicle.transform.position, destination) > 0.01f)
        {
            vehicle.transform.position = Vector3.MoveTowards(vehicle.transform.position, destination, Time.deltaTime * vehicleSpeed);
            yield return null;
        }

        // Wait at destination
        //yield return new WaitForSeconds(TimeTakenToTravel);

        // Flip vehicle direction (optional)
        vehicle.transform.localScale = new Vector3(-vehicle.transform.localScale.x, vehicle.transform.localScale.y, vehicle.transform.localScale.z);

        // Move vehicle back to the origin
        Vector3 origin = new Vector3(-3.51f, 4.04f, -2.1f);
        while (Vector3.Distance(vehicle.transform.position, origin) > 0.01f)
        {
            vehicle.transform.position = Vector3.MoveTowards(vehicle.transform.position, origin, Time.deltaTime * vehicleSpeed);
            yield return null;
        }

        // Destroy vehicle after returning
        Destroy(vehicle);
        Destroy(shipmentBarObject);

        // Example: Storing collected items in an objective
        
        
        objective.collected_items[0] += shipmentTransactions.ReadyToShipMoney;
        
    }
}
