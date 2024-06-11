using UnityEngine;

public class TruckController : MonoBehaviour
{
    public GameObject prefabToSpawn; // Assign the prefab in the Inspector
    public Vector3 spawnPosition; // Public variable to set the spawn position in the Inspector
    private Renderer currentRenderer;
    private Color originalColor;
    private Color hoverColor = Color.yellow;
    private Color clickColor = Color.red;

    void Update()
    {
        // Convert mouse position to a ray
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Check if the ray hits a collider
        if (Physics.Raycast(ray, out hit))
        {
            // Check if the object has the tag "Truck"
            if (hit.collider.CompareTag("Truck"))
            {
                Renderer renderer = hit.collider.GetComponent<Renderer>();

                // Change the color to hoverColor if not already hovered
                if (renderer != currentRenderer)
                {
                    ResetColor();
                    currentRenderer = renderer;
                    originalColor = currentRenderer.material.color;
                    currentRenderer.material.color = hoverColor;
                }

                // Check for mouse click
                if (Input.GetMouseButtonDown(0))
                {
                    // Change the color to clickColor
                    currentRenderer.material.color = clickColor;

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
            currentRenderer.material.color = originalColor;
            currentRenderer = null;
        }
    }
}
