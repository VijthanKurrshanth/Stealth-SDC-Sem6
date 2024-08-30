using UnityEngine;

public class HungerController : MonoBehaviour
{
    public float timer = 10f; // Time before the object gets hungry
    public bool isHungry = false;
    public float moveSpeed = 5f; // Speed at which the object moves towards grass
    public Animator animator; // Reference to the animator component
    private int grassCount = 0; // Count of eaten grass

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            isHungry = true;
        }

        if (isHungry)
        {
            FindAndMoveTowardsGrass();
        }
    }

    void FindAndMoveTowardsGrass()
    {
        GameObject[] grassObjects = GameObject.FindGameObjectsWithTag("grass");

        if (grassObjects.Length > 0)
        {
            GameObject chosenGrass = grassObjects[Random.Range(0, grassObjects.Length)]; // Choose a random grass object
            MoveTowards(chosenGrass.transform.position);

            // Check if the object has reached the chosen grass
            if (Vector3.Distance(transform.position, chosenGrass.transform.position) < 0.5f)
            {
                EatGrass(chosenGrass);
            }
        }
        else
        {
            Debug.LogWarning("No grass objects found!");
        }
    }

    void MoveTowards(Vector3 targetPosition)
    {
        // Calculate the direction to move towards the target position
        Vector3 direction = (targetPosition - transform.position).normalized;

        // Move towards the target position
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Play movement animation
        animator.SetBool("IsMoving", true);
    }

    void EatGrass(GameObject grass)
    {
        // Play eating animation
        animator.SetBool("IsMoving", false);
        animator.SetBool("IsEating", true);

        // Destroy the eaten grass after a delay
        Destroy(grass, 1f);

        // Reset isHungry flag
        isHungry = false;

        // Increment the count of eaten grass
        grassCount++;

        // Check if the object has eaten enough grass
        if (grassCount >= 3)
        {
            // Reset grass count
            grassCount = 0;

            // TODO: Implement any action after eating three grass (e.g., move to a different location)
        }
    }
}
