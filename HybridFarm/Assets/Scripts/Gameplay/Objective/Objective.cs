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
    public GameObject[] respectiveItemSprites = new GameObject[13];
    

    void Start()
    {
        items = new int[] { amount_of_money, No_of_chicken, No_of_pig, No_of_cow, No_of_egg, No_of_eggPoweder, No_of_cake, No_of_meat, No_of_meatSlice, No_of_sausage, No_of_milk, No_of_curd, No_of_cheese };
        itemsname = new string[] { "Money","chicken", "pig", "cow", "egg", "eggPoweder", "cake", "meat", "meatSlice", "sausages", "milk", "curd", "cheese" };

        Debug.Log("Array size: " + respectiveItemSprites.Length);

        respectiveItemSprites[0]=    Resources.Load<GameObject>("Prefabs/ObjectiveBoardAll/coin");
        respectiveItemSprites[1]=    Resources.Load<GameObject>("Prefabs/ObjectiveBoardAll/chicken_onlyface");
        respectiveItemSprites[2]=    Resources.Load<GameObject>("Prefabs/ObjectiveBoardAll/chicken_onlyface");
        respectiveItemSprites[3]=    Resources.Load<GameObject>("Prefabs/ObjectiveBoardAll/chicken_onlyface");
        respectiveItemSprites[4]=    Resources.Load<GameObject>("Prefabs/ObjectiveBoardAll/egg_GUI.prefab");
        respectiveItemSprites[5]=    Resources.Load<GameObject>("Prefabs/ObjectiveBoardAll/eggPowder_GUI.prefab");
        respectiveItemSprites[6]=    Resources.Load<GameObject>("Prefabs/ObjectiveBoardAll/cake_GUI.prefab");
        respectiveItemSprites[7]=    Resources.Load<GameObject>("Prefabs/ObjectiveBoardAll/meat_GUI");
        respectiveItemSprites[8]=    Resources.Load<GameObject>("Prefabs/ObjectiveBoardAll/meatSlice_GUI");
        respectiveItemSprites[9]=    Resources.Load<GameObject>("Prefabs/ObjectiveBoardAll/sausages_GUI");
        respectiveItemSprites[10]=   Resources.Load<GameObject>("Prefabs/ObjectiveBoardAll/milk_GUI");
        respectiveItemSprites[11]=   Resources.Load<GameObject>("Prefabs/ObjectiveBoardAll/curd_GUI");
        respectiveItemSprites[12]=   Resources.Load<GameObject>("Prefabs/ObjectiveBoardAll/cheese_GUI");
        
    }

    // Update is called once per frame
    void Update()
    {


    }
}
