using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    public Transform[] waypoints;
    public int waypointCounter;
    public float movespeed;
    Vector3 moveTo;
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
                if (Vector3.Dot(transform.right, moveTo - transform.position) > 0.05f)
                {
                    transform.Rotate(new Vector3(0, 180, 0) * Time.fixedDeltaTime);
                }
                else if(Vector3.Dot(transform.right, moveTo - transform.position) < -0.05f)
                {
                    transform.Rotate(new Vector3(0, -180, 0) * Time.fixedDeltaTime);
                }
            }
            if (Vector3.Distance(transform.position, moveTo) < 1f)
            {
                waypointCounter++;
                moveTo = waypoints[waypointCounter].position;
                moveTo.x += Random.Range(-4, 4);
                moveTo.z += Random.Range(-4, 4);
            }
        }
    }
    public void FindPath(Transform[] path)
    {
        waypoints = path;
        rb = GetComponent<Rigidbody>();
        moveTo = waypoints[0].position;
        moveTo.x += Random.Range(-4, 4);
        moveTo.z += Random.Range(-4, 4);
        canMove = true;
    }
}
