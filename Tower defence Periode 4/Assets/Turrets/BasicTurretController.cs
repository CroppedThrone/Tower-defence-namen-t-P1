using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTurretController : MonoBehaviour
{
    public GameObject supplyBox;
    public Animator animator;
    public Animator boxAnimator;
    public GameObject ammoBox;
    public Transform turretRotate;
    public Transform barrelRotate;
    public Transform dummyRotate;

    public bool canShoot;
    public int damage;
    public float rateOfFire;
    public int maxAmmo;
    public int currentAmmo;
    public int range;
    public GameObject targetEnemy;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        if (targetEnemy == null)
        {
            AquireTarget();
        }
        else if (Vector3.Distance(transform.position, targetEnemy.transform.position) > range)
        {
            targetEnemy = null;
        }
        else if (Vector3.Dot(transform.forward, targetEnemy.transform.position - transform.position) > 0.9f)
        {

        }
        if (targetEnemy)
        {
            Vector3 relativePos = targetEnemy.transform.position - dummyRotate.position;

            turretRotate.localRotation = Quaternion.LookRotation(relativePos, Vector3.up);
            barrelRotate.rotation = Quaternion.LookRotation(-relativePos, Vector3.right);
            Vector3 angles = barrelRotate.eulerAngles;
            angles.z = 90f;
            barrelRotate.rotation = Quaternion.Euler(angles);
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
        boxAnimator.SetTrigger("open");
        yield return new WaitForSeconds(0.45f);
        animator.SetTrigger("setup");
        yield return new WaitForSeconds(1f);
        canShoot = true;
        yield return new WaitForSeconds(4f);
        Destroy(supplyBox);
    }
}
