using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class grassSpawnDestroy : MonoBehaviour
{
    public GameObject[] grassPrefabs; // Reference to the grass prefab
    public bool flagRunEnabled = false; // Flag to enable/disable running
    public int numberOfGrassplant=0;

    public int stockcount = 5;
    private float minY = -2.9f;
    private float maxY = 2.83f;
    private float minZ = 6.7f;
    private float maxZ = 7.2f;
    private float mappedZ;



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
                    //Debug.Log("Clicked on background!");
                }

                if (hit.collider.CompareTag("Farm Evening")) 
                {
                    if (numberOfGrassplant<stockcount) 
                        {// Convert mouse position to world position
                            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            float normalizedY = Mathf.InverseLerp(minY, maxY, mousePosition.y);
                            float mappedZ = Mathf.Lerp(minZ, maxZ, normalizedY);
                            
                            mappedZ = Mathf.Clamp(mappedZ, minZ, maxZ); // Clamp mappedZ to ensure it stays within the range of minZ and maxZ
                            mousePosition.z = mappedZ; // mouse pint Y mapped to Z

                            // Spawn grass at mouse position
                            for (int i = 0; i < Random.Range(10, 12); i++) {
                                // Instantiate your game object at the desired position with Quaternion.identity rotation.
                                if (hit.collider.CompareTag("Farm Evening")){
                                    float offsetX = Random.Range(-0.6f, 0.6f); // Adjust as needed
                                    float offsetY = Random.Range(-0.3f, 0.3f); // Adjust as needed                           
                                    Vector3 randomOffset = new Vector3(offsetX, offsetY,0);
                                    int randomIndex = Random.Range(0, grassPrefabs.Length);
                                    Instantiate(grassPrefabs[randomIndex], mousePosition + randomOffset, Quaternion.identity);
                                }
                            }
                            numberOfGrassplant+=1;  // grass group bundle   
                        }
                }
            }
        }
    }

    // Method to check for grass presence
    public bool checkForGrassNotPresence()
    {
        return flagRunEnabled;
        
    }
}