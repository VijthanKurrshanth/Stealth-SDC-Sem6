using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;


public class wandering8direction : MonoBehaviour
{
    [SerializeField] float speed= 0.3f;
    [SerializeField] float range= 4f;
    [SerializeField] float maxDistance= 5f;

    Vector2 wayPoint;
    Vector2 currentDirection;

    private Animator anim;
    private SpriteRenderer sprite_render;
    private float angle=0f;
    private Transform Transform;
    private Rigidbody2D rb;

  
    

    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite_render = GetComponent<SpriteRenderer>();
        Transform= GetComponent<Transform>();

        wayPoint = new Vector2(Transform.position.x -Random.Range(-maxDistance, maxDistance), Transform.position.y); //Random.Range(-maxDistance, maxDistance));
        //Debug.Log("waypoint "+ wayPoint);


    }

    void Update()
    {
        
        Vector2 direction = (wayPoint - (Vector2)transform.position).normalized;
        //Debug.Log("direction "+direction);

        transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, wayPoint) < range)
                    {
                        wayPoint=RandomDirectionWaypoint();
                    }


        FindMovingAngleAndDirectionAndAnimate();
        
        






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
            Vector2 newPoint = new Vector2(newX, newY);
            //Debug.Log(newPoint);
            return newPoint;
            
            // Now you can use the 'newPoint' as the waypoint
        }



    private void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("background"))
        {

            wayPoint = new Vector2(0, 0);
            Debug.Log("Collision");

        }
    }

    void FindMovingAngleAndDirectionAndAnimate() 
    {
        Vector2 directionAngle = wayPoint - (Vector2)transform.position;
        float angledir = Mathf.Atan2(directionAngle.y, directionAngle.x) * Mathf.Rad2Deg;
        

        angle = (angledir + 360) % 360;
        
        string directionOfMovement=" ";

        
        if (angle>=350 | angle<=20)
        {
            SetAnimeFalse();
            anim.SetBool("kitten_left_anim",true);
            sprite_render.flipX=true;
            directionOfMovement= "East";
        }

        else if (angle>=21 && angle<=65)
        {
            SetAnimeFalse();
            anim.SetBool("kitten_leftup_anim",true);
            sprite_render.flipX=true;
            directionOfMovement= "Northeast";
        }


        else if (angle>=66 && angle<=115)
        {
            SetAnimeFalse();
            anim.SetBool("kitten_up_anim",true);
            sprite_render.flipX=false;
            directionOfMovement= "North";
        }

        else if (angle>=116 && angle<=159)
        {
            SetAnimeFalse();
            anim.SetBool("kitten_leftup_anim",true);
            sprite_render.flipX=false;
            directionOfMovement= "Northwest";
        }

        else if (angle>=160 && angle<=210)
        {
            SetAnimeFalse();
            anim.SetBool("kitten_left_anim",true);
            sprite_render.flipX=false;
            directionOfMovement= "West";
        }
        
        else if (angle>=211 && angle<=259)
        {
            SetAnimeFalse();
            anim.SetBool("kitten_leftdown_anim",true);
            sprite_render.flipX=false;
            directionOfMovement= "Southwest";
        }

        else if (angle>=260 && angle<=300)
        {
            SetAnimeFalse();
            anim.SetBool("kitten_down_anim",true);
            sprite_render.flipX=false;
            directionOfMovement= "South";
        }

        else if (angle>=301 && angle<=349)
        {
            SetAnimeFalse();
            anim.SetBool("kitten_leftdown_anim",true);
            sprite_render.flipX= true;
            directionOfMovement= "Southeast";
        }

        else 
        {
        
        directionOfMovement= " Other Dir";
        }
     Debug.Log(directionOfMovement);
    }

















    // void MoveTowardsWaypoint()
    //     {
    //         Vector2 direction = (wayPoint - (Vector2)transform.position).normalized;
            
    //         currentDirection = SnapToRandomDirections(direction);
    //         transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);
    //     }

    // Vector2 SnapToRandomDirections(Vector2 input)
    //     {
    //         float[] possibleAngles = { 180f, 225f, 270f, 315f, 0f, 45f, 90f, 135f }; // 0 is left (west)
    //         float angle = possibleAngles[Random.Range(0, possibleAngles.Length)];

    //         //Debug.Log(angle);

    //         float snappedAngle = Mathf.Round(angle / 45.0f) * 45.0f;
    //         return new Vector2(Mathf.Cos(snappedAngle * Mathf.Deg2Rad), Mathf.Sin(snappedAngle * Mathf.Deg2Rad));
    //     }

    // void SetNewDestination()
    //     {
    //         wayPoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));
    //         Debug.Log(wayPoint);

    //     }


    // void OnTriggerExit2D(Collider2D collision)
    //     {
    //         if (collision.gameObject.CompareTag("background"))
    //         {
    //             SetNewObtuseAngularDirection();
    //         }
    //     }







    // Method to get the direction based on the wayPoint vector
    // void GetDirection()
    // {


    //     if (angle ==0f)
    //     {   
    //         SetAnimeFalse();
    //         anim.SetBool("kitten_left_anim",true);
    //         sprite_render.flipX=true;
    //         Debug.Log("East "+angle);
            
    //     }
    //     else if (angle ==45f)
    //     {
    //         SetAnimeFalse();
            
    //         anim.SetBool("kitten_leftup_anim",true);
    //         sprite_render.flipX=true;
    //         Debug.Log("Northeast "+angle);
    //     }
    //     else if (angle ==90f)
    //     {
    //         SetAnimeFalse();
            
    //         anim.SetBool("kitten_up_anim",true);
    //         sprite_render.flipX=false;
    //         Debug.Log("North "+angle);
    //     }
    //     else if (angle ==135f)
    //     {
    //         SetAnimeFalse();
            
    //         anim.SetBool("kitten_leftup_anim",true);
    //         sprite_render.flipX=false;
    //         Debug.Log("Northwest "+angle);
    //     }
    //     else if (angle ==180f)
    //     {
    //         SetAnimeFalse();
            
    //         anim.SetBool("kitten_left_anim",true);
    //         sprite_render.flipX=false;
    //         Debug.Log("West "+angle);
    //     }
    //     else if (angle ==235f)
    //     {
    //         SetAnimeFalse();
            
    //         anim.SetBool("kitten_leftdown_anim",true);
    //         sprite_render.flipX=false;
    //         Debug.Log("Southwest "+angle);
    //     }
    //     else if (angle ==270f)
    //     {
    //         SetAnimeFalse();
            
    //         anim.SetBool("kitten_down_anim",true);
    //         sprite_render.flipX=false;
    //         Debug.Log("South "+angle);
    //     }


    //     else if (angle ==270f)
    //     {
    //           SetAnimeFalse();
    //         anim.SetBool("kitten_leftdown_anim",true);
    //         sprite_render.flipX= true;
    //         Debug.Log("Southeast "+angle);
    //     }

    //     else // angle >= 292.5 && angle < 337.5
    //     {

    //     }

    // }


    void SetAnimeFalse()
    {
        anim.SetBool("kitten_up_anim",false);
        anim.SetBool("kitten_leftup_anim",false);
        anim.SetBool("kitten_left_anim",false);
        anim.SetBool("kitten_leftdown_anim",false);
        anim.SetBool("kitten_down_anim",false);

    }



    }


