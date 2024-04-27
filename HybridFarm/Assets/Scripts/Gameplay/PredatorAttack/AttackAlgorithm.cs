using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackAlgorithm : MonoBehaviour
{
    private readonly int maxLevelTime = 5;
    private readonly int maxDailyUnits = 10;
    private readonly float maxConsumptionRate = 0.1f;
    private double currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Determine the attack interval in mins
    private float DetermineAttackInterval(float yesterdayConsumption)
    {
        float attackInterval = Mathf.Lerp(maxLevelTime, 0, yesterdayConsumption / maxDailyUnits);
        return attackInterval;
    }

    // Get the attack interval
    public float GetAttackInterval()
    {
        float attackInterval = 0;
        if (PlayerPrefs.GetFloat("yesterdayConsumption") == 0)
        {
            StartCoroutine(ApiController.GetJwtKey((JWTKey) => StartCoroutine(ApiController.GetYesterdayConsumption(JWTKey, (consumption) =>
            {
                PlayerPrefs.SetFloat("yesterdayConsumption", consumption);
                attackInterval = DetermineAttackInterval(consumption);
            }))));
        }
        else
        {
            attackInterval = DetermineAttackInterval(PlayerPrefs.GetFloat("yesterdayConsumption"));
        }

        StartCoroutine(ApiController.GetJwtKey((JWTKey) => StartCoroutine(ApiController.GetCurrentConsumption(JWTKey, (consumption) =>
        {
            PlayerPrefs.SetString("currentConsumption", consumption.ToString());
        }))));

        PlayerPrefs.SetFloat("attackInterval", attackInterval);
        Debug.Log("Attack interval: " + attackInterval);
        return attackInterval;
    }

    // Get predator array based on consumption rate
    public List<int> GetPredatorArray(double consumptionRate)
    {
        int consumptionScore = Mathf.RoundToInt(Mathf.Lerp(1, 12, (float)(consumptionRate / maxConsumptionRate)));
        Debug.Log("Consumption score: " + consumptionScore);

        // Helper method to find combinations recursively
        List<List<int>> combinations = new();
        void Backtrack(int currentSum, int remainingElements, List<int> currentList, int startNum = 1)
        {
            if (currentSum == consumptionScore && remainingElements == 0)
            {
                combinations.Add(new List<int>(currentList));
                return;
            }

            if (currentSum > consumptionScore || remainingElements < 0)
            {
                return;
            }

            for (int num = startNum; num <= 5; num++)
            {
                currentList.Add(num);
                Backtrack(currentSum + num, remainingElements - 1, currentList, num + 1);
                currentList.RemoveAt(currentList.Count - 1);
            }
        }

        List<int> currentList = new(); // Declare outside Backtrack
        for (int numElements = 1; numElements <= 3; numElements++)
        {
            Backtrack(0, numElements, currentList);
        }

        return combinations.Count > 0 ? combinations[UnityEngine.Random.Range(0, combinations.Count)] : null;
    }

    // Get consumption rate based on power consumption
    public IEnumerator GetConsumptionRate(Action<double> callback)
    {
        double consumptionRate = 0;
        float attackInterval = PlayerPrefs.GetFloat("attackInterval");

        yield return StartCoroutine(ApiController.GetJwtKey((JWTKey) => StartCoroutine(ApiController.GetCurrentConsumption(JWTKey, (consumptionString) =>
        {
            double currentConsumption = double.Parse(PlayerPrefs.GetString("currentConsumption"));
            Debug.Log("Current consumption: " + currentConsumption);

            PlayerPrefs.SetString("currentConsumption", consumptionString);

            double consumption = double.Parse(consumptionString);
            Debug.Log("Consumption: " + consumption);

            consumptionRate = (consumption - currentConsumption) / (attackInterval * 60);
            Debug.Log("Consumption rate: " + consumptionRate);

            callback(consumptionRate);
        }))));
    }
}
