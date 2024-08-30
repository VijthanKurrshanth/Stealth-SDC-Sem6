using UnityEngine;
using TMPro;
public class hideObjectBasedOnMoney : MonoBehaviour
{
    
    
    //MoneyScript moneyScript;

    Objective objective;

    public GameObject ToHide;

    [SerializeField] int cost = 100;


    void Start()
    {
        objective =FindObjectOfType<Objective>();
        

    }
    void Update()
    {

        if (objective.collected_items[0] < cost)
        {
            ToHide.SetActive(false); // Hide the GameObject
        }
        else
        {
            ToHide.SetActive(true); // Show the GameObject
        }
    }
}
