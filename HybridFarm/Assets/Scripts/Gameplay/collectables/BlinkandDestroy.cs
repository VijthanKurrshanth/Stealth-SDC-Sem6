using System.Collections;
using UnityEngine;

public class BlinkAndDestroy : MonoBehaviour
{
    public float blinkInterval = 0.25f; // Time between blinks
    public float destroyTime = 15f; // Time before the object is destroyed if not collected
    public float blinkStartTime = 10f; // Time before the object starts blinking
    public float brightnessReduction = 0.1f; // Amount to reduce brightness each blink

    private Renderer objectRenderer;
    private Color originalColor;
    private float currentBrightness;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        originalColor = objectRenderer.material.color;
        currentBrightness = 1f; // Initial brightness is 100%
        StartCoroutine(Blink());
        StartCoroutine(DestroyAfterTime());
    }

    IEnumerator Blink()
    {
        yield return new WaitForSeconds(blinkStartTime); // Wait before starting to blink
        while (true)
        {
            objectRenderer.enabled = !objectRenderer.enabled;
            if (objectRenderer.enabled)
            {
                // Reduce brightness
                currentBrightness -= brightnessReduction;
                currentBrightness = Mathf.Clamp(currentBrightness, 0, 1); // Ensure brightness stays within [0, 1]
                Color newColor = originalColor * currentBrightness;
                objectRenderer.material.color = newColor;
            }
            yield return new WaitForSeconds(blinkInterval);
        }
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }


    public void Collect()
    {
        // Add logic here for what happens when the object is collected (e.g., increase score)
        Destroy(gameObject); // Destroy the object after collecting
    }
}
