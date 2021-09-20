using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTurretController : MonoBehaviour
{
    public GameObject supplyBox;
    public Animator animator;
    public Animator boxAnimator;
    public Animator gunAnimator;
    public Transform turretRotate;
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
            //if (targetEnemy)
            //{
            //    turretRotate.localRotation = Quaternion.LookRotation(targetEnemy.transform.position - turretRotate.position, Vector3.up);
            //    Vector3 angles = turretRotate.eulerAngles;
            //    angles.x = 0f;
            //    angles.z = 0f;
            //    turretRotate.rotation = Quaternion.Euler(angles);
            //    barrelRotate.rotation = Quaternion.LookRotation(-targetEnemy.transform.position + barrelRotate.position, Vector3.up);
            //    Vector3 barrelAngles = barrelRotate.eulerAngles;
            //    barrelAngles.y = turretRotate.eulerAngles.y;
            //    barrelAngles.z = 0f;
            //    barrelRotate.rotation = Quaternion.Euler(barrelAngles);
            //}
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
        animator.SetTrigger("Fire");
        targetEnemy.GetComponent<EnemyBehaviour>().OnTakeDamage(damage);
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
        yield return new WaitForSeconds(0.5f);
        gunAnimator.SetTrigger("Setup");
        yield return new WaitForSeconds(2f);
        isActive = true;
        canShoot = true;
        //animator.enabled = false;
        yield return new WaitForSeconds(4f);
        Destroy(supplyBox);
    }
}
