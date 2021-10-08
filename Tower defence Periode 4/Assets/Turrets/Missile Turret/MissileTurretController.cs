using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTurretController : AttackTurretController
{
    public MissileArray[] missileArray = new MissileArray[2];
    public GameObject missile;
    public int loadedMissile;
    public float reloadTimer;

    public override void Start()
    {
        base.Start();
        currentAmmo = maxAmmo;
        for (int i = 0; i < missileArray.Length; i++)
        {
            missileArray[i].missile = Instantiate(missile, missileArray[i].spawnPoint.position, missileArray[i].spawnPoint.rotation, missileArray[i].spawnPoint);
        }
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
            if (targetEnemy)
            {
                turretRotate.localRotation = Quaternion.LookRotation(targetEnemy.transform.position - turretRotate.position, Vector3.up);
                Vector3 angles = turretRotate.eulerAngles;
                angles.x = 0f;
                angles.z = 0f;
                turretRotate.rotation = Quaternion.Euler(angles);
                if (Vector3.Dot(turretRotate.forward, targetEnemy.transform.position - transform.position) > 0.9f)
                {
                    if (canShoot == true && currentAmmo > 0)
                    {
                        canShoot = false;
                        StartCoroutine(Fire());
                    }
                }
            }
        }
    }
    IEnumerator Fire()
    {
        missileArray[loadedMissile].missile.GetComponent<MissileController>().Launch(targetEnemy, damage);
        missileArray[loadedMissile].missile = null;
        loadedMissile++;
        yield return new WaitForSeconds(1f / rateOfFire);
        if (loadedMissile == 2 & currentAmmo > 1)
        {
            StartCoroutine(Resupply());
        }
        else if (loadedMissile == 2 & currentAmmo == 1)
        {
            isActive = false;
            gunAnimator.SetTrigger("Start reload");
        }
        else
        {
            canShoot = true;
        }
    }
    IEnumerator Resupply()
    {
        isActive = false;
        gunAnimator.SetTrigger("Start reload");
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < missileArray.Length; i++)
        {
            missileArray[i].missile = Instantiate(missile, missileArray[i].spawnPoint.position, missileArray[i].spawnPoint.rotation, missileArray[i].spawnPoint);
        }
        yield return new WaitForSeconds(reloadTimer);
        gunAnimator.SetTrigger("Finish reload");
        yield return new WaitForSeconds(1.8f);
        loadedMissile = 0;
        currentAmmo--;
        canShoot = true;
        isActive = true;
    }
    public override void Reload()
    {
        StartCoroutine(Reloading());
    }
    public IEnumerator Reloading()
    {
        for (int i = 0; i < missileArray.Length; i++)
        {
            missileArray[i].missile = Instantiate(missile, missileArray[i].spawnPoint.position, missileArray[i].spawnPoint.rotation, missileArray[i].spawnPoint);
        }
        yield return new WaitForSeconds(reloadTimer);
        gunAnimator.SetTrigger("Finish reload");
        yield return new WaitForSeconds(1.8f);
        loadedMissile = 0;
        currentAmmo = maxAmmo;
        canShoot = true;
        isActive = true;
    }
    public override IEnumerator TurretSetup()
    {
        boxAnimator.SetTrigger("Open");
        yield return new WaitForSeconds(0.45f);
        animator.SetTrigger("Setup");
        yield return new WaitForSeconds(0.45f);
        gunAnimator.SetTrigger("Setup");
        yield return new WaitForSeconds(2f);
        isActive = true;
        canShoot = true;
        animator.enabled = false;
        yield return new WaitForSeconds(4f);
        Destroy(supplyBox);
    }
}

[System.Serializable]
public class MissileArray
{
    public GameObject missile;
    public Transform spawnPoint;
}