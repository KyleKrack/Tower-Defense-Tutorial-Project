using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 10f;

    private Transform target;
    private int waypointIndex = 0;

    private void Start()
    {
        target = Waypoints.points[0]; 
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        Debug.Log("direction:" + direction);
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f) 
        {
            GetNextWaypoint();
        }
    }


    void GetNextWaypoint()
    {
        Debug.Log("waypoint index:" + waypointIndex);
        
        if (waypointIndex >= Waypoints.points.Length-1)
       {
           Destroy(gameObject);
           return; 
       }
        else
        {
            waypointIndex++;
            target = Waypoints.points[waypointIndex];      
        }
       
    }
    
}
