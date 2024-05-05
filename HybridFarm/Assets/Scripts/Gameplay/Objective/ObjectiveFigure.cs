using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class ObjectiveFigure : MonoBehaviour
{
    Objective objective;
    public TextMeshProUGUI objectiveText; // Reference to the TextMeshProUGUI component to display the timer
    public int noOfItemCollected = 1;
    public GameObject ItemPrefab1; 
    public GameObject ItemPrefab2; 
    public GameObject ItemPrefab3; 
    public int[] itemsNumberpostionsInArray;
    private int flag =0;

    void Start()
    {

        objective = FindObjectOfType<Objective>();
        itemsNumberpostionsInArray = new int[3];
        itemsNumberpostionsInArray[0]=1; //for initialize
        itemsNumberpostionsInArray[1]=1;
        itemsNumberpostionsInArray[2]=1;

        ItemPrefab1= objective.respectiveItemSprites[1] ;
        ItemPrefab2= objective.respectiveItemSprites[2] ;
        ItemPrefab3= objective.respectiveItemSprites[3] ;

        Debug.Log(ItemPrefab1);

        for (int i = 0; i < objective.items.Length; i++)
        {
            
            if (objective.items[i]>0)
            {
                itemsNumberpostionsInArray[flag] = i;
                flag++;
            }
        }



        if (itemsNumberpostionsInArray.Length <= 3)
            {
                // Instantiate and position item 1
                Vector3 spawnPosition1 = new Vector3(6.05006402f, -3.85f, 16f);
                GameObject objectiveitem1 = Instantiate(ItemPrefab1, spawnPosition1, Quaternion.identity);
                
                 
                // Instantiate and position item 2
                Vector3 spawnPosition2 = new Vector3(6.0516402f, -3.85f, 16f) + new Vector3(1.1f * 1, 0, 0);
                GameObject objectiveitem2 = Instantiate(ItemPrefab2, spawnPosition2, Quaternion.identity);
                
                

                // Instantiate and position item 3
                Vector3 spawnPosition3 = new Vector3(6.116402f, -3.85f, 16f) + new Vector3(1.1f * 2, 0, 0);
                GameObject objectiveitem3 = Instantiate(ItemPrefab3, spawnPosition3, Quaternion.identity);
                
                
            }

    }

    void Update()
    {
                

    }
}
