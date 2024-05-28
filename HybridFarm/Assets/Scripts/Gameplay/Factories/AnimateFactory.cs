using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateFactory : MonoBehaviour
{
    // Start is called before the first frame update
    //GameObject gameObject;
    public bool canAnimate = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        if (canAnimate)
        {
            
            StartCoroutine(AnimateTheFactory());

            


        } 

        else 
        {
            //nothing
        }
        
    }

    private IEnumerator AnimateTheFactory()
    {
        yield return new WaitForSeconds (0.01f);
        gameObject.transform.localScale = new Vector3 (1.1f,1.1f,1f);
        yield return new WaitForSeconds (0.5f);
        gameObject.transform.localScale = new Vector3 (1f,1f,1f);
        yield return new WaitForSeconds (0.5f);

    }



}
