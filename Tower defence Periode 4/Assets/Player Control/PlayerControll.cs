using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControll : MonoBehaviour
{
    Rigidbody rb;
    public float movespeed;
    public float turnspeed;
    Vector2 moveVector;
    bool isSprinting;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        moveVector = movementValue.Get<Vector2>();
    }
    void OnLook(InputValue lookValue)
    {
        Vector2 lookVector = lookValue.Get<Vector2>();
        transform.Rotate(0, lookVector.x * turnspeed, 0);
    }
    void OnSprint()
    {
        if (isSprinting == false)
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isSprinting == false)
        {
            rb.AddRelativeForce(moveVector.x * movespeed * 3, 0, moveVector.y * movespeed * 3);
        }
        else
        {
            rb.AddRelativeForce(moveVector.x * movespeed * 9, 0, moveVector.y * movespeed * 9);
        }
        if (moveVector.x == 0 && moveVector.y == 0 && isSprinting == true)
        {
            isSprinting = false;
        }
    }
}
