using UnityEngine;

public class HideAndShowObjectForLevel1Factories : MonoBehaviour
{
    private Renderer[] renderers;

    // Public boolean to manually control visibility
    public bool isVisible = false;
    
    // Public integer for the cost of the factory
    public int CostOfFactory = 0;

    void Start()
    {
        // Get all Renderer components in the GameObject and its children
        renderers = GetComponentsInChildren<Renderer>();

        // Set the initial visibility based on the isVisible variable
        SetRenderersEnabled(isVisible); //false initially
    }

    void Update()
    {
        
        // Check if the "L" key is pressed
        if (isVisible)
        {
            // Toggle the visibility of the object and its children
            isVisible = true;
            SetRenderersEnabled(isVisible);
        }

        else {
            SetRenderersEnabled(!isVisible);
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
