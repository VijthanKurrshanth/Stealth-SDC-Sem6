using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Vector2 spawnRange = new Vector2 (3 , 10);
    public Vector2 fieldRange= new Vector2 (3, 1) ;
    public float moveSpeed =50.0f; // Speed at which the object will move to the new position

    public void SpawnObject()
    {
        // Generate random position within the spawn range
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnRange.x, spawnRange.x),
            Random.Range(spawnRange.y, spawnRange.y),
            0
        );

        // Spawn the object at the generated position
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        // Calculate the new position within the field range while maintaining x position
        Vector3 targetPosition = new Vector3(
            spawnedObject.transform.position.x, // Maintain x position
            Random.Range(-fieldRange.y, fieldRange.y), // New y position within field range
            spawnedObject.transform.position.z // Maintain z position
        );

        // Move the object to the new position with specified speed
        StartCoroutine(MoveObject(spawnedObject.transform, targetPosition, moveSpeed));
    }

    IEnumerator MoveObject(Transform objectToMove, Vector3 targetPosition, float moveSpeed)
    {
        // Calculate distance to move
        float distance = Vector3.Distance(objectToMove.position, targetPosition);

        // Continue moving until the object reaches the target position
        while (distance > Mathf.Epsilon)
        {
            // Move towards the target position
            objectToMove.position = Vector3.MoveTowards(objectToMove.position, targetPosition, moveSpeed * Time.deltaTime);

            // Recalculate the distance to the target position
            distance = Vector3.Distance(objectToMove.position, targetPosition);

            // Yield until the next frame
            yield return null;
        }
    }
}
