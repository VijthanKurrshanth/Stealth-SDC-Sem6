using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableWarehouseToFactoryTransform : MonoBehaviour
{
    public float speed = 18f; 
    public Vector3 targetPosition = new Vector3(0f, -4f, -3f); 

    public Sprite spriteToMove; // Sprite to be instantiated
    public Vector3 spawnPosition = new Vector3(0f, -4f, -3f); 
    private bool isMoving = false; 
    private GameObject movingObject; 

    public GameObject ProcessedOutputToSpawn; // Object to spawn after sprite...
    public Vector3 processedOutputSpawnPosition = new Vector3(0f, -4f, -3f); 

    public float delayBeforeSpawn = 2f; // Delay for spawning processed...

    public float cooldownTime = 5f; // Cooldown time between spawns
    private float lastSpawnTime = -Mathf.Infinity; // Time when the last object was spawned...

    Objective objective;
    public string factoryname;
    public string nameoftheRawMaterial;

    private AnimateFactory animateFactory;

    void Start()
    {
        objective = FindObjectOfType<Objective>();
        animateFactory = FindObjectOfType<AnimateFactory>();
    }

    void Update()
    {




        if (isMoving && movingObject != null)
        {
            movingObject.transform.position = Vector2.MoveTowards(movingObject.transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector2.Distance(movingObject.transform.position, targetPosition) < 0.01f)
            {
                // Destroy the object
                animateFactory.canAnimate = true;
                Destroy(movingObject);

                isMoving = false; // Reset the moving flag

                // Spawn the processed output object after a delay
                Invoke("SpawnProcessedOutput", delayBeforeSpawn);
            }
        
        
        }



    }

    void OnMouseDown()
    {



        
        if (Time.time - lastSpawnTime < cooldownTime)
        {
            return; // Exit the method if still  cooldown .........
        }

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

            
            if (gameObject.CompareTag(factoryname))
            {
                
                if (spriteToMove != null)
                {
                    movingObject = new GameObject("MovingSprite");
                    movingObject.transform.position = spawnPosition;
                    SpriteRenderer renderer = movingObject.AddComponent<SpriteRenderer>();
                    renderer.sprite = spriteToMove;
                    isMoving = true; // Set the flag to start moving 
                    lastSpawnTime = Time.time; // Update the last spa....
                    objective.collected_items[indexofSpawnObject] -= 1;
                }
            }
        }
    }

    void SpawnProcessedOutput()
    {

        
        
        if (ProcessedOutputToSpawn != null)
        {
            Instantiate(ProcessedOutputToSpawn, processedOutputSpawnPosition, Quaternion.identity);
            animateFactory.canAnimate = false;
        }
    }
}
