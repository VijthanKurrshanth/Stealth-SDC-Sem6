using UnityEngine;

public class FactoryPurchaseButtonOnClick : MonoBehaviour
{
    // Assign these in the Inspector
    public GameObject[] renderersToHide;
    public GameObject targetObject;
    private HideAndShowObjectForLevel1Factories hideAndShowObjectForLevel1Factories;
    public bool isVisible = false;

    void Start()
    {
        if (targetObject != null)
        {
            hideAndShowObjectForLevel1Factories = targetObject.GetComponent<HideAndShowObjectForLevel1Factories>();
            if (hideAndShowObjectForLevel1Factories == null)
            {
                Debug.LogError("HideAndShowObjectForLevel1Factories component not found on targetObject.");
            }
        }
        else
        {
            Debug.LogError("Target object is not assigned.");
        }
    }

    // Call this method when the button is pressed
    public void ToggleGroups()
    {
        // Hide the first group of objects
        if (renderersToHide != null)
        {
            foreach (GameObject obj in renderersToHide)
            {
                if (obj != null)
                {
                    obj.SetActive(false);
                }
                else
                {
                    Debug.LogWarning("One of the objects in renderersToHide is null.");
                }
            }
        }
        else
        {
            Debug.LogWarning("RenderersToHide array is not assigned.");
        }
    }

    public void OnButtonClick()
    {
        if (hideAndShowObjectForLevel1Factories != null)
        {
            hideAndShowObjectForLevel1Factories.isVisible=true;
        }
        else
        {
            Debug.LogWarning("HideAndShowObjectForLevel1Factories is not initialized.");
        }
    }
}
