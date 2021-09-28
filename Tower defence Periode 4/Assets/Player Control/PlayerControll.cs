using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    bool canJump;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GetMoney(0);
    }

    void OnFuckGoBack()
    {
        SceneManager.LoadScene(1);
    }
    void OnDevKey()
    {
        GetMoney(1000);
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
    void OnJump()
    {
        if (canJump == true)
        {
            rb.AddForce(0, 50f, 0, ForceMode.Impulse);
            canJump = false;
        }
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

    public void GetMoney(int money)
    {
        gold += money;
        moneyText.text = "$" + gold.ToString();
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "Path")
        {
            canJump = true;
        }
    }
}
