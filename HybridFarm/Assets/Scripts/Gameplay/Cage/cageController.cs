using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cageController : MonoBehaviour
{
    public GameObject[] cagePrefabs; // Array to hold your 9 cage prefabs
    public GameObject cagedAnimalPrefab; // Prefab for the caged animal
    public float timeToReverse = 5.0f; // Time to start reversing the cage building process
    private int cageStep = 0; // Current cage step
    private GameObject currentCage; // Current displayed cage prefab
    private float lastClickTime; // Time of the last click

    void Start()
    {
        lastClickTime = Time.time;
    }

    void Update()
    {
        // Check if enough time has passed to reverse the cage build
        if (Time.time - lastClickTime > timeToReverse && cageStep > 0)
        {
            cageStep--;
            UpdateCage();
        }
    }

    void OnMouseDown()
    {
        if (cageStep < cagePrefabs.Length)
        {
            cageStep++;
            lastClickTime = Time.time; // Reset the timer
            UpdateCage();
        }
    }

    void UpdateCage()
    {
        if (currentCage != null)
        {
            Destroy(currentCage);
        }

        if (cageStep > 0 && cageStep < cagePrefabs.Length)
        {
            currentCage = Instantiate(cagePrefabs[cageStep - 1], transform.position, Quaternion.identity);
            currentCage.transform.SetParent(this.transform);
        }
        else if (cageStep >= cagePrefabs.Length)
        {
            // Destroy the predator and spawn the caged animal
            Destroy(gameObject); // Destroy the predator
            Instantiate(cagedAnimalPrefab, transform.position, Quaternion.identity);
        }
    }
}
