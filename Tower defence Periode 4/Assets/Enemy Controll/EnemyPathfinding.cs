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
    public float height;
    public int turnspeed;
    
    void FixedUpdate()
    {
        if (canMove == true)
        {
            {
                print("move");
                //rb.AddRelativeForce(new Vector3(0, 0, movespeed));
                transform.Translate(0, 0, movespeed * Time.fixedDeltaTime);
            }
            if (Vector3.Dot(transform.right, moveTo - transform.position) > 0.1f)
            {
                transform.Rotate(new Vector3(0, turnspeed, 0) * Time.fixedDeltaTime);
            }
            else if(Vector3.Dot(transform.right, moveTo - transform.position) < -0.1f)
            {
                transform.Rotate(new Vector3(0, -turnspeed, 0) * Time.fixedDeltaTime);
            }
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            transform.position = new Vector3(transform.position.x, height, transform.position.z);
            if (Vector3.Distance(transform.position, moveTo) < 1.5f)
            {
                waypointCounter++;
                moveTo = waypoints[waypointCounter].position;
                moveTo.x += Random.Range(-4, 4);
                moveTo.y += height;
                moveTo.z += Random.Range(-4, 4);
            }
        }
    }
    public void FindPath(Transform[] path)
    {
        waypoints = path;
        rb = GetComponent<Rigidbody>();
        StartCoroutine(StartMoving());
    }
    IEnumerator StartMoving()
    {
        yield return new WaitForSeconds(0.25f);
        moveTo = waypoints[0].position;
        moveTo.x += Random.Range(-4, 4);
        moveTo.y = transform.position.y;
        moveTo.z += Random.Range(-4, 4);
        canMove = true;
    }
}
