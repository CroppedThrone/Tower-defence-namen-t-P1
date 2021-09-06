using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraControl : MonoBehaviour
{
    public float turnSpeed;
    Vector3 angles;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void OnLook(InputValue lookValue)
    {
        Vector2 lookVector = lookValue.Get<Vector2>();
        angles.x -= lookVector.y * turnSpeed;
        angles.x = Mathf.Clamp(angles.x, -90f, 90f);
        transform.localRotation = Quaternion.Euler(angles);
    }
}
