using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class ObjectiveText : MonoBehaviour
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

        // Get the TextMeshProUGUI component attached to the same GameObject
        objectiveText = GetComponent<TextMeshProUGUI>(); 
        if (objectiveText == null)
        {
            Debug.LogError("ObjectiveText script requires a TextMeshProUGUI component attached to the same GameObject.");
            return;
        }

        objective = FindObjectOfType<Objective>();

        itemsNumberpostionsInArray = new int[3];
        itemsNumberpostionsInArray[0]=1; //for initialize
        itemsNumberpostionsInArray[1]=1;
        itemsNumberpostionsInArray[2]=1;
        


        for (int i = 0; i < objective.items.Length; i++)
        {
            Debug.Log(" " + i);
            if (objective.items[i]>0)
            {
                
                
                //System.Array.Resize(ref itemsNumberpostionsInArray, itemsNumberpostionsInArray.Length + 1); //rezize array
                itemsNumberpostionsInArray[flag] = i;
                Debug.Log(i.ToString());
                flag++;

            }
        }






        if (itemsNumberpostionsInArray.Length <= 3)
            {
                
                // Instantiate and position item 1
                Vector3 spawnPosition1 = new Vector3(6.116402f, -3.85f, 16f);
                GameObject objectiveitem1 = Instantiate(ItemPrefab1, spawnPosition1, Quaternion.identity);
                transform.position = spawnPosition1;
                // Update the objective text for item 1
                //objectiveText.text = noOfItemCollected.ToString() + "/" + objective.items[itemsNumberpostionsInArray[0]].ToString();

                // Instantiate and position item 2
                Vector3 spawnPosition2 = new Vector3(6.116402f, -3.85f, 16f) + new Vector3(1.1f * 1, 0, 0);
                GameObject objectiveitem2 = Instantiate(ItemPrefab2, spawnPosition2, Quaternion.identity);
                transform.position = spawnPosition2;
                // Update the objective text for item 2
                //objectiveText.text = noOfItemCollected.ToString() + "/" + objective.items[itemsNumberpostionsInArray[1]].ToString();

                // Instantiate and position item 3
                Vector3 spawnPosition3 = new Vector3(6.116402f, -3.85f, 16f) + new Vector3(1.1f * 2, 0, 0);
                GameObject objectiveitem3 = Instantiate(ItemPrefab3, spawnPosition3, Quaternion.identity);
                transform.position = spawnPosition3;
                // Update the objective text for item 3
                //objectiveText.text = noOfItemCollected.ToString() + "/" + objective.items[itemsNumberpostionsInArray[2]].ToString();
            }







    }

    void Update()
    {
                

    }
}
