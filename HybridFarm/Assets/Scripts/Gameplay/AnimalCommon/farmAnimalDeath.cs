using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class farmAnimalDeath : MonoBehaviour
{
    // Start is called before the first frame update
    grassSpawnDestroy grassSpawner;

    private wandering8FarmAnimals wandering8FarmAnimals;
    private wandering8FarmAnimals wandering8animalsIENumrator;
    private Animator anim;
    public float timerforDeath = 10.0f;
    public float timerofDeathConstant= 10.0f ;



    void Start()
    {
        anim = GetComponent<Animator>();
        grassSpawner =FindObjectOfType<grassSpawnDestroy>();
        wandering8FarmAnimals = FindObjectOfType <wandering8FarmAnimals>();
        wandering8animalsIENumrator = GetComponent<wandering8FarmAnimals>();
        timerforDeath = Random.Range(timerforDeath-1,timerforDeath+2);
    }

    // Update is called once per frame
    void Update()
    {

        if ( wandering8FarmAnimals.noGrassatAll)  // if no grass this will be true
        {   
                timerforDeath -= Time.deltaTime;
                // If the timer reaches zero or less, spawn the prefab and reset the timer
                if (timerforDeath <= 0) 
                {


                    // {
                    //     Destroy(gameObject);
                    //     Debug.Log("destroy");
                    // }
                    //Destroy(gameObject);
                    StartCoroutine(DeathAnimate());
                    
                }
        }
    }


private IEnumerator DeathAnimate()
{
    
    yield return new WaitForSeconds(0.01f);
    Destroy(gameObject);

}




}
