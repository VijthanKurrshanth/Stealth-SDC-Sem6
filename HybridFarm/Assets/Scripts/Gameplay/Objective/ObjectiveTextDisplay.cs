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
        
        
        StartCoroutine(DisplayObjectiveText());
        
    }

    private IEnumerator DisplayObjectiveText()
    {
        yield return new WaitForSeconds(0.1f); // Adjust the delay time as needed

        if (objectiveFigure.Green_Correct_Indicators[correctMarkNumber]==true)
        {
            
            if (objectiveFigure.NumberinIndexPostioninObjectiveItems[index]>0)
            {
                ObjectiveText.text = "1" + "/" + objectiveFigure.NumberinIndexPostioninObjectiveItems[index].ToString();
            }
            
        }
 
        
    }




    void Update()
    {
        
    }
}
