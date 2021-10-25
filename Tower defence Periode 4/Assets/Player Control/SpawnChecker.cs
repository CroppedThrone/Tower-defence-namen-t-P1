using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnChecker : MonoBehaviour
{
    public bool canSpawn;
    public Image stip;

    void FixedUpdate()
    {
        int objectsInArea = 0;
        Collider[] colliders = Physics.OverlapBox(transform.position + transform.forward * 2.5f, new Vector3(1.5f, 1, 1.5f), transform.rotation);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.tag != "Ground" && collider.gameObject.tag != "Rubbish")
            {
                objectsInArea++;
            }
        }
        RaycastHit hit;
        Physics.Raycast(transform.position + transform.forward * 2.5f, Vector3.down, out hit, 2f);
        if(objectsInArea == 0 && hit.collider.gameObject.tag == "Ground")
        {
            canSpawn = true;
        }
        else
        {
            canSpawn = false;
        }
        if (canSpawn == true)
        {
            stip.color = Color.green;
        }
        else if (canSpawn == false)
        {
            stip.color = Color.red;
        }
    }
}
