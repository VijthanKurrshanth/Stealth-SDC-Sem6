using Unity.Burst.Intrinsics;
using UnityEngine;

public class collectableWarehouseTransform : MonoBehaviour
{
    private float speed = 18f; // Speed at which the object moves
    private Vector3 targetPosition= new Vector3 (0f, -4f ,-3f); // Target position for the object to move towards

    private bool isMoving = false; // Flag to check if the object is currently moving

    public GameObject   prefabToSpawninWarehouse;
    
    Objective objective;
    WarehouseResourceManagement warehouseResourceManagement;

    [SerializeField] string nameoftheSpawnObject;
    

    void Start ()
    {
        objective = FindObjectOfType<Objective>();
        warehouseResourceManagement = FindObjectOfType<WarehouseResourceManagement>();
    }
    void Update()
    {
        
        // Check if object is moving..
        if (isMoving)
        {
            // Move the object towards the target position
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Check if the object has reached the target position
            if (Vector2.Distance(transform.position, targetPosition) < 0.01f)
            {
                // Destroy the object when it reaches the target position
                
                for (int i=0; i< objective.collected_items.Length; i++)
                {
                if (objective.itemsname[i] == nameoftheSpawnObject)
                {
                    objective.collected_items[i]+=1;
                    objective.collected_itemsIncrements[i]+=1;
                    //Debug.Log(i);
                }

                
                Destroy(gameObject);
                
                
                }
            }
        }
    }

    void OnMouseDown()
    {
        // Check if the clicked object has the "collectables" tag
        if (gameObject.CompareTag("collectables"))
        {
            // Set the flag to start moving the object
            

            (int boxRequired, bool canCollect) = warehouseResourceManagement.SpaceAllocationWarehouse(nameoftheSpawnObject, warehouseResourceManagement.warehouseLevel);
            

            
            if (canCollect == true) 
            {
              isMoving = true; //if true object will move and destroyed...
              

              warehouseResourceManagement.warehouseAllignment( boxRequired, prefabToSpawninWarehouse ); // not completed
                
              warehouseResourceManagement.RemainingCapacityOfWarehouse -= boxRequired;

              //Debug.Log(warehouseResourceManagement.RemainingCapacityOfWarehouse);


            }
            


        }
    }









    



}



