using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyTurretController : MonoBehaviour
{
    public GameObject supplyBox;
    public Animator animator;
    public Animator boxAnimator;
    public Transform turretRotate;
    public Transform barrelRotate;
    public Transform barrelPoint;
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
    void Update()
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
            if (targetEnemy)
            {
                turretRotate.localRotation = Quaternion.LookRotation(targetEnemy.transform.position - turretRotate.position, Vector3.up);
                Vector3 angles = turretRotate.eulerAngles;
                angles.x = 0f;
                angles.z = 0f;
                turretRotate.rotation = Quaternion.Euler(angles);
                barrelRotate.rotation = Quaternion.LookRotation(targetEnemy.transform.position - barrelRotate.position, Vector3.up);
                Vector3 barrelAngles = barrelRotate.eulerAngles;
                barrelAngles.y = turretRotate.eulerAngles.y;
                barrelAngles.z = 0f;
                barrelRotate.rotation = Quaternion.Euler(barrelAngles);
                if (Vector3.Dot(barrelPoint.forward, targetEnemy.transform.position - transform.position) > 0.95f)
                {
                    if (currentAmmo > 0 && canShoot == true)
                    {
                        StartCoroutine(Fire());
                        canShoot = false;
                    }
                }
            }
        }
    }
    void AquireTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);
        foreach (Collider collider in colliders)
        {
            if (collider.transform.parent)
            {
                if (collider.transform.parent.GetComponent<EnemyBehaviour>())
                {
                    targetEnemy = collider.transform.parent.gameObject;
                    return;
                }
            }
        }
    }
    IEnumerator Fire()
    {
        print(currentAmmo.ToString());
        RaycastHit hit;
        if (Physics.Raycast(barrelPoint.position, (targetEnemy.transform.position - barrelPoint.position), out hit, range))
        {
            print("hit");
            if (hit.collider.GetComponentInParent<EnemyBehaviour>())
            {
                print("enemy hit");
                hit.collider.GetComponentInParent<EnemyBehaviour>().OnTakeDamage(damage);
            }
        }
        currentAmmo -= 1;
        print("finished firing");
        yield return new WaitForSeconds(1f / rateOfFire);
        canShoot = true;
        if (currentAmmo == 0)
        {
            
        }
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
    public void Reload()
    {
        
        currentAmmo = maxAmmo;
        canShoot = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject.transform.parent.gameObject);
    }
}
