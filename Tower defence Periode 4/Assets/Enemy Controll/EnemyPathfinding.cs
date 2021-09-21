using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    public Vector3[] waypoints;
    public int waypointCounter;
    public float movespeed;
    
    void Update()
    {
        //if (Vector3.Dot(transform.forward, waypoints[waypointCounter] - transform.position) > 0.9f)
        {
            transform.rotation = Quaternion.LookRotation(waypoints[waypointCounter] - transform.position, Vector3.up);
        }
        //else
        {
            transform.Translate(transform.forward * movespeed * Time.deltaTime);
        }
        if (Vector3.Distance(transform.position, waypoints[waypointCounter]) < 1f)
        {
            waypointCounter++;
        }
    }
    public void FindPath(Vector3[] path, Vector2 pathDeviation)
    {
        waypoints = path;
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i].x += Random.Range(-pathDeviation.x, pathDeviation.x);
            waypoints[i].z += Random.Range(-pathDeviation.y, pathDeviation.y);
        }
    }
}
