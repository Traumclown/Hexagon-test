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

        wayPoints = new Transform[PathFieldCount];


        //wayPoints[i] = transform.GetChild(i);
        // if (wayPoints[i].GetComponent<MeshFilter>().mesh!=null)
        // Debug.Log(wayPoints[i].GetComponent<MeshRenderer>().material.name);
        // Debug.Log("##### " + wayPoints[i].GetComponent<Renderer>().material.name);



        for (int i = 0; i < wayPoints.Length; i++)
        {



            if (transform.GetChild(i).tag == "path")
            {
                wayPoints[i] = transform.GetChild(i);
                Debug.Log("##### " + wayPoints[i].tag);
            }

        }
        Debug.Log("Hello" + wayPoints.Length);

    }

}
