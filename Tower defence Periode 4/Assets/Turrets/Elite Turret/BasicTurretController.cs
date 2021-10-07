using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTurretController : AttackTurretController
{
    public GameObject ammoBox;
    public Transform barrelPoint;

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
    IEnumerator Fire()
    {
        print(currentAmmo.ToString());
        RaycastHit hit;
        Debug.DrawRay(barrelPoint.position, (targetEnemy.transform.position - barrelPoint.position) * 15, Color.red, 2);
        gunAnimator.SetTrigger("Fire");
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
            ammoBox.SetActive(false);
        }
    }
    public override void Reload()
    {
        ammoBox.SetActive(true);
        base.Reload();
    }
}
