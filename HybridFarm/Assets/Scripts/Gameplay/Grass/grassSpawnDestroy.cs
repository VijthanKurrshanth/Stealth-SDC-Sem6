using UnityEngine;

public class grassSpawnDestroy : MonoBehaviour
{
    public GameObject grass; // Reference to the grass prefab
    public bool flagRunEnabled = false; // Flag to enable/disable running

    private int numberOfGrassplant=0;

    void Update()
    {
        // Check if there are any grass objects present in the scene
        GameObject[] grassObjects = GameObject.FindGameObjectsWithTag("grass");
        if (grassObjects.Length > 0)
        {
            // Grass exists, set flagRunEnabled to false
            flagRunEnabled = false;
        }
        else
        {
            // No grass, set flagRunEnabled to true
            flagRunEnabled = true;
        }

        // Check if the mouse button is clicked (left mouse button)
        if (Input.GetMouseButtonDown(0))
        {   
            
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero);

            if (hit.collider != null)
            {
                // Check if the collider hit has the tag "background"
                if (hit.collider.CompareTag("background"))
                {
                    // Collision occurred with object tagged as "background"
                    Debug.Log("Clicked on background!");
                }

                if (hit.collider.CompareTag("Farm Evening")) 
                {
                    if (numberOfGrassplant<5) 
                        {// Convert mouse position to world position
                            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            mousePosition.z = 0; // Ensure the grass spawns at z = 0 (assuming 2D)

                            // Spawn grass at mouse position
                            Instantiate(grass, mousePosition, Quaternion.identity);
                            numberOfGrassplant+=1;
                        }
                }

            }

            

        }
    }

    // Method to check for grass presence
    public bool checkForGrassPresence()
    {
        return flagRunEnabled;
    }
}