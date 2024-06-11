using UnityEngine;
using TMPro;

public class MoneyScript : MonoBehaviour
{
    public int moneyValue; // Variable to hold the money value

    Objective objective;
    private TextMeshProUGUI moneyText; // Reference to the UI text element to display the money value

    // Start is called before the first frame update
    void Start()
    {
        objective = FindObjectOfType<Objective>();
        moneyText = GetComponent<TextMeshProUGUI>(); // Get the TextMeshProUGUI component attached to the same GameObject
        if (moneyText == null)
        {
            Debug.LogError("MoneyScript requires a TextMeshProUGUI component attached to the same GameObject.");
            return;
        }
        //moneyValue = 100;   //initial Money
        UpdateMoneyText(); // Call the function to update the money text when the game starts
        moneyValue=objective.collected_items[0];
        
        
    }


    void Update()
    {
        // Example: Increase money value by 1 every frame 
        moneyValue=objective.collected_items[0];
        if (moneyValue < 0)
        {
            moneyValue = 0;
        }
        
        UpdateMoneyText(); // Call the function to update the money text when money value changes
    }

    void UpdateMoneyText()
    {
        moneyText.fontStyle = FontStyles.Bold;
        moneyText.fontSize = 40;
        moneyText.text = moneyValue.ToString();

    
    }


    int getMoneyValue()
    {
        return moneyValue;
    }
}
