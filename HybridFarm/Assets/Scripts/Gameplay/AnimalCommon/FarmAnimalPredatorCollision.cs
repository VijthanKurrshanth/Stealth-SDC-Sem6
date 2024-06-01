using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmAnimalPredatorCollision : MonoBehaviour
{

    public Vector3 targetLeftPosition; 
    public Vector3 targetRightPosition; 

    private Vector3 targetPosition;

    public float speedOfThrow = 5;
    public float scaleReductionSpeed = 0.1f;

    public float rotationSpeed = 100f;
    

  

    void Start ()
    {

        
        targetLeftPosition = new Vector3(0, 0, transform.position.z);
        targetRightPosition = new Vector3(0, 0, transform.position.z);
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Predators"))
        {
            
            
            StartCoroutine (ThrowAndDestoryGameAnimal());
            //Destroy(gameObject);
        }

    
    }


    private IEnumerator ThrowAndDestoryGameAnimal()
    {
        yield return new WaitForSeconds(0.001f);

        string selectedDirection = Random.Range(0, 2) == 0 ? "Left" : "Right"; // select one of these two random...

        if (selectedDirection == "Left")
        {
            targetPosition = targetLeftPosition;  
        }
        else if (selectedDirection == "Right")
        {
             targetPosition = targetRightPosition;
        }
        
        else
        {
            // Do nothing here...
        }


       
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speedOfThrow * Time.deltaTime);
            transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.zero, scaleReductionSpeed * Time.deltaTime);
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            yield return null;
        }

        Destroy(gameObject);
    }
}
