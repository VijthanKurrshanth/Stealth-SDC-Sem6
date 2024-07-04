using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskLevelButtons : MonoBehaviour
{
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        int currentLevel = PlayerPrefs.GetInt("currentLevel");
        if (level > currentLevel)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
