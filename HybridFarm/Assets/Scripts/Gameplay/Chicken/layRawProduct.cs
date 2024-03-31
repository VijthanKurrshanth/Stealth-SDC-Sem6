using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layRawProduct : MonoBehaviour
{
    public GameObject RawProductPrefab; // Reference to the prefab you want to spawn
    public float spawnInterval = 15f; // Interval between each spawn

    private float timer = 0f;
    grassSpawnDestroy grassSpawner;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the timer
        timer = spawnInterval;
        grassSpawner =FindObjectOfType<grassSpawnDestroy>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // Decrease the timer

        {   
            if ( !grassSpawner.checkForGrassPresence())  // if grass exist this will be true
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
        // Instantiate the egg prefab at the current object's position and rotation
        Instantiate(RawProductPrefab, transform.position, transform.rotation);
    }
}
