using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmAnimalPredatorCollision : MonoBehaviour
{
    

  
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Predators"))
        {
            
            Destroy(gameObject);
        }
    }
}
