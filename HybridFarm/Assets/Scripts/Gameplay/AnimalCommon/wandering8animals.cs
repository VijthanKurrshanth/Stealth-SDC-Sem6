using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;


public class wandering8animals : MonoBehaviour
{
    [SerializeField] float speed= 0.5f;
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

    // Define the z-axis range
    private float minZ = -0.5f;
    private float maxZ = 0f;
    private float mappedZ;
  

    grassSpawnDestroy grassSpawner;

    

    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite_render = GetComponent<SpriteRenderer>();
        Transform= GetComponent<Transform>();
        
        grassSpawner = FindObjectOfType<grassSpawnDestroy>();

        wayPoint = new Vector2(Transform.position.x -Random.Range(-maxDistance, maxDistance), Transform.position.y); //Random.Range(-maxDistance, maxDistance));
        //Debug.Log("waypoint "+ wayPoint);
        
       


    }

    void Update()
    {
        // speed= 1f;
        // if ( grassSpawner.checkForGrassPresence())
        //     {
  
        //     speed= 2.5f;                # react to grass for farm animal only
        
        //     }

        
        direction = (wayPoint - (Vector2)transform.position).normalized;
        //Debug.Log("direction "+direction);

        mappedZ = Mathf.Lerp(minZ, maxZ, Mathf.InverseLerp(minY, maxY, wayPoint.y));
        Vector3 targetPosition = new Vector3(wayPoint.x, wayPoint.y, mappedZ);
        //Debug.Log(mappedZ);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);





        //transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, wayPoint) < range)
            {
                wayPoint=RandomDirectionWaypoint();
            }


        FindMovingAngleAndDirectionAndAnimate();
        //Debug.Log(wayPoint);
        






    }


    Vector2 RandomDirectionWaypoint()
        {
            
            float[] possibleAngles = { 0f, 45f, 90f, 135f, 180f, 225f, 270f, 315f }; // Corrected the angles
            float selectedAngle = possibleAngles[Random.Range(0, possibleAngles.Length)];
            angle= selectedAngle;
            // Convert angle to radians
            float angleInRadians = selectedAngle * Mathf.Deg2Rad;
            //Debug.Log("angle "+ selectedAngle);
            
            // Calculate new position based on the selected angle and maxDistance
            float newX = Transform.position.x + maxDistance * Mathf.Cos(angleInRadians);
            float newY = Transform.position.y + maxDistance * Mathf.Sin(angleInRadians);

            // Create a new Vector2 with the calculated position
            newPoint = new Vector2(newX, newY);
            //Debug.Log(newPoint);
            return newPoint;
            
            // Now you can use the 'newPoint' as the waypoint
        }





    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("background"))
        {

            // wayPoint = new Vector2(0, 0);
            // directionAngle = new Vector2(0, 0) - (Vector2)transform.position;
            // float angledir = Mathf.Atan2(directionAngle.y, directionAngle.x) * Mathf.Rad2Deg;
            // angle = (angledir + 360) % 360;
            // Debug.Log(angle);
            wayPoint=RandomDirectionWaypointonCollision();
            //Debug.Log("Collision lynx");
            //Debug.Log(wayPoint);

        }
    }



    Vector2 RandomDirectionWaypointonCollision()
        {
            
            // float[] possibleAngles = { 0f, 45f, 90f, 135f, 180f, 225f, 270f, 315f }; // Corrected the angles
            // //float selectedAngle = possibleAngles[Random.Range(0, possibleAngles.Length)];
            
            // directionAngle = new Vector2(0, 0) - (Vector2)transform.position;
            // float angledir = Mathf.Atan2(directionAngle.y, directionAngle.x) * Mathf.Rad2Deg;
            // angle = (angledir + 360) % 360;
            // //Debug.Log(angle);
            
            // angle= selectedAngle;
            // // Convert angle to radians
            // float angleInRadians = selectedAngle * Mathf.Deg2Rad;
            // //Debug.Log("angle "+ selectedAngle);

            float[] possibleAngles = { 0f, 45f, 90f, 135f, 180f, 225f, 270f, 315f }; // Corrected the angles

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

            // Create a new Vector2 with the calculated position
            newPoint = new Vector2(newX, newY);
            //Debug.Log(newPoint);
            return newPoint;
            
            // Now you can use the 'newPoint' as the waypoint
        }





    void FindMovingAngleAndDirectionAndAnimate() 
    {
        directionAngle = wayPoint - (Vector2)transform.position;
        float angledir = Mathf.Atan2(directionAngle.y, directionAngle.x) * Mathf.Rad2Deg;
        

        angle = (angledir + 360) % 360;
        
        

        
        if (angle>=350 | angle<=20)
        {
            SetAnimeFalse();
            anim.SetBool("left_anim",true);
            sprite_render.flipX=true;
            directionOfMovement= "East";
        }

        else if (angle>=21 && angle<=65)
        {
            SetAnimeFalse();
            anim.SetBool("leftup_anim",true);
            sprite_render.flipX=true;
            directionOfMovement= "Northeast";
        }


        else if (angle>=66 && angle<=115)
        {
            SetAnimeFalse();
            anim.SetBool("up_anim",true);
            sprite_render.flipX=false;
            directionOfMovement= "North";
        }

        else if (angle>=116 && angle<=159)
        {
            SetAnimeFalse();
            anim.SetBool("leftup_anim",true);
            sprite_render.flipX=false;
            directionOfMovement= "Northwest";
        }

        else if (angle>=160 && angle<=210)
        {
            SetAnimeFalse();
            anim.SetBool("left_anim",true);
            sprite_render.flipX=false;
            directionOfMovement= "West";
        }
        
        else if (angle>=211 && angle<=259)
        {
            SetAnimeFalse();
            anim.SetBool("leftdown_anim",true);
            sprite_render.flipX=false;
            directionOfMovement= "Southwest";
        }

        else if (angle>=260 && angle<=300)
        {
            SetAnimeFalse();
            anim.SetBool("down_anim",true);
            sprite_render.flipX=false;
            directionOfMovement= "South";
        }

        else if (angle>=301 && angle<=349)
        {
            SetAnimeFalse();
            anim.SetBool("leftdown_anim",true);
            sprite_render.flipX= true;
            directionOfMovement= "Southeast";
        }

        else 
        {
        
        directionOfMovement= " Other Dir";
        }
     //Debug.Log(directionOfMovement);
    }




    void SetAnimeFalse()
    {
        anim.SetBool("up_anim",false);
        anim.SetBool("leftup_anim",false);
        anim.SetBool("left_anim",false);
        anim.SetBool("leftdown_anim",false);
        anim.SetBool("down_anim",false);

    }



    }


