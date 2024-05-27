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

    Objective objective;
    public string factoryname;

    public string nameoftheRawMaterial;

    //[SerializeField] private string nameoftheSpawnObject;

    void Start()
    {
        objective = FindObjectOfType<Objective>();
    }

    void Update()
    {
        // Check if the object is moving
        if (isMoving && movingObject != null)
        {
            // Move the object towards the target position
            movingObject.transform.position = Vector2.MoveTowards(movingObject.transform.position, targetPosition, speed * Time.deltaTime);

            // Check if the object has reached the target position
            if (Vector2.Distance(movingObject.transform.position, targetPosition) < 0.01f)
            {
                // Destroy the object when it reaches the target position
                Destroy(movingObject);
                isMoving = false; // Reset the moving flag

                // Update the collected items in the objective
                // for (int i = 0; i < objective.collected_items.Length; i++)
                // {
                //     if (objective.itemsname[i] == nameoftheSpawnObject)
                //     {
                //         objective.collected_items[i]++;
                //     }
                // }

                // Spawn the processed output object at the specified position
                if (ProcessedOutputToSpawn != null)
                {
                    Instantiate(ProcessedOutputToSpawn, processedOutputSpawnPosition, Quaternion.identity);
                }
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
                indexofSpawnObject=i;
            }
        }

        if (objective.collected_items[indexofSpawnObject]>0){


        // Check if the clicked object has the specified factory tag
            if (gameObject.CompareTag(factoryname))
            {
                // Spawn the sprite at the spawn position
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
}
