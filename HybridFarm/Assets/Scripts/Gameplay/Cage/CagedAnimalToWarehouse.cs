using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CagedAnimalToWarehouse : MonoBehaviour
{
    public Vector3 targetPosition; 
    private float speedOfThrow;
    private float scaleReductionSpeed;
    private float rotationSpeed;

    void Start ()
    {
        speedOfThrow = 15f;
        scaleReductionSpeed = 1.5f;
        rotationSpeed = 3500f;
    }

    void Update()
    {
        // You can include any other logic you need to run every frame here
    }

    void OnMouseDown()
    {
        // When the object is clicked, start the coroutine to throw and destroy it
        StartCoroutine(ThrowAndDestroyGameAnimal());
    }

    private IEnumerator ThrowAndDestroyGameAnimal()
    {
        yield return new WaitForSeconds(0.001f);

        while (Vector3.Distance(transform.position, targetPosition) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speedOfThrow * Time.deltaTime);
            transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.zero, scaleReductionSpeed * Time.deltaTime);
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

            yield return null;
        }

        Destroy(gameObject);
    }
}
