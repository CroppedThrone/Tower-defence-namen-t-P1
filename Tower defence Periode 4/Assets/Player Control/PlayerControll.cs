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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        moveVector = movementValue.Get<Vector2>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(moveVector.x * movespeed * 3, 0, moveVector.y * movespeed * 3);
    }
}
