using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraControl : MonoBehaviour
{
    public float turnSpeed;
    private Quaternion _cameraTargetRot;

    void OnLook(InputValue lookValue)
    {
        Vector2 lookVector = lookValue.Get<Vector2>();
        _cameraTargetRot *= Quaternion.Euler(-lookVector.y * turnSpeed, 0f, 0f);
        _cameraTargetRot = LockCameraMovement(_cameraTargetRot);
        transform.rotation = _cameraTargetRot;
    }
    private Quaternion LockCameraMovement(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        var angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, -90, 90);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }
}
