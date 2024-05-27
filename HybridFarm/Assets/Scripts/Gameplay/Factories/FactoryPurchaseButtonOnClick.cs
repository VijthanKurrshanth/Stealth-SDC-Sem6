using UnityEngine;

public class FactoryPurchaseButtonOnClick : MonoBehaviour
{
    // Assign these in the Inspector
    public GameObject[] renderersToHide;
    public GameObject targetObjectToShow;
    public float targetX; // The X position to move to
    public float targetY; // The Y position to move to

    public GameObject targetButtonObjectToMove;
    private HideAndShowObjectForLevel1Factories hideAndShowObjectForLevel1Factories;

    public GameObject targetObjectForCostofFactoryReduction;
    private FactoryPurchaseButtonReaction FactoryPurchaseButtonReaction;
    private Objective objective;
    public bool isVisible = false;

    void Start()
    {
        
        hideAndShowObjectForLevel1Factories = targetObjectToShow.GetComponent<HideAndShowObjectForLevel1Factories>();
        FactoryPurchaseButtonReaction = targetObjectForCostofFactoryReduction.GetComponent<FactoryPurchaseButtonReaction>();  
        
        objective = FindObjectOfType<Objective>();
            

       
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
            if (objective.collected_amount_of_money>=FactoryPurchaseButtonReaction.CostOfFactory)
            {
            objective.collected_amount_of_money-= FactoryPurchaseButtonReaction.CostOfFactory;
            //Debug.Log("enter");
            }

            else 
            {
                //arrow mark indication show cash not enough...
            }

        }
        else
        {
            Debug.LogWarning("HideAndShowObjectForLevel1Factories is not initialized.");
        }
    }
}
