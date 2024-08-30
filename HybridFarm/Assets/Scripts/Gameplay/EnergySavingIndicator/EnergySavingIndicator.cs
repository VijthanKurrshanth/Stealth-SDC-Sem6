using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySavingIndicator : MonoBehaviour
{
    public Sprite level1IndicatorSprite;
    public Sprite level2IndicatorSprite;
    public Sprite level3IndicatorSprite;
    public Sprite level4IndicatorSprite;
    public Sprite level5IndicatorSprite;
    // Start is called before the first frame update
    void Start()
    {
         // Get the SpriteRenderer component attached to this GameObject
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        // Set the sprite of the SpriteRenderer to the assigned indicatorSprite

        int updateInterval = 3; // in seconds
        StartCoroutine(ApiController.GetJwtKey((JWTKey) => StartCoroutine(ApiController.GetCurrentConsumption(JWTKey, (consumptionString) =>
        {
            PlayerPrefs.SetString("currentConsumptionForIndicator", consumptionString);
            InvokeRepeating(nameof(setIndicatorSprite), updateInterval, updateInterval);
        }))));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator GetConsumptionRate(Action<double> callback)
    {
        double consumptionRate = 0;
        int updateInterval = 3; // in seconds

        yield return StartCoroutine(ApiController.GetJwtKey((JWTKey) => StartCoroutine(ApiController.GetCurrentConsumption(JWTKey, (consumptionString) =>
        {
            double currentConsumption = double.Parse(PlayerPrefs.GetString("currentConsumptionForIndicator"));
            //Debug.Log("Current consumption for indicator: " + currentConsumption);

            PlayerPrefs.SetString("currentConsumptionForIndicator", consumptionString);

            double consumption = double.Parse(consumptionString);
            //Debug.Log("Consumption: " + consumption);

            double difference = consumption - currentConsumption;
            if (difference <= 0)
            {
                consumptionRate = 0;
            }
            else
            {
                consumptionRate = difference / updateInterval;
            }
            //Debug.Log("Consumption rate for indicator: " + consumptionRate);

            callback(consumptionRate);
        }))));
    }

    void setIndicatorSprite()
    {
        StartCoroutine(GetConsumptionRate((consumptionRate) =>
        {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            if (consumptionRate >= 0.08)
            {
                renderer.sprite = level1IndicatorSprite;
            }
            else if (consumptionRate < 0.08 && consumptionRate >= 0.06)
            {
                renderer.sprite = level2IndicatorSprite;
            }
            else if (consumptionRate < 0.06 && consumptionRate >= 0.04)
            {
                renderer.sprite = level3IndicatorSprite;
            }
            else if (consumptionRate < 0.04 && consumptionRate >= 0.02)
            {
                renderer.sprite = level4IndicatorSprite;
            }
            else
            {
                renderer.sprite = level5IndicatorSprite;
            }
        }));
    }
}
