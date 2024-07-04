using UnityEngine;
using UnityEngine.UI;

public class TruckController2D : MonoBehaviour
{
    public GameObject prefabToSpawn; 
    public Vector3 spawnPosition; // Public variable to set the spawn position in the Inspector
    private SpriteRenderer currentRenderer;
    private Color originalColor;
    private Color hoverColor = Color.white;
    private Color clickColor = Color.red;

    public Transform parentPrefab; // Canva ShipmentUI

    AllButtonDisableEnabler allButtonDisableEnabler;

    public bool vehicleisPressed = false;

    ShipmentBar shipmentBar;

    void Start()
    {
        allButtonDisableEnabler = FindObjectOfType<AllButtonDisableEnabler>();
        //shipmentBar = FindObjectOfType<ShipmentBar>();
    }

    void Update()
    {
        
        //gameObject.SetActive(shipmentBar.canTravelagain);

        //Debug.Log(shipmentBar.canTravelagain);

        // Get the mouse position in world coordinates
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        
        if (hit.collider != null)
        {
            // Check if the object has the tag "Truck"
            if (hit.collider.CompareTag("Truck"))
            {
                SpriteRenderer renderer = hit.collider.GetComponent<SpriteRenderer>();

                
                if (renderer != currentRenderer)
                {
                    ResetColor();
                    currentRenderer = renderer;
                    originalColor = currentRenderer.color;
                    currentRenderer.color = hoverColor;
                }

                
                if (Input.GetMouseButtonDown(0))
                {
                    
                    currentRenderer.color = clickColor;

                    // Spawn the prefab at the specified spawn position
                    GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
                    spawnedObject.transform.SetParent(parentPrefab);

                    vehicleisPressed = true;

                    // Pause the game
                    Time.timeScale = 0;

                    // Disable all buttons
                    allButtonDisableEnabler.DisableAllButtons();

                    // Enable specific buttons (children of the spawned prefab)
                    allButtonDisableEnabler.EnableChildButtons(spawnedObject);
                }
            }
            else
            {
                ResetColor();
            }
        }
        else
        {
            ResetColor();
        }
    }

    void ResetColor()
    {
        // Reset the color of the previously hovered object
        if (currentRenderer != null)
        {
            currentRenderer.color = originalColor;
            currentRenderer = null;
        }
    }
}
