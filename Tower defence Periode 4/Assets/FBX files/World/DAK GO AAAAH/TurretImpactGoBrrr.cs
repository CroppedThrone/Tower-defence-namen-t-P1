using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretImpactGoBrrr : MonoBehaviour
{
    public void TurretCrash()
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }
        GetComponent<Animator>().SetTrigger("Crash");
    }
}
