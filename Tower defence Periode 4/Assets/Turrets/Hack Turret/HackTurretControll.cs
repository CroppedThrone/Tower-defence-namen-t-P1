using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackTurretControll : MonoBehaviour
{
    public GameObject supplyBox;
    public Animator animator;
    public Animator boxAnimator;
    public GameObject targetEnemy;
    bool isActive;
    bool canShoot;

    public float rateOfFire;
    public float StunDuration;
    public int range;
    private void Update()
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
                if (canShoot == true)
                {
                    StartCoroutine(AttemptHack());
                    canShoot = false;
                }
            }
        }
    }
    IEnumerator AttemptHack()
    {
        print("hack");
        targetEnemy.GetComponent<EnemyBehaviour>().Stun(StunDuration);
        yield return new WaitForSeconds(1f / rateOfFire);
        targetEnemy = null;
        canShoot = true;

    }
    void AquireTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.GetComponent<EnemyBehaviour>().isStunned == false)
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
        boxAnimator.SetTrigger("Open");
        yield return new WaitForSeconds(0.45f);
        animator.SetTrigger("Setup");
        yield return new WaitForSeconds(2f);
        isActive = true;
        canShoot = true;
        animator.SetTrigger("IsActive");
        yield return new WaitForSeconds(4f);
        Destroy(supplyBox);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject.transform.parent.gameObject);
    }
}
