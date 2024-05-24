using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Objective : MonoBehaviour
{
    // Start is called before the first frame update

    // Below are objectives
    public int amount_of_money=0;
    public int No_of_chicken =0;
    public int No_of_pig =0;
    public int No_of_cow =0;                                // objective present amounts
    public int No_of_egg = 0;
    public int No_of_eggPoweder =0 ;
    public int No_of_cake =0 ;
    public int No_of_meat =0 ;
    public int No_of_meatSlice =0;
    public int No_of_sausage =0 ;
    public int No_of_milk =0 ;
    public int No_of_curd =0 ;
    public int No_of_cheese =0;


    //below are present amount tracking this should be updated manually with initial item amount.
    public int collected_amount_of_money = 0;
    public int collected_No_of_chicken =0;
    public int collected_No_of_pig =0;
    public int collected_No_of_cow =0;
    public int collected_No_of_egg = 0;
    public int collected_No_of_eggPoweder =0 ;
    public int collected_No_of_cake =0 ;
    public int collected_No_of_meat =0 ;
    public int collected_No_of_meatSlice =0;
    public int collected_No_of_sausage =0 ;
    public int collected_No_of_milk =0 ;
    public int collected_No_of_curd =0 ;
    public int collected_No_of_cheese =0;



    public int[] objective_items;
    public int[] collected_items;
    public string[] itemsname;
    public GameObject[] respectiveItemSprites;   // this will have sprites of objective in order resepctive to item(pissoble objective items)
    
    
    //private int flag =0;

    //ObjectiveFigure objectiveFigure;
    

    void Start()
    {
        

        //objectiveFigure = FindObjectOfType<ObjectiveFigure>();

        objective_items = new int[] { amount_of_money, No_of_chicken, No_of_pig, No_of_cow, No_of_egg, No_of_eggPoweder, No_of_cake, No_of_meat, No_of_meatSlice, No_of_sausage, No_of_milk, No_of_curd, No_of_cheese };
        collected_items = new int[] { collected_amount_of_money, collected_No_of_chicken, collected_No_of_pig, collected_No_of_cow, collected_No_of_egg, collected_No_of_eggPoweder, collected_No_of_cake, collected_No_of_meat, collected_No_of_meatSlice, collected_No_of_sausage, collected_No_of_milk, collected_No_of_curd, collected_No_of_cheese };
        // This should be entered as name for spawnobject scripts when script assigned.
        itemsname = new string[] { "money","chicken", "pig", "cow", "egg", "eggPoweder", "cake", "meat", "meatSlice", "sausages", "milk", "curd", "cheese" };

        respectiveItemSprites = new GameObject[13];
        //Debug.Log("Array size: " + respectiveItemSprites.Length);

        respectiveItemSprites[0]=    Resources.Load<GameObject>("coin");
        respectiveItemSprites[1]=    Resources.Load<GameObject>("chicken_onlyface");   // each prefabs should be in a folder "Assets/Resources" by default
        respectiveItemSprites[2]=    Resources.Load<GameObject>("pig_onlyface");       // So temperorily there is a Resource folder which is copy of prefabs/objective prefabs folder
        respectiveItemSprites[3]=    Resources.Load<GameObject>("cow_onlyface") ;
        respectiveItemSprites[4]=    Resources.Load<GameObject>("egg_GUI");
        respectiveItemSprites[5]=    Resources.Load<GameObject>("eggPowder_GUI");
        respectiveItemSprites[6]=    Resources.Load<GameObject>("cake_GUI");
        respectiveItemSprites[7]=    Resources.Load<GameObject>("meat_GUI");
        respectiveItemSprites[8]=    Resources.Load<GameObject>("meatSlice_GUI");
        respectiveItemSprites[9]=    Resources.Load<GameObject>("sausages_GUI");
        respectiveItemSprites[10]=   Resources.Load<GameObject>("milk_GUI");
        respectiveItemSprites[11]=   Resources.Load<GameObject>("curd_GUI");
        respectiveItemSprites[12]=   Resources.Load<GameObject>("cheese_GUI");

        
        

        
    }

    // Update is called once per frame
    void Update()
    {   

        

    }


}
