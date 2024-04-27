using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAlgorithm : MonoBehaviour
{
    private int maxTime = 5;

    // Determine the attack interval in mins
    private float DetermineAttackInterval(float yesterdayConsumption)
    {
        float attackInterval = Mathf.Lerp(maxTime, 0, yesterdayConsumption / 10);
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
}
