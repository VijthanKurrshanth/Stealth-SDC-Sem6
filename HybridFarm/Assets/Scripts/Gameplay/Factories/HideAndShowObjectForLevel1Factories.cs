using UnityEngine;

public class HideAndShowObjectForLevel1Factories : MonoBehaviour
{
    private Renderer[] renderers;

    // Public boolean to manually control visibility
    public bool isVisible = false;
    
    // Public integer for the cost of the factory
    

    void Start()
    {
        // Get all Renderer components in the GameObject and its children
        renderers = GetComponentsInChildren<Renderer>();

        // Set the initial visibility based on the isVisible variable
        SetRenderersEnabled(isVisible); //false initially
    }

    void Update()
    {

        
        if (isVisible)
        {
            // Toggle the visibility of the object and its children
            SetRenderersEnabled(true);
        }

        else {
            SetRenderersEnabled(false);
        }
    }

    // Method to enable or disable all Renderer components
    public void SetRenderersEnabled(bool isEnabled)
    {
        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = isEnabled;
        }
    }

}
