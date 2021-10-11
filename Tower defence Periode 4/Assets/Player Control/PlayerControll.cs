using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed;
    public float turnSpeed;
    Vector2 moveVector;
    Vector3 angles;
    bool isSprinting;
    public int gold;
    public Transform playerCamera;
    public Text moneyText;
    public Animator arm;

    public int moneyEarned;
    public int enemiesKilled;
    public int turretsBought;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GetMoney(0);
    }

    void OnDevKey()
    {
        GetMoney(1000);
        moneyEarned -= 1000;
        enemiesKilled -= 1;
    }
    void OnMove(InputValue movementValue)
    {
        moveVector = movementValue.Get<Vector2>();
    }
    void OnLook(InputValue lookValue)
    {
        Vector2 lookVector = lookValue.Get<Vector2>();
        transform.Rotate(0, lookVector.x * turnSpeed, 0);
        angles.x -= lookVector.y * turnSpeed;
        angles.x = Mathf.Clamp(angles.x, -90f, 90f);
        playerCamera.localRotation = Quaternion.Euler(angles);
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
    void OnOpenMenu()
    {
        print("blah");
        if (arm.GetBool("Screen on") == true)
        {
            arm.SetBool("Screen on", false);
        }
        else
        {
            arm.SetBool("Screen on", true);
        }
    }

    public void GetMoney(int money)
    {
        gold += money;
        moneyText.text = "$" + gold.ToString();
        if (money > 0)
        {
            moneyEarned += money;
            enemiesKilled++;
        }
        if (money < 0)
        {
            turretsBought++;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isSprinting == false)
        {
            rb.AddRelativeForce(moveVector.x * moveSpeed * 3, 0, moveVector.y * moveSpeed * 3, ForceMode.Acceleration);
        }
        else
        {
            rb.AddRelativeForce(moveVector.x * moveSpeed * 9, 0, moveVector.y * moveSpeed * 9, ForceMode.Acceleration);
        }
        if (moveVector.x == 0 && moveVector.y == 0 && isSprinting == true)
        {
            isSprinting = false;
        }
    }
}
