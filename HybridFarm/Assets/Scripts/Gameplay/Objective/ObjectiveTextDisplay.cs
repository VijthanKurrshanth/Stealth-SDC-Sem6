using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;

public class ObjectiveTextDisplay : MonoBehaviour
{
    public TextMeshProUGUI ObjectiveText; 
    Objective objective;
    ObjectiveFigure objectiveFigure;

    [SerializeField] int index=0;
    [SerializeField] int correctMarkNumber = 0;

    void Start()
    {
        objective = FindObjectOfType<Objective>();
        objectiveFigure = FindObjectOfType<ObjectiveFigure>();
        ObjectiveText = GetComponent<TextMeshProUGUI>(); // Get the TextMeshProUGUI component attached to the same GameObject
        if (ObjectiveText == null)
        {
            Debug.LogError("Timer Script requires a TextMeshProUGUI component attached to the same GameObject.");
            return;
        }
        
        
        //StartCoroutine(DisplayObjectiveText());
        
    }


    void Update()
    {
        StartCoroutine(DisplayObjectiveText());
    }

    private IEnumerator DisplayObjectiveText()
    {
        yield return new WaitForSeconds(0.05f); // Adjust the delay time as needed


        Debug.Log(objectiveFigure.Green_Correct_Indicators[0]);

        if (objectiveFigure.Green_Correct_Indicators[correctMarkNumber]== false)
        {
            //Debug.Log("Coming here");
            if (objectiveFigure.NumberinIndexPostioninObjectiveItems[index]>0)
            {
                //Debug.Log("Coming here");
                ObjectiveText.text = objective.collected_items[objectiveFigure.inIndexPostioninObjectiveItems[index]].ToString() + "/" + objectiveFigure.NumberinIndexPostioninObjectiveItems[index].ToString();
            }

           
            
        }

        else if(objectiveFigure.Green_Correct_Indicators[correctMarkNumber]==true)
        {
                ObjectiveText.text="";
        }
 
        
    }


}
