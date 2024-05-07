using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using System.Collections;

public class ObjectiveFigure : MonoBehaviour
{
    Objective objective;
    public GameObject[] ObjectiveSelectedprefabs;

    public int[] NumberinIndexPostioninObjectiveItems;
    public int[] inIndexPostioninObjectiveItems;
    public bool?[] Green_Correct_Indicators;
    private int flag =0;


    void Start()
    {

        objective = FindObjectOfType<Objective>();
        ObjectiveSelectedprefabs = new GameObject[] {null,null,null};


        NumberinIndexPostioninObjectiveItems= new int[] {0,0,0};
        inIndexPostioninObjectiveItems= new int[] {13,13,13};

        



        for (int i = 0; i < objective.items.Length; i++)
        {
            
            if (objective.items[i]>0)
            {
                inIndexPostioninObjectiveItems[flag]=i;
                NumberinIndexPostioninObjectiveItems[flag]=objective.items[i];
                ObjectiveSelectedprefabs[flag]=objective.respectiveItemSprites[i];
                flag++;
            }
        }


        Debug.Log (inIndexPostioninObjectiveItems[0]);

        

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

        Green_Correct_Indicators = new bool?[] { null, null, null };

                
    }

    void Update()
    {
    
        StartCoroutine(GreenCorrectIndicatorBool()) ;

    }



    private IEnumerator GreenCorrectIndicatorBool()
    {
        yield return new WaitForSeconds(0.1f); // Adjust the delay time as needed
        
        for (int i=0; i< Green_Correct_Indicators.Length; i++)
        {
            //Debug.Log (objectiveFigure.inIndexPostioninObjectiveItems[i]);

            if (objective.collected_items[inIndexPostioninObjectiveItems[i]]>= objective.items[inIndexPostioninObjectiveItems[i]] )
            {
                Green_Correct_Indicators[i]= true;
            }
            else
            {
                Green_Correct_Indicators[i]= false;
            }
        }


       
    }
}
