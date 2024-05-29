using UnityEngine;

public class FactoryPurchaseButtonOnClick : MonoBehaviour
{
    // Assign these in the Inspector
    public GameObject[] renderersToHide;
    public bool isVisible = false;
    public GameObject targetObjectToShow;
    public float targetX; // The X position to move to
    public float targetY; // The Y position to move to

    public GameObject targetButtonObjectToMove;
    private HideAndShowObjectForLevel1Factories hideAndShowObjectForLevel1Factories;

    public GameObject targetObjectForCostofFactoryReduction;
    private FactoryPurchaseButtonReaction FactoryPurchaseButtonReaction;
    private Objective objective;
    

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
            
            if (objective.collected_amount_of_money>=FactoryPurchaseButtonReaction.CostOfFactory)
            {
            hideAndShowObjectForLevel1Factories.isVisible=true;
            objective.collected_amount_of_money-= FactoryPurchaseButtonReaction.CostOfFactory;
            objective.factoryNamesLevels[FactoryPurchaseButtonReaction.indexOfFactoryAssigned] += 1;
            targetButtonObjectToMove.transform.position = new Vector3(targetX, targetY, targetButtonObjectToMove.transform.position.z);
            
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
