using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    public Vector3[] waypoints;
    public int waypointCounter;
    public float movespeed;
    Rigidbody rb;
    bool canMove;
    
    void FixedUpdate()
    {
        if (canMove == true)
        {
            //if (Vector3.Dot(transform.forward, waypoints[waypointCounter] - transform.position) > 0.95f)
            {
                print("move");
                rb.AddRelativeForce(new Vector3(0, 0, movespeed));
            }
            
            {
                print("turn");
                if (Vector3.Dot(transform.right, waypoints[waypointCounter] - transform.position) > 0.05f)
                {
                    transform.Rotate(new Vector3(0, 180, 0) * Time.fixedDeltaTime);
                }
                else if(Vector3.Dot(transform.right, waypoints[waypointCounter] - transform.position) < -0.05f)
                {
                    transform.Rotate(new Vector3(0, -180, 0) * Time.fixedDeltaTime);
                }
            }
            if (Vector3.Distance(transform.position, waypoints[waypointCounter]) < 1f)
            {
                waypointCounter++;
            }
        }
    }
    public void FindPath(Vector3[] path, Vector3 pathDeviation)
    {
        waypoints = path;
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] += pathDeviation;
        }
        rb = GetComponent<Rigidbody>();
        canMove = true;
    }
}
