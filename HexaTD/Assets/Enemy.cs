using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 10f;
    private Transform target;
    private int waypointindex = 0;

    // Use this for initialization
    void Start()
    {
        if (Waypoints.wayPoints.Length == 0) { return; }
        target = Waypoints.wayPoints[0];
        Debug.Log(target);
    }

    // Update is called once per frame
    void Update()
    {
        if (!target) { return; }
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();

        }
    }
    void GetNextWaypoint()
    {

        if (waypointindex >= Waypoints.wayPoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        waypointindex++;
        target = Waypoints.wayPoints[waypointindex];

    }
}
