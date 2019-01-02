//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{


    public static Transform[] wayPoints;
    public void Awake()
    {
        int PathFieldCount = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).tag == "path")
            {
                PathFieldCount++;
            }
        }

        Debug.Log(PathFieldCount);
        wayPoints = new Transform[PathFieldCount];


        //wayPoints[i] = transform.GetChild(i);
        // if (wayPoints[i].GetComponent<MeshFilter>().mesh!=null)
        // Debug.Log(wayPoints[i].GetComponent<MeshRenderer>().material.name);
        // Debug.Log("##### " + wayPoints[i].GetComponent<Renderer>().material.name);

        int counter = 0;

        for (int i = 0; i < transform.childCount; i++)
        {
            
            if (transform.GetChild(i).tag == "path")
            {
                wayPoints[counter] = transform.GetChild(i);
                counter++;
                Debug.Log("##### " + transform.GetChild(i).tag);
            }

        }
        Debug.Log("Hello" + wayPoints.Length);

    }

}
