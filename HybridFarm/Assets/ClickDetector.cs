using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    void Update()
    {
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
            }
        }
    }
}
