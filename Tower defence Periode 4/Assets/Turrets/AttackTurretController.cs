using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTurretController : TurretController
{
    public Animator gunAnimator;
    public Transform turretRotate;
    public Transform barrelRotate;
    public GameObject targetEnemy;

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
                    targetEnemy = collider.transform.parent.gameObject;
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
        yield return new WaitForSeconds(4f);
        Destroy(supplyBox);
    }
    public void EmptyMag()
    {
        canShoot = false;
        isActive = false;
        animator.enabled = true;
        animator.SetTrigger("Power Down");
    }
    public virtual IEnumerator Reload()
    {
        animator.SetTrigger("Power Up");
        currentAmmo = maxAmmo;
        yield return new WaitForSeconds(reloadTime);
        animator.enabled = false;
        canShoot = true;
    }
}
