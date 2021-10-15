using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretErrorRotate : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(0, 1, 0);
    }
}
