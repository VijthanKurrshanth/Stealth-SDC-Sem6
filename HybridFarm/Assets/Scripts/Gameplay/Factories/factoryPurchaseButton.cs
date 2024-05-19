using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class factoryPurchaseButton : MonoBehaviour


{
    // Start is called before the first frame update
    MoneyScript moneyScript;
    private Renderer buttonRenderer;
    public int CostOfFactory = 100;

    void Start()
    {
        moneyScript = FindObjectOfType<MoneyScript>();
        buttonRenderer = GetComponent<Renderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moneyScript.moneyValue >= CostOfFactory)
        {
            buttonRenderer.enabled = true; //false initially
        }

        else
        {
            buttonRenderer.enabled = false;
        }
        
    }
}
