using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class shadowEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 Offset= new Vector3 (-0.1f, -0.1f);
    public Material Material;

    GameObject shadow; 

    void Start()
    {
        shadow = new GameObject ("Shadow");
        shadow.transform.parent = transform;

        shadow.transform.localPosition=Offset;
        shadow.transform.localRotation=Quaternion.identity;
        
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        SpriteRenderer sr= shadow.AddComponent <SpriteRenderer>();
        sr.sprite = renderer.sprite;
        sr.material =Material;

        sr.sortingLayerName =renderer.sortingLayerName;
        sr.sortingOrder = renderer.sortingOrder-1;


    }

    // Update is called once per frame
    void LateUpdate()
    {
        shadow.transform.localPosition =Offset;
    }
}
