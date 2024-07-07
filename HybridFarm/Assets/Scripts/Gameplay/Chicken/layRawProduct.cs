using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class layRawProduct : MonoBehaviour
{
    public GameObject RawProductPrefab; // Reference to the prefab you want to spawn
    public float spawnInterval = 15f; // Interval between each spawn

    private float timer = 0f;
    grassSpawnDestroy grassSpawner;

    FarmAnimalPredatorCollision farmAnimalPredatorCollision;

    // Start is called before the first frame update
    void Start()
    {
        farmAnimalPredatorCollision = FindObjectOfType<FarmAnimalPredatorCollision>();
        // Initialize the timer
        timer = spawnInterval;
        grassSpawner =FindObjectOfType<grassSpawnDestroy>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // Decrease the timer

        {   
            if ( !grassSpawner.checkForGrassNotPresence() && !farmAnimalPredatorCollision.isDontLay)  // if grass exist this will be true
            {   
                timer -= Time.deltaTime;
                // If the timer reaches zero or less, spawn the prefab and reset the timer
                if (timer <= 0) 
                {
                    SpawnRawProduct();
                    timer = Random.Range(spawnInterval-1,spawnInterval+1);
                }
            }

        }
    }

    void SpawnRawProduct()
    {
        // Instantiate the Raw product prefab slightly front of the current object's position and rotation
        Instantiate(RawProductPrefab, transform.position+ new Vector3 (0,-0.2f,-0.05f), transform.rotation);
    }
}
