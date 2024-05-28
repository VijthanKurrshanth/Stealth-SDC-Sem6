using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableWarehouseToFactoryTransform : MonoBehaviour
{
    public float speed = 18f; // Speed at which the object moves
    public Vector3 targetPosition = new Vector3(0f, -4f, -3f); // Target position for the object to move towards

    public Sprite spriteToMove; // Sprite to be instantiated
    public Vector3 spawnPosition = new Vector3(0f, -4f, -3f); // Serialized variable for spawn position
    private bool isMoving = false; // Flag to check if the object is currently moving
    private GameObject movingObject; // Reference to the spawned moving object

    public GameObject ProcessedOutputToSpawn; // Object to spawn after sprite is destroyed
    public Vector3 processedOutputSpawnPosition = new Vector3(0f, -4f, -3f); // Position to spawn the processed output

    public float delayBeforeSpawn = 2f; // Delay for spawning the processed output object

    Objective objective;
    public string factoryname;
    public string nameoftheRawMaterial;

    void Start()
    {
        objective = FindObjectOfType<Objective>();
    }

    void Update()
    {




        
        if (isMoving && movingObject != null)
        {
            
            movingObject.transform.position = Vector2.MoveTowards(movingObject.transform.position, targetPosition, speed * Time.deltaTime);

            
            if (Vector2.Distance(movingObject.transform.position, targetPosition) < 0.01f)
            {
                // Destroy the object.....
                Destroy(movingObject);
                isMoving = false; // Reset  moving flag....

                // processed output object after a delay
                Invoke("SpawnProcessedOutput", delayBeforeSpawn);
            }
        }
    }

    void OnMouseDown()
    {



        int indexofSpawnObject = 0;
        for (int i = 0; i < objective.collected_items.Length; i++)
        {
            if (objective.itemsname[i] == nameoftheRawMaterial)
            {
                indexofSpawnObject = i;
            }
        }

        if (objective.collected_items[indexofSpawnObject] > 0)
        {
            // Check for clicked object has  factory tag....
            if (gameObject.CompareTag(factoryname))
            {
                // Spawn the sprite .....
                if (spriteToMove != null)
                {
                    movingObject = new GameObject("MovingSprite");
                    movingObject.transform.position = spawnPosition;
                    SpriteRenderer renderer = movingObject.AddComponent<SpriteRenderer>();
                    renderer.sprite = spriteToMove;
                    isMoving = true; // Set the flag to start moving the object
                }
            }
        }
    }

    void SpawnProcessedOutput()
    {


        // Spawn the processed output 
        if (ProcessedOutputToSpawn != null)
        {
            Instantiate(ProcessedOutputToSpawn, processedOutputSpawnPosition, Quaternion.identity);
        }


        
    }
}
