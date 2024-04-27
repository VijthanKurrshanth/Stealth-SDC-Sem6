using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAlgorithm : MonoBehaviour
{
    private readonly int maxLevelTime = 5;
    private readonly int maxDailyUnits = 10;
    private readonly float maxConsumptionRate = 0.08f;
    private double currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = (System.DateTime.Now - new System.DateTime(1970, 1, 1)).TotalMilliseconds;
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

        PlayerPrefs.SetFloat("attackInterval", attackInterval);
        Debug.Log("Attack interval: " + attackInterval);
        return attackInterval;
    }

    // Get predator array
    public List<int> GetPredatorArray(float consumptionRate)
    {
        int consumptionScore = Mathf.RoundToInt(Mathf.Lerp(0, 15, consumptionRate / maxConsumptionRate));
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

        return combinations.Count > 0 ? combinations[Random.Range(0, combinations.Count)] : null;
    }
}
