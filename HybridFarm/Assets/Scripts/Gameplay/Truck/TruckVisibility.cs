using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckVisibility : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TruckPrefab;

    ShipmentBar shipmentBar;
    void Start()
    {
        shipmentBar = FindObjectOfType<ShipmentBar>();
        
    }

    // Update is called once per frame
    void Update()
    {
        TruckPrefab.SetActive(shipmentBar.canTravelagain);
    }
}
