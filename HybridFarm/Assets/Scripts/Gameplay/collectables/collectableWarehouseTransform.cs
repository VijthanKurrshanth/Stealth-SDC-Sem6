using Unity.Burst.Intrinsics;
using UnityEngine;

public class collectableWarehouseTransform : MonoBehaviour
{
    private float speed = 18f; // Speed at which the object moves
    private Vector3 targetPosition= new Vector3 (0f, -4f ,-3f); // Target position for the object to move towards

    private bool isMoving = false; // Flag to check if the object is currently moving
    public GameObject collecatableBoxToSpawn;
    public Vector3 spawnPosition = new Vector3(-1.3f, -4.3f, -3.0f); // Serialized variable for spawn position
    Objective objective;

    [SerializeField] string nameoftheSpawnObject;
    [SerializeField] int numberOFEggs=0;



    void Start ()
    {
        objective = FindObjectOfType<Objective>();
    }
    void Update()
    {
        // Check if the object is moving
        if (isMoving)
        {
            // Move the object towards the target position
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Check if the object has reached the target position
            if (Vector2.Distance(transform.position, targetPosition) < 0.01f)
            {
                // Destroy the object when it reaches the target position
                Destroy(gameObject);
                for (int i=0; i< objective.collected_items.Length; i++)
                {
                if (objective.itemsname[i] == nameoftheSpawnObject)
                {
                    objective.collected_items[i]++;
                }
                
                }

                SpawnCollectableBox();

            }
        }
    }

    void OnMouseDown()
    {
        // Check if the clicked object has the "collectables" tag
        if (gameObject.CompareTag("collectables"))
        {
            // Set the flag to start moving the object
            isMoving = true;
        }
    }






    void SpawnCollectableBox()
    {
        // Check if the prefab to spawn is assigned
        if (collecatableBoxToSpawn != null)
        {
            // Instantiate the prefab at the position of this GameObject
            spawnPosition += new Vector3 (0,numberOFEggs * 0.25f,0); // this method not working
            Instantiate(collecatableBoxToSpawn, spawnPosition, Quaternion.identity);
            numberOFEggs+=1;
            spawnPosition= new Vector3 (-1.3f,-4.3f,-3.0f);


        }
        else
        {
            Debug.LogError("Prefab to spawn is not assigned in PrefabSpawner script!");
        }
    }



}



