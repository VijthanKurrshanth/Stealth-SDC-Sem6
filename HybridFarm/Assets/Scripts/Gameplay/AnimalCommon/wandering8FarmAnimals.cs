using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
public class wandering8FarmAnimals : MonoBehaviour
{
    [SerializeField] float speed= 1.0f;
    [SerializeField] float range= 2.14f;
    [SerializeField] float maxDistance= 5f;
    private Vector2 wayPoint;
    private Vector2 direction;
    private Animator anim;
    private SpriteRenderer sprite_render;
    private float angle=0f;
    private Transform Transform;
    private Rigidbody2D rb;
    private string directionOfMovement;
    private Vector2 directionAngle;
    private Vector2 newPoint;
    // Define the y-axis range
    private float minY = -2.9f;
    private float maxY = 2.83f;
    private float minZ = -0.5f;
    private float maxZ = 0f;
    private float mappedZ;

    private float timer = 0f;
    private float timervalueForHungryTrigger = 10.0f;
    public bool noGrassatAll = false;
    private bool isHungry =false;
    private bool startedEating = false;
    private int destroyedNoOfGrassobject=0;
    bool approachingGrass= false;
    bool movingTowardsGrassAndEat = false;

    grassSpawnDestroy grassSpawner;
    farmAnimalDeath farmAnimalDeath;
    

    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite_render = GetComponent<SpriteRenderer>();
        Transform= GetComponent<Transform>();
        
        grassSpawner = FindObjectOfType<grassSpawnDestroy>();
        farmAnimalDeath = FindObjectOfType<farmAnimalDeath>();

        wayPoint = new Vector2(Transform.position.x -Random.Range(-maxDistance, maxDistance), Transform.position.y); //Random.Range(-maxDistance, maxDistance));
        //Debug.Log("waypoint "+ wayPoint);
        
        timer = timervalueForHungryTrigger;
        
    }

    void Update()
    {
        speed= 1f;
        StartCoroutine(FindMovingAngleAndDirectionAndAnimate());

        if (destroyedNoOfGrassobject >=3) 
        {
            isHungry=false;
            noGrassatAll = false;
            movingTowardsGrassAndEat=false;
            StopCoroutine(MoveAndEat());       

        }

        if ( grassSpawner.checkForGrassPresence() & isHungry )  // true if no grass found
        {
                    speed= 2.5f;
                    noGrassatAll = true;
                    //StopCoroutine(MoveAndEat());
                    
        }

        else if ( isHungry )
        {
            noGrassatAll = false;
            //StartCoroutine(returnWaypointForApproachAGrass());
            speed = 2f;
            StartCoroutine (MoveAndEat());
            //wayPoint = FindAndMoveTowardsGrass();   // remove comment for move toward grass and eat.
            speed = 2f; // remove comment for move toward grass and eat.
            
        }

        else 
        {
            timer=timervalueForHungryTrigger; 
            noGrassatAll = false;
            //StopCoroutine(MoveAndEat());
            StartCoroutine(animalisHungryTrigger());
        }
        
        if (!movingTowardsGrassAndEat)
        {
        direction = (wayPoint - (Vector2)transform.position).normalized;
        //Debug.Log("direction "+direction);
        mappedZ = Mathf.Lerp(minZ, maxZ, Mathf.InverseLerp(minY, maxY, wayPoint.y));
        Vector3 targetPosition = new Vector3(wayPoint.x, wayPoint.y, mappedZ);
        //Debug.Log(mappedZ);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, wayPoint) < range)
            {
                wayPoint=RandomDirectionWaypoint();
            }
          //Debug.Log(wayPoint);
        
    }


    private Vector2 RandomDirectionWaypoint()
        {
            float[] possibleAngles = { 0f,15f, 30f ,45f,60f,75f, 90f,105f, 120f ,135f,150f, 165f, 180f, 195f,210f , 225f, 240f, 255f , 270f,285f, 300f, 315f };
            float selectedAngle = possibleAngles[Random.Range(0, possibleAngles.Length)];
            angle= selectedAngle;
            // Convert angle to radians
            float angleInRadians = selectedAngle * Mathf.Deg2Rad;
            // Calculate new position based on the selected angle and maxDistance
            float newX = Transform.position.x + maxDistance * Mathf.Cos(angleInRadians);
            float newY = Transform.position.y + maxDistance * Mathf.Sin(angleInRadians);
            // Create a new Vector2 with the calculated position
            newPoint = new Vector2(newX, newY);
            return newPoint;    
        }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("background"))
        {
            wayPoint=RandomDirectionWaypointonCollision();
        }

        else if (collision.gameObject.CompareTag("grass"))
        {
            if (isHungry) 
            {
            SetAnimeFalse();
            anim.SetBool("eat_anim",true);
            startedEating = true;
            //Debug.Log("Eating");
            approachingGrass=false;
            StartCoroutine(DestroyGrass(collision.gameObject)); // Pass the grass object to destroy
            }
        }
    }

    private void OnTriggerStay2D (Collider2D collision)
    {

    }

    private Vector2 RandomDirectionWaypointonCollision()
    {
            //float[] possibleAngles = { 0f, 45f, 90f, 135f, 180f, 225f, 270f, 315f }; // Corrected the angles
            float[] possibleAngles = { 0f,15f, 30f ,45f,60f,75f, 90f,105f, 120f ,135f,150f, 165f, 180f, 195f,210f , 225f, 240f, 255f , 270f,285f, 300f, 315f };
            directionAngle = new Vector2(0, 0) - (Vector2)transform.position;
            float angledir = Mathf.Atan2(directionAngle.y, directionAngle.x) * Mathf.Rad2Deg;
            float targetAngle = (angledir + 360) % 360;
            float minDifference = float.MaxValue;
            float closestAngle = 0f;

            foreach (float possibleAngle in possibleAngles)
            {
                float difference = Mathf.Abs(Mathf.DeltaAngle(possibleAngle, targetAngle));
                if (difference < minDifference)
                {
                    minDifference = difference;
                    closestAngle = possibleAngle;
                }
            }  
            float selectedAngle=closestAngle;
            float angleInRadians = selectedAngle * Mathf.Deg2Rad;
            // Calculate new position based on the selected angle and maxDistance
            float newX = Transform.position.x + maxDistance * Mathf.Cos(angleInRadians);
            float newY = Transform.position.y + maxDistance * Mathf.Sin(angleInRadians);
            newPoint = new Vector2(newX, newY); // Create a new Vector2 with the calculated position
            return newPoint;
    }

    private Vector2 SearchAndFindGrass()
    {
        GameObject[] grassObjects = GameObject.FindGameObjectsWithTag("grass");
        if (grassObjects.Length > 0)
        {
                Vector3 currentPosition = transform.position; 
                GameObject nearestGrass = grassObjects[0];
                float shortestDistance = Vector3.Distance(currentPosition, nearestGrass.transform.position);

                for (int i = 1; i < grassObjects.Length; i++)
                {
                    float distanceGrasstoAnimal = Vector3.Distance(currentPosition, grassObjects[i].transform.position);
                    if (distanceGrasstoAnimal < shortestDistance)
                    {
                        shortestDistance = distanceGrasstoAnimal;
                        nearestGrass = grassObjects[i];
                    }
                }

                // Now nearestGrass will hold the closest grass object so chicken can move to nearest grass.
                approachingGrass = true;
                return nearestGrass.transform.position;       
        }
        else
        {
            Debug.LogWarning("No grass objects found!");
            // Return a default vector indicating no grass found
            //return Vector2.zero;
            return RandomDirectionWaypoint();
            
        }
    }
    
    private IEnumerator FindMovingAngleAndDirectionAndAnimate() 
    {
            directionAngle = wayPoint - (Vector2)transform.position;
            float angledir = Mathf.Atan2(directionAngle.y, directionAngle.x) * Mathf.Rad2Deg;
            //Debug.Log("Current angle is: " + angledir);
            angle = (angledir + 360) % 360;
            
            if (angle>=350 | angle<=20)
            {
                StartCoroutine(SetAnimeFalse());
                anim.SetBool("left_anim",true);
                sprite_render.flipX=true;
                directionOfMovement= "East";
            }

            else if (angle>=21 && angle<=65)
            {
                StartCoroutine(SetAnimeFalse());
                anim.SetBool("leftup_anim",true);
                sprite_render.flipX=true;
                directionOfMovement= "Northeast";
            }

            else if (angle>=66 && angle<=115)
            {
                StartCoroutine(SetAnimeFalse());
                anim.SetBool("up_anim",true);
                sprite_render.flipX=false;
                directionOfMovement= "North";
            }

            else if (angle>=116 && angle<=159)
            {
                StartCoroutine(SetAnimeFalse());
                anim.SetBool("leftup_anim",true);
                sprite_render.flipX=false;
                directionOfMovement= "Northwest";
            }

            else if (angle>=160 && angle<=210)
            {
                StartCoroutine(SetAnimeFalse());
                anim.SetBool("left_anim",true);
                sprite_render.flipX=false;
                directionOfMovement= "West";
            }
            
            else if (angle>=211 && angle<=259)
            {
                StartCoroutine(SetAnimeFalse());
                anim.SetBool("leftdown_anim",true);
                sprite_render.flipX=false;
                directionOfMovement= "Southwest";
            }

            else if (angle>=260 && angle<=300)
            {
                StartCoroutine(SetAnimeFalse());
                anim.SetBool("down_anim",true);
                sprite_render.flipX=false;
                directionOfMovement= "South";
            }

            else if (angle>=301 && angle<=349)
            {
                StartCoroutine(SetAnimeFalse());
                anim.SetBool("leftdown_anim",true);
                sprite_render.flipX= true;
                directionOfMovement= "Southeast";
            }

            else 
            {
                directionOfMovement= " Other Dir";
            }
        //Debug.Log(directionOfMovement);
        yield return null;
    }


    private IEnumerator SetAnimeFalse()
    {   
        anim.SetBool("up_anim",false);
        anim.SetBool("leftup_anim",false);
        anim.SetBool("left_anim",false);
        anim.SetBool("leftdown_anim",false);
        anim.SetBool("down_anim",false);
        anim.SetBool("eat_anim",false);
        yield return null;

    }

    private IEnumerator animalisHungryTrigger()
    {
        //Debug.Log("Coroutine started in Update");
        // Wait for 3 seconds
        yield return new WaitForSeconds(timervalueForHungryTrigger);
        destroyedNoOfGrassobject =0;
        isHungry = true; // Reset coroutineStarted for the next iteration
    }

    private IEnumerator DestroyGrass(GameObject grassObject)
    {
        yield return new WaitForSeconds(2);
        Destroy(grassObject);
        destroyedNoOfGrassobject+=1; 
    }
    private IEnumerator MoveAndEat()
    {
        movingTowardsGrassAndEat = true;
        
        Vector2 grasslocation= SearchAndFindGrass();
        //Debug.Log("grass location: "+grasslocation);
        direction = (grasslocation - (Vector2)transform.position).normalized;
        //Debug.Log("direction "+direction);
        mappedZ = Mathf.Lerp(minZ, maxZ, Mathf.InverseLerp(minY, maxY, grasslocation.y));
        Vector3 targetPosition = new Vector3(grasslocation.x, grasslocation.y, mappedZ);
        //Debug.Log(mappedZ);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        float distanceToTarget = Vector2.Distance(transform.position, targetPosition);
        Debug.Log(distanceToTarget);
        

       if (distanceToTarget > 0.02) {

        directionAngle = grasslocation - (Vector2)transform.position;
            float angledir = Mathf.Atan2(directionAngle.y, directionAngle.x) * Mathf.Rad2Deg;
            //Debug.Log("Current angle is: " + angledir);
            angle = (angledir + 360) % 360;
            
            if (angle>=350 | angle<=20)
            {
                StartCoroutine(SetAnimeFalse());
                anim.SetBool("left_anim",true);
                sprite_render.flipX=true;
                directionOfMovement= "East";
            }

            else if (angle>=21 && angle<=65)
            {
                StartCoroutine(SetAnimeFalse());
                anim.SetBool("leftup_anim",true);
                sprite_render.flipX=true;
                directionOfMovement= "Northeast";
            }

            else if (angle>=66 && angle<=115)
            {
                StartCoroutine(SetAnimeFalse());
                anim.SetBool("up_anim",true);
                sprite_render.flipX=false;
                directionOfMovement= "North";
            }

            else if (angle>=116 && angle<=159)
            {
                StartCoroutine(SetAnimeFalse());
                anim.SetBool("leftup_anim",true);
                sprite_render.flipX=false;
                directionOfMovement= "Northwest";
            }

            else if (angle>=160 && angle<=210)
            {
                StartCoroutine(SetAnimeFalse());
                anim.SetBool("left_anim",true);
                sprite_render.flipX=false;
                directionOfMovement= "West";
            }
            
            else if (angle>=211 && angle<=259)
            {
                StartCoroutine(SetAnimeFalse());
                anim.SetBool("leftdown_anim",true);
                sprite_render.flipX=false;
                directionOfMovement= "Southwest";
            }

            else if (angle>=260 && angle<=300)
            {
                StartCoroutine(SetAnimeFalse());
                anim.SetBool("down_anim",true);
                sprite_render.flipX=false;
                directionOfMovement= "South";
            }

            else if (angle>=301 && angle<=349)
            {
                StartCoroutine(SetAnimeFalse());
                anim.SetBool("leftdown_anim",true);
                sprite_render.flipX= true;
                directionOfMovement= "Southeast";
            }

            else 
            {
                directionOfMovement= " Other Dir";
            }

       }

       else 
       {
            if (grasslocation.x >transform.position.x) {
            StartCoroutine(SetAnimeFalse());
            sprite_render.flipX= true;
            anim.SetBool("eat_anim",true);
            }

            else 
            {
                StartCoroutine(SetAnimeFalse());
                sprite_render.flipX= false;
                anim.SetBool("eat_anim",true);
  
            }
       }

        yield return new WaitForSeconds(2);
    }

}
