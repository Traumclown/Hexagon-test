//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour {


    public static Transform[] wayPoints;
    public void Awake()
    {
        //Debug
        wayPoints = new Transform[transform.childCount];
        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPoints[i] = transform.GetChild(i);
           // if (wayPoints[i].GetComponent<MeshFilter>().mesh!=null)
            {
         //       Debug.Log(wayPoints[i].GetComponent<MeshRenderer>().material.name);
            }
            if (wayPoints[i].GetComponent<MeshRenderer>()!=null)
            {
                Debug.Log(wayPoints[i].GetComponent<Renderer>());

            }

        }
        Debug.Log("Hello" + wayPoints.Length);

    }

}
