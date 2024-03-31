using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class farmAnimalDeath : MonoBehaviour
{
    // Start is called before the first frame update
    grassSpawnDestroy grassSpawner;

    wandering8FarmAnimals wandering8FarmAnimals;

    [SerializeField] float timer = 10.0f;



    void Start()
    {
        grassSpawner =FindObjectOfType<grassSpawnDestroy>();
        wandering8FarmAnimals = FindObjectOfType <wandering8FarmAnimals>();
        timer = Random.Range(timer-1,timer+2);
    }

    // Update is called once per frame
    void Update()
    {

        if ( wandering8FarmAnimals.noGrassatAll)  // if no grass this will be true
        {   
                timer -= Time.deltaTime;
                // If the timer reaches zero or less, spawn the prefab and reset the timer
                if (timer <= 0) 
                {

                    {
                        Destroy(gameObject);
                        Debug.Log("destroy");
                    }
                    Destroy(gameObject);
                    
                }
        }
    }




}
