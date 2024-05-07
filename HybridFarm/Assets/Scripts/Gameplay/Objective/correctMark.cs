using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class correctMark : MonoBehaviour
{
    // Start is called before the first frame update
    Objective objective;
    ObjectiveFigure objectiveFigure;

    //[SerializeField] int correctMarkNumber = 0;
    public GameObject greenCorrectMark1; // corrrect object
    public GameObject greenCorrectMark2;
    public GameObject greenCorrectMark3;

    void Start()
    {
        objective = FindObjectOfType<Objective>();
        objectiveFigure = FindObjectOfType<ObjectiveFigure>();
        // Assuming the object you want to show/hide is the same GameObject this script is attached to
        //greenCorrectMark1 = gameObject;
        // Initially hide the object
        //markObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(objectiveFigure.Green_Correct_Indicators[0]);
        //Debug.Log(objectiveFigure.Green_Correct_Indicators[1]);
        //Debug.Log(objectiveFigure.Green_Correct_Indicators[2]);
        

        if (objectiveFigure.Green_Correct_Indicators[0]==true)
        {
            
            greenCorrectMark1.SetActive(true);
            //StartCoroutine(visibleTheobject());
            
        }
        else 
        {
            
            greenCorrectMark1.SetActive(false);
            //StartCoroutine(hideTheobject());
        }


        if (objectiveFigure.Green_Correct_Indicators[1]==true)
        {
            
            greenCorrectMark2.SetActive(true);
            //StartCoroutine(visibleTheobject());
            
        }
        else 
        {
            
            greenCorrectMark2.SetActive(false);
            //StartCoroutine(hideTheobject());
        }


        if (objectiveFigure.Green_Correct_Indicators[2]==true)
        {
            
            greenCorrectMark3.SetActive(true);
            //StartCoroutine(visibleTheobject());
            
        }
        else 
        {
            
            greenCorrectMark3.SetActive(false);
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
