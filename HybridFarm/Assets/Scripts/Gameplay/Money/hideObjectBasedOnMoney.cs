using UnityEngine;
using TMPro;
public class hideObjectBasedOnMoney : MonoBehaviour
{
    
    
    MoneyScript moneyScript;
    [SerializeField] int cost = 100;


    void Start()
    {
        moneyScript =FindObjectOfType<MoneyScript>();
        

    }
    void Update()
    {

        if (moneyScript.moneyValue < cost)
        {
            gameObject.SetActive(false); // Hide the GameObject
        }
        else
        {
            gameObject.SetActive(true); // Show the GameObject
        }
    }
}
