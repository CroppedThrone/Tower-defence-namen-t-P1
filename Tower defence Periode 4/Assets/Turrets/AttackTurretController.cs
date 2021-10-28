using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTurretController : TurretController
{
    public Animator gunAnimator;
    public Transform turretRotate;
    public Transform barrelRotate;
    public GameObject targetEnemy;
    public GameObject error;

    public int damage;
    public float rateOfFire;
    public int maxAmmo;
    public int currentAmmo;
    public int range;
    public float reloadTime;

    public virtual void Start()
    {
        currentAmmo = maxAmmo;
    }
    public void AquireTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);
        foreach (Collider collider in colliders)
        {
            if (collider.transform.parent)
            {
                if (collider.transform.parent.GetComponent<EnemyBehaviour>())
                {
                    targetEnemy = collider.transform.GetComponentInParent<EnemyBehaviour>().targetingCenter;
                    return;
                }
            }
        }
    }
    public override IEnumerator TurretSetup()
    {
        boxAnimator.SetTrigger("Open");
        yield return new WaitForSeconds(0.45f);
        animator.SetTrigger("Setup");
        yield return new WaitForSeconds(2f);
        isActive = true;
        canShoot = true;
        animator.enabled = false;
        gunAnimator.enabled = true;
        yield return new WaitForSeconds(4f);
        Destroy(supplyBox);
    }
    public void EmptyMag()
    {
        canShoot = false;
        isActive = false;
        animator.enabled = true;
        animator.SetTrigger("Power Down");
        error.SetActive(true);
    }
    public virtual IEnumerator Reload()
    {
        isActive = false;
        yield return new WaitForSeconds(reloadTime - 0.5f);
        if (currentAmmo == 0)
        {
            animator.SetTrigger("Power Up");
            yield return new WaitForSeconds(2.5f);
            animator.enabled = false;
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
        }
        error.SetActive(false);
        currentAmmo = maxAmmo;
        canShoot = true;
        isActive = true;
    }
}
