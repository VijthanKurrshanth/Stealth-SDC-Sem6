using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Animator))]


public class Kitten_Wander : MonoBehaviour
{
        
    public float pursuitSpeed;
    public float wanderSpeed;
    float currentSpeed;
   
    public float directionChangeInterval;

    public bool followPlayer;
   
    Coroutine moveCoroutine;
    
    Rigidbody2D rb2d;
    Animator animator;
    
    Transform targetTransform = null;
  
    Vector3 endPosition;
  
    float currentAngle = 0;

    // Start is called before the first frame update
    void Start()
        {
            animator = GetComponent<Animator>();
            currentSpeed = wanderSpeed;
    
            rb2d = GetComponent<Rigidbody2D>();
    
            StartCoroutine(WanderRoutine());
        }

        // Update is called once per frame
        void Update()
        {
            
        }






    public IEnumerator WanderRoutine()
        {

        while (true)
        {

        ChooseNewEndpoint();
    
        if (moveCoroutine != null)
        {

        StopCoroutine(moveCoroutine);
        }

        moveCoroutine = StartCoroutine(Move(rb2d, currentSpeed));
    
        yield return new WaitForSeconds(directionChangeInterval);
        }
        }







    void ChooseNewEndpoint()
        {
        int[] allowedAngles = { 45, 90, 135, 180, 225, 270, 315 };
        int randomIndex = Random.Range(0, allowedAngles.Length);
        int selectedAngle = allowedAngles[randomIndex];

        currentAngle += selectedAngle;          // Add the selected angle to the current angle here
        currentAngle = Mathf.Repeat(currentAngle, 360); // to ensure angle dosnt exceed 360
        endPosition += Vector3FromAngle(currentAngle);
        }


    Vector3 Vector3FromAngle(float inputAngleDegrees)
        {
        float inputAngleRadians = inputAngleDegrees * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(inputAngleRadians), 
        Mathf.Sin(inputAngleRadians), 0);
        }




    public IEnumerator Move(Rigidbody2D rigidBodyToMove, float speed)
        {

        float remainingDistance = (transform.position - endPosition).sqrMagnitude;

        while (remainingDistance > float.Epsilon)
            {if (targetTransform != null)
                {
                endPosition = targetTransform.position;
                }

            if (rigidBodyToMove != null)
                {
   
                animator.SetBool("isWalking", true);

                Vector3 newPosition = Vector3.
                MoveTowards(rigidBodyToMove.position, endPosition, 
                speed * Time.deltaTime);
                // 7
                rb2d.MovePosition(newPosition);
                // 8
                remainingDistance = (transform.position - 
                endPosition).sqrMagnitude;
                }

                yield return new WaitForFixedUpdate();
            }

            animator.SetBool("isWalking", false);
        }









// pursuit alogrithm for resource collection

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 1
        if (collision.gameObject.CompareTag("collectables") && followPlayer)
            {
                // 2
                currentSpeed = pursuitSpeed;
                // 3
                targetTransform = collision.gameObject.transform;
                // 4
                if (moveCoroutine != null)
                {
                StopCoroutine(moveCoroutine);
                }
                // 5
                moveCoroutine = StartCoroutine(Move(rb2d, 
                currentSpeed));
            }
    }

    void OnTriggerExit2D(Collider2D collision)
        {
        
            if (collision.gameObject.CompareTag("collectables"))
                {
                    animator.SetBool("isWalking", false);
                    currentSpeed = wanderSpeed;
       
                    if (moveCoroutine != null)
                        {
                            StopCoroutine(moveCoroutine);
                        }

                        targetTransform = null;
                }
        }




}
