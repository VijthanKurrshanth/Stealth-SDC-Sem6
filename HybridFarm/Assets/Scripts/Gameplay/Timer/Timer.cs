using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 0; // Initial time to start from 00:00
    public TextMeshProUGUI timerText; // Reference to the TextMeshProUGUI component to display the timer

    public String TimeinFormat;
    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>(); // Get the TextMeshProUGUI component attached to the same GameObject
        if (timerText == null)
        {
            Debug.LogError("Timer Sript requires a TextMeshProUGUI component attached to the same GameObject.");
            return;
        }
        timeRemaining = 0; // Start from 00:00
        UpdateTimerDisplay(); // Update the timer display
    }

    void Update()
    {
        // Increase the time remaining
        timeRemaining += Time.deltaTime;

        // Update the timer display
        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        // Convert the time remaining to minutes and seconds
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        // Update the timer text
         
        TimeinFormat= string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = TimeinFormat;
    }
}
