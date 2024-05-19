using UnityEngine;

public class HideAndShowObject : MonoBehaviour
{
    // Reference to the Renderer component of the GameObject
    private Renderer objRenderer;

    void Start()
    {
        // Get the Renderer component
        objRenderer = GetComponent<Renderer>();

        // Hide the object when the game starts
        if (objRenderer != null)
        {
            objRenderer.enabled = false;
        }
    }

    void Update()
    {
        // Check if the "P" key is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Toggle the visibility of the object
            if (objRenderer != null)
            {
                objRenderer.enabled = !objRenderer.enabled;
            }
        }
    }
}
