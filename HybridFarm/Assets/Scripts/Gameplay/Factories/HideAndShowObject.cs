using UnityEngine;

public class HideAndShowObject : MonoBehaviour
{
    // Array to hold all Renderer components of the GameObject and its children
    private Renderer[] renderers;

    void Start()
    {
        // Get all Renderer components in the GameObject and its children
        renderers = GetComponentsInChildren<Renderer>();

        // Hide the object and its children when the game starts
        SetRenderersEnabled(false);
    }

    void Update()
    {
        // Check if the "P" key is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Toggle the visibility of the object and its children
            SetRenderersEnabled(!renderers[0].enabled);
        }
    }

    // Method to enable or disable all Renderer components
    private void SetRenderersEnabled(bool isEnabled)
    {
        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = isEnabled;
        }
    }
}
