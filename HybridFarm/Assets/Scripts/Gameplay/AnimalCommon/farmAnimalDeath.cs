using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class farmAnimalDeath : MonoBehaviour
{
    // Start is called before the first frame update
    grassSpawnDestroy grassSpawner;

    [SerializeField] float timer = 3.0f;

    [SerializeField] float spawnInterval = 2f;
    public float fadeDuration = 1.0f; // Duration of the fade
    private float fadeTimer = 0.0f; // Timer for tracking the fade progress
    private Renderer objectRenderer; // Reference to the object's renderer


    void Start()
    {
        grassSpawner =FindObjectOfType<grassSpawnDestroy>();
        objectRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if ( grassSpawner.checkForGrassPresence())  // if no grass this will be true
        {   
                timer -= Time.deltaTime;
                // If the timer reaches zero or less, spawn the prefab and reset the timer
                if (timer <= 0) 
                {
                    
                    fadeTimer += Time.deltaTime;
                    // Calculate the current alpha value based on the fade progress
                    float alpha = Mathf.Lerp(1f, 0f, fadeTimer / fadeDuration);
                    // Set the object's material color with updated alpha
                    Color currentColor = objectRenderer.material.color;
                    currentColor.a = alpha;
                    objectRenderer.material.color = currentColor;
                    // If the fade is complete, destroy the object
                    if (fadeTimer >= fadeDuration)
                    {
                        Destroy(gameObject);
                    }
                    timer = Random.Range(spawnInterval-1,spawnInterval+1);
                }
        }
    }




}
