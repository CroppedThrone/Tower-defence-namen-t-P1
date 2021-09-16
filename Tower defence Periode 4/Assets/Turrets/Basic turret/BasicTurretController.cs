using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTurretController : MonoBehaviour
{
    public GameObject supplyBox;
    public Animator animator;
    public Animator boxAnimator;
    public Animator gunAnimator;
    public GameObject ammoBox;
    public Transform turretRotate;
    public Transform barrelRotate;
    public Transform barrelPoint;
    RaycastHit hit;
    GameObject targetEnemy;
    bool isActive;
    bool canShoot;

    public int damage;
    public float rateOfFire;
    public int maxAmmo;
    public int currentAmmo;
    public int range;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentAmmo = maxAmmo;
    }
    void FixedUpdate()
    {
        if (isActive == true)
        {
            if (targetEnemy == null)
            {
                AquireTarget();
            }
            else if (Vector3.Distance(transform.position, targetEnemy.transform.position) > range)
            {
                targetEnemy = null;
            }
            else if (Vector3.Dot(barrelPoint.forward, targetEnemy.transform.position - transform.position) > 0.9f)
            {
                if (currentAmmo > 0 && canShoot == true)
                {
                    StartCoroutine(Fire());
                    canShoot = false;
                }
            }
            if (targetEnemy)
            {
                turretRotate.localRotation = Quaternion.LookRotation(targetEnemy.transform.position - turretRotate.position, Vector3.up);
                Vector3 angles = turretRotate.eulerAngles;
                angles.x = 0f;
                angles.z = 0f;
                turretRotate.rotation = Quaternion.Euler(angles);
                barrelRotate.rotation = Quaternion.LookRotation(-targetEnemy.transform.position + barrelRotate.position, Vector3.up);
                Vector3 barrelAngles = barrelRotate.eulerAngles;
                barrelAngles.y = turretRotate.eulerAngles.y;
                barrelAngles.z = 0f;
                barrelRotate.rotation = Quaternion.Euler(barrelAngles);
            }
        }
    }
    void AquireTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.tag == "Enemy")
            {
                targetEnemy = collider.gameObject;
                return;
            }
        }
    }
    IEnumerator Fire()
    {
        print(currentAmmo.ToString());
        gunAnimator.SetTrigger("Fire");
        if (Physics.Raycast(barrelPoint.position, barrelPoint.forward, out hit, range))
        {
            if (hit.collider.GetComponent<EnemyBehaviour>())
            {
                print("hit!");
                hit.collider.GetComponent<EnemyBehaviour>().OnTakeDamage(damage);
            }
        }
        else
        {
            print("miss...");
        }
        currentAmmo -= 1;
        print("finished firing");
        yield return new WaitForSeconds(1f / rateOfFire);
        canShoot = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            StartCoroutine(TurretSetup());
            print("setup");
        }
    }
    IEnumerator TurretSetup()
    {
        boxAnimator.SetTrigger("Open");
        yield return new WaitForSeconds(0.45f);
        animator.SetTrigger("Setup");
        yield return new WaitForSeconds(2f);
        isActive = true;
        canShoot = true;
        animator.enabled = false;
        yield return new WaitForSeconds(4f);
        Destroy(supplyBox);
    }
}
