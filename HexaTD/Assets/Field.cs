using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{

    public static bool path = false;

    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.GetComponent<Renderer>().material.name != "")
        {
            Debug.Log("not empty");
            Debug.Log(gameObject.GetComponent<Renderer>().material.name);
            if(gameObject.GetComponent<Renderer>().material.name != "path")
            {
                Debug.Log("hit");
                path = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
