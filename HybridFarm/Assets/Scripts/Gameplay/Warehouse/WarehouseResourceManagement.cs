using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarehouseResourceManagement : MonoBehaviour
{
    // Start is called before the first frame update

    public int[] warehouse_items;
    public int No_of_egg_inWarehouse = 0;
    public int No_of_eggPoweder_inWarehouse = 0 ;
    public int No_of_cake_inWarehouse = 0 ;
    public int No_of_meat_inWarehouse = 0 ;
    public int No_of_meatSlice_inWarehouse = 0;
    public int No_of_sausage_inWarehouse = 0 ;
    public int No_of_milk_inWarehouse = 0 ;
    public int No_of_curd_inWarehouse = 0 ;
    public int No_of_cheese_inWarehouse = 0;

    void Start()
    {
        objective_items = new int[] { No_of_egg, No_of_eggPoweder, No_of_cake, No_of_meat, No_of_meatSlice, No_of_sausage, No_of_milk, No_of_curd, No_of_cheese };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
