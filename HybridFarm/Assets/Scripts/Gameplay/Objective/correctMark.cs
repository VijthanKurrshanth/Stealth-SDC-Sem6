using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class correctMark : MonoBehaviour
{
    // Start is called before the first frame update
    Objective objective;
    ObjectiveFigure objectiveFigure;

    [SerializeField] int correctMarkNumber = 0;
    GameObject markObject; // corrrect object

    void Start()
    {
        objective = FindObjectOfType<Objective>();
        objectiveFigure = FindObjectOfType<ObjectiveFigure>();
        // Assuming the object you want to show/hide is the same GameObject this script is attached to
        markObject = gameObject;
        // Initially hide the object
        markObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log((objective.Green_Correct_Indicators[0]));
        

        if (objective.Green_Correct_Indicators[correctMarkNumber]==true)
        {
            
            markObject.SetActive(true);
            //StartCoroutine(visibleTheobject());
            
        }
        else 
        {
            
            markObject.SetActive(false);
            //StartCoroutine(hideTheobject());
        }
    }


    // private IEnumerator visibleTheobject()
    // {
    //     yield return new WaitForSeconds(0.5f);
    //     markObject.SetActive(true);

    // }

    // private IEnumerator hideTheobject()
    // {
    //     yield return new WaitForSeconds(0.5f);
    //     markObject.SetActive(false);
    // }
}
