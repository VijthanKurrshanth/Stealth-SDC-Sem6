using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmAnimalPredatorCollision : MonoBehaviour
{

    public Vector3 targetLeftPosition; 
    public Vector3 targetRightPosition; 

    private Vector3 targetPosition;

    private float speedOfThrow;
    private float scaleReductionSpeed;

    private float rotationSpeed;

    public string nameOfAnimal;

    public bool isDontLay = false;

    //private CircleCollider2D circleCollider2D;

    Objective objective;
    

  

    void Start ()
    {
        //circleCollider2D = GetComponent<CircleCollider2D>();
        objective = FindObjectOfType<Objective>();
        
        targetLeftPosition = new Vector3(-7.31f, 3.43f, 5);
        targetRightPosition = new Vector3(7.31f, 3.43f, 5);

        speedOfThrow = 10f;
        scaleReductionSpeed = 1.5f;
        rotationSpeed = 2000f;


    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Predators"))
        {

            isDontLay=true;
            
            
            StartCoroutine (ThrowAndDestoryGameAnimal());
            //Destroy(gameObject);

            for (int i = 0; i<objective.itemsname.Length; i++)
            {
                if (objective.itemsname[i] == nameOfAnimal)
                {
                    objective.collected_items[i]-=1;
                }
            }

            

        }

        else 
        {
            isDontLay=false;
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


       
        while (Vector3.Distance(transform.position, targetPosition) > 0.05f)
        {
            //circleCollider2D.enabled = false;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speedOfThrow * Time.deltaTime);
            transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.zero, scaleReductionSpeed * Time.deltaTime);
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

            yield return null;
        }

        Destroy(gameObject);
    }
}
