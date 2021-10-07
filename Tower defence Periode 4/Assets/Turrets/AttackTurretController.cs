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
    public virtual void Reload()
    {

        currentAmmo = maxAmmo;
        canShoot = true;
    }
}
