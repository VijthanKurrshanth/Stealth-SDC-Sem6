using UnityEngine;

public class FactoryPurchaseButtonOnClick : MonoBehaviour
{
    // Assign these in the Inspector
    public GameObject[] renderersToHide;
    public GameObject targetObjectForHideAndShow;
    private HideAndShowObjectForLevel1Factories hideAndShowObjectForLevel1Factories;

    public GameObject targetObjectForCostofFactoryReduction;
    private FactoryPurchaseButtonReaction FactoryPurchaseButtonReaction;
    private MoneyScript moneyScript;
    public bool isVisible = false;

    void Start()
    {
        if (targetObjectForHideAndShow != null)
        {
            hideAndShowObjectForLevel1Factories = targetObjectForHideAndShow.GetComponent<HideAndShowObjectForLevel1Factories>();
            FactoryPurchaseButtonReaction = targetObjectForCostofFactoryReduction.GetComponent<FactoryPurchaseButtonReaction>();
            moneyScript = FindObjectOfType<MoneyScript>();
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
            moneyScript.moneyValue-= 
        }
        else
        {
            Debug.LogWarning("HideAndShowObjectForLevel1Factories is not initialized.");
        }
    }
}
