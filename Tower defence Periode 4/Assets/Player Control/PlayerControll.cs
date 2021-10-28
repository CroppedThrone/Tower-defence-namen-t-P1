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
    public GameObject[] ammoHeld;
    public GameObject reloadImg;
    public Image reloadBar;
    public GameObject interactDot;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GetMoney(0);
        for (int i = 0; i < currentAmmo; i++)
        {
            ammoHeld[i].SetActive(true);
        }
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
            interactDot.SetActive(false);
            RaycastHit hit;
            if (canGatherAmmo == true)
            {
                interactDot.SetActive(true);
            }
            else if(Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, 5f))
            {
                if (hit.collider.GetComponentInParent<AttackTurretController>())
                {
                    interactDot.SetActive(true);
                }
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
            if (canGatherAmmo && currentAmmo < 3)
            {
                StartCoroutine(GatheringAmmo());
            }
            else
            {
                RaycastHit hit;
                if (currentAmmo > 0)
                {
                    if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, 5f))
                    {
                        if (hit.collider.GetComponentInParent<AttackTurretController>())
                        {
                            StartCoroutine(hit.collider.GetComponentInParent<AttackTurretController>().Reload());
                            StartCoroutine(Reloading(hit.collider.GetComponentInParent<AttackTurretController>().reloadTime));
                        }
                    }
                }
                if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, 5f))
                {
                    if (hit.collider.tag == "Banjo")
                    {
                        if (hit.collider.GetComponent<AudioSource>().isPlaying == true)
                        {
                            hit.collider.GetComponent<AudioSource>().Stop();
                        }
                        else
                        {
                            hit.collider.GetComponent<AudioSource>().Play();
                        }
                    }
                }
            }
        }
    }
    IEnumerator GatheringAmmo()
    {
        canAct = false;
        float speed = moveSpeed;
        moveSpeed = 0;
        isSprinting = false;
        if (arm.GetBool("Screen on") == true)
        {
            arm.SetBool("Screen on", false);
        }
        reloadImg.SetActive(true);
        reloadBar.fillAmount = 0;
        for (float  f = 0; f < 0.5f + 0.5f * (3f - currentAmmo); f += Time.fixedDeltaTime)
        {
            yield return new WaitForFixedUpdate();
            reloadBar.fillAmount += 1f / (0.5f + 0.5f * (3f - currentAmmo)) * Time.fixedDeltaTime;
        }
        reloadImg.SetActive(false);
        currentAmmo = 3;
        for (int i = 0; i < currentAmmo; i++)
        {
            ammoHeld[i].SetActive(true);
        }
        canAct = true;
        moveSpeed = speed;
    }
    IEnumerator Reloading(float reloadTime)
    {
        canAct = false;
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
            reloadBar.fillAmount += 1f / reloadTime * Time.fixedDeltaTime;
        }
        reloadImg.SetActive(false);
        currentAmmo--;
        for (int i = 3; i > currentAmmo; i--)
        {
            ammoHeld[i-1].SetActive(false);
        }
        canAct = true;
        moveSpeed = speed;
    }
}
