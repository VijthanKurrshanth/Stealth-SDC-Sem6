using UnityEngine;
using UnityEngine.UI;

public class AllButtonDisableEnabler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void DisableAllButtons()
    {
        // Find all button components in the scene and disable them
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            button.interactable = false;
        }
    }

    public void EnableAllButtons()
    {
        // Find all button components in the scene and enable them
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
    }
}
