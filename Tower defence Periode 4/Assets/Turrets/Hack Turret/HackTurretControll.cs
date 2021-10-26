using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackTurretControll : TurretController
{
    public GameObject targetEnemy;

    public float rateOfFire;
    public float StunDuration;
    public int range;
    public AudioSource biem;
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
        biem.Play();
        print("hack");
        StartCoroutine(targetEnemy.GetComponent<EnemyBehaviour>().Stun(StunDuration));
        yield return new WaitForSeconds(1f / rateOfFire);
        targetEnemy = null;
        canShoot = true;

    }
    public override IEnumerator TurretSetup()
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
    void AquireTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);
        foreach (Collider collider in colliders)
        {
            if (collider.transform.parent)
            {
                if (collider.transform.parent.GetComponent<EnemyBehaviour>())
                {
                    if (collider.transform.GetComponentInParent<EnemyBehaviour>().isStunned == false)
                    {
                        targetEnemy = collider.transform.parent.gameObject;
                        return;
                    }
                }
            }
        }
    }
}
