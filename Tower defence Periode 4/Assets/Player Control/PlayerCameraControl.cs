using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraControl : MonoBehaviour
{
    public float turnSpeed;

    void OnLook(InputValue lookValue)
    {
        Vector2 lookVector = lookValue.Get<Vector2>();
        transform.Rotate(-lookVector.y * turnSpeed, 0, 0);
        //Vector3 finalRotation = new Vector3(Mathf.Clamp(transform.eulerAngles.x, 0, 180), transform.eulerAngles.y, transform.eulerAngles.z);
        //transform.eulerAngles = finalRotation;
    }
}
