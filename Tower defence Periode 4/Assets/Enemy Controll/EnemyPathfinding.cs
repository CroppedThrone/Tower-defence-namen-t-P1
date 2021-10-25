using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    public Transform[] waypoints;
    public int waypointCounter;
    public float movespeed;
    Vector3 moveTo;
    public Vector2 deviation;
    bool canMove;
    public int height;
    public int turnspeed;
    
    void FixedUpdate()
    {
        int currentHeight = height;
        if (canMove == true)
        {
            {
                transform.Translate(0, 0, movespeed * Time.fixedDeltaTime);
            }
            if (Vector3.Dot(transform.right, moveTo - transform.position) > 0.15f)
            {
                transform.Rotate(new Vector3(0, turnspeed, 0) * Time.fixedDeltaTime);
            }
            else if(Vector3.Dot(transform.right, moveTo - transform.position) < -0.15f)
            {
                transform.Rotate(new Vector3(0, -turnspeed, 0) * Time.fixedDeltaTime);
            }
            else
            {
                transform.rotation = Quaternion.LookRotation(moveTo - transform.position, Vector3.up);
            }
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            height = currentHeight;
            transform.position = new Vector3(transform.position.x, height, transform.position.z);
            if (Vector3.Distance(transform.position, moveTo) < 1.5f)
            {
                waypointCounter++;
                moveTo = waypoints[waypointCounter].position;
                moveTo.x += Random.Range(-deviation.x, deviation.x);
                moveTo.y = height;
                moveTo.z += Random.Range(-deviation.y, deviation.y);
            }
        }
        height = currentHeight;
    }
    public void FindPath(Transform[] path, Vector2 deviate)
    {
        waypoints = path;
        deviation = deviate;
        StartCoroutine(StartMoving());
    }
    public IEnumerator StartMoving()
    {
        yield return new WaitForSeconds(0.25f);
        moveTo = waypoints[0].position;
        moveTo.x += Random.Range(-deviation.x, deviation.x);
        moveTo.y = transform.position.y;
        moveTo.z += Random.Range(-deviation.y, deviation.y);
        height = (int)transform.position.y;
        canMove = true;
    }
}
