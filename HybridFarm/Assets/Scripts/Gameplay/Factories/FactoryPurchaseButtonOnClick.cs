using UnityEngine;

public class FactoryPurchaseButtonOnClick : MonoBehaviour
{
    // Assign these in the Inspector
    public GameObject[] renderersToHide;
    public bool isVisible = false;
    //public GameObject targetObjectToShow;
    public float factoryTargetX; // The X position to move to
    public float factoryTargetY; // The Y position to move to

    //public GameObject targetButtonObjectToMove;
    public GameObject FactoryToSpawn;
    //private HideAndShowObjectForLevel1Factories hideAndShowObjectForLevel1Factories;

    public GameObject targetObjectForCostofFactoryReduction;
    private FactoryPurchaseButtonReaction FactoryPurchaseButtonReaction;
    private Objective objective;
    

    void Start()
    {
        
        //hideAndShowObjectForLevel1Factories = targetObjectToShow.GetComponent<HideAndShowObjectForLevel1Factories>();
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
                    Debug.LogWarning("One of the objects in renderersToHide is null....");
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
        
        if (objective.collected_items[0]>=FactoryPurchaseButtonReaction.CostOfFactory)
        {
        //hideAndShowObjectForLevel1Factories.isVisible=true;
        objective.collected_items[0]-= FactoryPurchaseButtonReaction.CostOfFactory;
        //objective.factoryNamesLevels[FactoryPurchaseButtonReaction.indexOfFactoryAssigned] += 1;
        GameObject newFactory = Instantiate(FactoryToSpawn, new Vector3(factoryTargetX,factoryTargetY,5), Quaternion.identity);
        }

        else 
        {
        //arrow mark indication show cash not enough...
        }

    
    }
}
