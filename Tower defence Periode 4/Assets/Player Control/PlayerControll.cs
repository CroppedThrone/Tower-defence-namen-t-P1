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
    public bool canAct = true;

    public int moneyEarned;
    public int enemiesKilled;
    public int turretsBought;

    public bool canGatherAmmo;
    public int currentAmmo = 3;
    public Text ammoText;
    public GameObject reloadImg;
    public Image reloadBar;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GetMoney(0);
        ammoText.text = currentAmmo.ToString();
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
        if (canAct == true)
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
    }
    void OnOpenMenu()
    {
        if (canAct == true)
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
        if (canAct == true)
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Base")
        {
            canGatherAmmo = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Base")
        {
            canGatherAmmo = false;
        }
    }
    void OnFire()
    {
        if (canAct == true)
        {
            if (canGatherAmmo)
            {
                if (currentAmmo < 3)
                {
                    StartCoroutine(GatheringAmmo());
                }
            }
            else
            {
                if (currentAmmo > 0)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, 5f))
                    {
                        if (hit.collider.GetComponentInParent<AttackTurretController>())
                        {
                            StartCoroutine(hit.collider.GetComponentInParent<AttackTurretController>().Reload());
                            StartCoroutine(Reloading(hit.collider.GetComponentInParent<AttackTurretController>().reloadTime));
                        }
                    }
                }
            }
        }
    }
    IEnumerator GatheringAmmo()
    {
        float speed = moveSpeed;
        moveSpeed = 0;
        canAct = false;
        isSprinting = false;
        if (arm.GetBool("Screen on") == true)
        {
            arm.SetBool("Screen on", false);
        }
        reloadImg.SetActive(true);
        reloadBar.fillAmount = 0;
        for (float  f = 0; f < 0.5f + 0.5f * (3 - currentAmmo); f += Time.fixedDeltaTime)
        {
            yield return new WaitForFixedUpdate();
            reloadBar.fillAmount += 1 / (3 - currentAmmo) * Time.fixedDeltaTime;
        }
        reloadImg.SetActive(false);
        currentAmmo = 3;
        ammoText.text = currentAmmo.ToString();
        canAct = true;
        moveSpeed = speed;
    }
    IEnumerator Reloading(float reloadTime)
    {
        float speed = moveSpeed;
        moveSpeed = 0;
        canAct = false;
        isSprinting = false;
        if (arm.GetBool("Screen on") == true)
        {
            arm.SetBool("Screen on", false);
        }
        reloadImg.SetActive(true);
        reloadBar.fillAmount = 0;
        for (float f = 0; f < reloadTime; f += Time.fixedDeltaTime)
        {
            yield return new WaitForFixedUpdate();
            reloadBar.fillAmount += 1 / reloadTime * Time.fixedDeltaTime;
        }
        reloadImg.SetActive(false);
        currentAmmo--;
        ammoText.text = currentAmmo.ToString();
        canAct = true;
        moveSpeed = speed;
    }
}
