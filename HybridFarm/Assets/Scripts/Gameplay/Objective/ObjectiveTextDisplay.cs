using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using TMPro;


public class ObjectiveTextDisplay : MonoBehaviour
{
    public TextMeshProUGUI ObjectiveText; 
    Objective objective;
    ObjectiveFigure objectiveFigure;

    void Start()
    {
        objective = FindObjectOfType<Objective>();
        objectiveFigure=FindObjectOfType<ObjectiveFigure>();
        ObjectiveText = GetComponent<TextMeshProUGUI>(); // Get the TextMeshProUGUI component attached to the same GameObject
        if (ObjectiveText == null)
        {
            Debug.LogError("Timer Sript requires a TextMeshProUGUI component attached to the same GameObject.");
            return;
        }

        //Debug.Log(objectiveFigure.IndexPostioninObjectiveItems[0]);
        //ObjectiveText.text= "1" + "/" + objectiveFigure.IndexPostioninObjectiveItems[0].ToString();   // need to get from colletables
        if (objectiveFigure.IndexPostioninObjectiveItems.Length > 0)
        {
            Debug.Log(objectiveFigure.IndexPostioninObjectiveItems[0]);
            ObjectiveText.text = "1" + "/" + objectiveFigure.IndexPostioninObjectiveItems[0].ToString();
        }
        else
        {
            Debug.LogError("IndexPostioninObjectiveItems array is empty.");
        }
    
    
    
    }

    void Update()
    {
        
    }

    
}
