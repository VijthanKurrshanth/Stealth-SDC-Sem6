using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStarter : MonoBehaviour
{
    public GameObject attackAlgorithm;
    public GameObject predatorSpawn;
    // Start is called before the first frame update
    void Start()
    {
        float interval = PlayerPrefs.GetFloat("attackInterval");
        //interval = 0.2f;

        StartCoroutine(ApiController.GetJwtKey((JWTKey) => StartCoroutine(ApiController.GetCurrentConsumption(JWTKey, (consumptionString) =>
        {
            PlayerPrefs.SetString("currentConsumption", consumptionString);
            InvokeRepeating(nameof(Attack), interval * 60, interval * 60);
        }))));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Attack()
    {
        Debug.Log("Attack method called");
        StartCoroutine(SendPredatorAttack());
    }

    // Send predator attack
    IEnumerator SendPredatorAttack()
    {

        yield return StartCoroutine(attackAlgorithm.GetComponent<AttackAlgorithm>().GetConsumptionRate((consumptionRate) =>
        {
            List<int> predatorArray = attackAlgorithm.GetComponent<AttackAlgorithm>().GetPredatorArray(consumptionRate);
            if (predatorArray == null)
            {
                Debug.Log("Predator array is null");
            }

            Debug.Log("Predator array: ");
            foreach (int num in predatorArray)
            {
                Debug.Log(num);
                predatorSpawn.GetComponent<PredatorSpawn>().SpawnObject(num);
            }
        }));
    }
}
