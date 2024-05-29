using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateFactory : MonoBehaviour
{
    public bool canAnimate = false;

    public GameObject factoryToAnimate1;
    public GameObject factoryToAnimate2;

    void Update()
    {
        if (canAnimate)
        {
            StartCoroutine(AnimateTheFactory());
        }
        else
        {
            factoryToAnimate1.transform.localScale = new Vector3(1f, 1f, 1f);
            factoryToAnimate2.transform.localScale = new Vector3(1f, 1f, 1f);
            StopCoroutine(AnimateTheFactory());
        }
    }

    IEnumerator AnimateTheFactory()
    {
        
        
        //yield return new WaitForSeconds(0.01f);
        factoryToAnimate1.transform.localScale = new Vector3(1.1f, 1.1f, 1f);
        factoryToAnimate2.transform.localScale = new Vector3(1.1f, 1.1f, 1f);
        yield return new WaitForSeconds(0.5f);
        factoryToAnimate1.transform.localScale = new Vector3(1f, 1f, 1f);
        factoryToAnimate2.transform.localScale = new Vector3(1f, 1f, 1f);
        yield return new WaitForSeconds(0.5f);
        //Debug.Log(gameObject.name + " finished animation.");
    }
}
