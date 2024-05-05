using UnityEngine;
using TMPro;

public class ObjectiveText : MonoBehaviour
{
    Objective objective;
    public TextMeshProUGUI objectiveText; // Reference to the TextMeshProUGUI component to display the timer
    public int noOfItemCollected = 1;

    void Start()
    {
        // Get the TextMeshProUGUI component attached to the same GameObject
        objectiveText = GetComponent<TextMeshProUGUI>(); 
        if (objectiveText == null)
        {
            Debug.LogError("ObjectiveText script requires a TextMeshProUGUI component attached to the same GameObject.");
            return;
        }

        objective = FindObjectOfType<Objective>();
    }

    void Update()
    {

        for (int i = 0; i < objective.items.Length; i++)
        {
            if (objective.items[i]>0)
            {
                
            }
        }

        objectiveText.text = noOfItemCollected.ToString()+"/"+ "5";
    }
}
