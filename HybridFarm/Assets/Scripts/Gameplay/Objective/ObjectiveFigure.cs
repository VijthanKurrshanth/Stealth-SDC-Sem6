using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class ObjectiveFigure : MonoBehaviour
{
    Objective objective;
    public TextMeshProUGUI objectiveText; // Reference to the TextMeshProUGUI component to display the timer
    public int noOfItemCollected = 1;
 
    public GameObject[] ObjectiveSelectedprefabs;
    private int flag =0;


    void Start()
    {

        objective = FindObjectOfType<Objective>();
        ObjectiveSelectedprefabs = new GameObject[3];
        ObjectiveSelectedprefabs[0]=null;
        ObjectiveSelectedprefabs[1]=null;
        ObjectiveSelectedprefabs[2]=null;
        // ItemPrefab1= objective.respectiveItemSprites[1] ;
        // ItemPrefab2= objective.respectiveItemSprites[2] ;
        // ItemPrefab3= objective.respectiveItemSprites[3] ;
        



        

        for (int i = 0; i < objective.items.Length; i++)
        {
            
            if (objective.items[i]>0)
            {
                ObjectiveSelectedprefabs[flag]=objective.respectiveItemSprites[i];
                flag++;
            }
        }

            // Instantiate and position item 1
            Vector3 spawnPosition1 = new Vector3(6.05006402f, -3.85f, 16f);
            if (ObjectiveSelectedprefabs[0])
            {
                GameObject objectiveitem1 = Instantiate(ObjectiveSelectedprefabs[0], spawnPosition1, Quaternion.identity);
            }
                
                 
            // Instantiate and position item 2
            Vector3 spawnPosition2 = new Vector3(6.0516402f, -3.85f, 16f) + new Vector3(1.1f * 1, 0, 0);
            if (ObjectiveSelectedprefabs[1])
            {
            GameObject objectiveitem2 = Instantiate(ObjectiveSelectedprefabs[1], spawnPosition2, Quaternion.identity);
            }
                
            // Instantiate and position item 3
            Vector3 spawnPosition3 = new Vector3(6.116402f, -3.85f, 16f) + new Vector3(1.1f * 2, 0, 0);
            if (ObjectiveSelectedprefabs[2])
            {
            GameObject objectiveitem3 = Instantiate(ObjectiveSelectedprefabs[2], spawnPosition3, Quaternion.identity);
            }
                
    }

    void Update()
    {
                

    }
}
