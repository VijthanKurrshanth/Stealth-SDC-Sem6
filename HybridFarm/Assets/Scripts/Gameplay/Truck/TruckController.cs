using UnityEngine;
using UnityEngine.UI;

public class TruckController2D : MonoBehaviour
{
    public GameObject prefabToSpawn; // Assign the prefab in the Inspector
    public Vector3 spawnPosition; // Public variable to set the spawn position in the Inspector
    private SpriteRenderer currentRenderer;
    private Color originalColor;
    private Color hoverColor = Color.white;
    private Color clickColor = Color.red;


    void Update()
    {
        // Get the mouse position in world coordinates
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        // Check if the ray hits a collider
        if (hit.collider != null)
        {
            // Check if the object has the tag "Truck"
            if (hit.collider.CompareTag("Truck"))
            {
                SpriteRenderer renderer = hit.collider.GetComponent<SpriteRenderer>();

                // Change the color to hoverColor if not already hovered
                if (renderer != currentRenderer)
                {
                    ResetColor();
                    currentRenderer = renderer;
                    originalColor = currentRenderer.color;
                    currentRenderer.color = hoverColor;
                }

                // Check for mouse click
                if (Input.GetMouseButtonDown(0))
                {   
                    
                    // Change the color to clickColor
                    currentRenderer.color = clickColor;

                    // Spawn the prefab at the specified spawn position
                    Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

                    // Pause the game
                    Time.timeScale = 0;
                }
            }
            else
            {
                ResetColor();
            }
        }
        else
        {
            ResetColor();
        }
    }

    void ResetColor()
    {
        // Reset the color of the previously hovered object
        if (currentRenderer != null)
        {
            currentRenderer.color = originalColor;
            currentRenderer = null;
        }
    }

    
}
