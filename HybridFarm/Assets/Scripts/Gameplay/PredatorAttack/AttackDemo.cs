using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDemo : MonoBehaviour
{
    public GameObject fox;
    public Vector2 spawnRange = new Vector2(3, 10);
    public Vector2 fieldRange = new Vector2(3, 1);
    public float moveSpeed = 40.0f; // Speed at which the object will move to the new position
    public float spawnDelay = 2.0f; // Delay before spawning the fox

    bool canSpawn = true; // Flag to control cooldown

    void Start()
    {
        // Start coroutine to spawn the fox after a delay
        StartCoroutine(SpawnFoxAfterDelay());
    }

    IEnumerator SpawnFoxAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(spawnDelay);

        // Spawn the fox
        SpawnObject(0); // Assuming 0 is the index for the fox
    }

    public void SpawnObject(int predatorIndex)
    {
        if (canSpawn)
        {
            // Generate random position within the spawn range
            Vector3 spawnPosition = new Vector3(
                Random.Range(-spawnRange.x, spawnRange.x),
                Random.Range(spawnRange.y, spawnRange.y),
                6.7f
            );

            // Spawn the object at the generated position
            GameObject spawnedObject = Instantiate(fox, spawnPosition, Quaternion.identity);

            // Calculate the new position within the field range while maintaining x position
            Vector3 targetPosition = new Vector3(
                spawnedObject.transform.position.x, // Maintain x position
                Random.Range(-fieldRange.y, fieldRange.y), // New y position within field range
                spawnedObject.transform.position.z // Maintain z position
            );

            // Move the object to the new position with specified speed
            StartCoroutine(MoveObject(spawnedObject.transform, targetPosition, moveSpeed));

            // Start the cooldown coroutine
            StartCoroutine(SpawnCoolDown());
        }
    }

    IEnumerator SpawnCoolDown()
    {
        canSpawn = false;
        yield return new WaitForSeconds(0.3f);
        canSpawn = true;
    }

    IEnumerator MoveObject(Transform objectToMove, Vector3 targetPosition, float moveSpeed)
    {
        
        float distance = Vector3.Distance(objectToMove.position, targetPosition);
       
        while (distance > Mathf.Epsilon)
        {
            // Move towards the target position
            objectToMove.position = Vector3.MoveTowards(objectToMove.position, targetPosition, moveSpeed * Time.deltaTime);

            
            distance = Vector3.Distance(objectToMove.position, targetPosition);

            // Yield until the next frame
            yield return null;
        }
    }
}
