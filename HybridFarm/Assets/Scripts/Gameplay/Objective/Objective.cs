using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Objective : MonoBehaviour
{
    // Start is called before the first frame update
    public int amount_of_money=0;
    public int No_of_chicken =0;
    public int No_of_pig =0;
    public int No_of_cow =0;
    public int No_of_egg = 0;
    public int No_of_eggPoweder =0 ;
    public int No_of_cake =0 ;
    public int No_of_meat =0 ;
    public int No_of_meatSlice =0;
    public int No_of_sausage =0 ;
    public int No_of_milk =0 ;
    public int No_of_curd =0 ;
    public int No_of_cheese =0;

    public int[] items;
    public string[] itemsname;
    public string[] respectiveItemSprites;
    

    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        items = new int[] { amount_of_money, No_of_chicken, No_of_pig, No_of_cow, No_of_egg, No_of_eggPoweder, No_of_cake, No_of_meat, No_of_meatSlice, No_of_sausage, No_of_milk, No_of_curd, No_of_cheese };
        itemsname = new string[] { "Money","chicken", "pig", "cow", "egg", "eggPoweder", "cake", "meat", "meatSlice", "sausage", "milk", "curd", "cheese" };
      
        respectiveItemSprites = new string[] { "","","", "Collectables Sheet-01_6", "Collectables Sheet-01_7","Collectables Sheet-01_8","Collectables Sheet-01_3","Collectables Sheet-01_4","Collectables Sheet-01_5","Collectables Sheet-01_2","Collectables Sheet-01_1","Collectables Sheet-01_0"};
        

    }
}
