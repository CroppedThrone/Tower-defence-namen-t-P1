using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTurret : MonoBehaviour
{
    public TurretChoice turretChoice;
    public GameObject[] turrets;

    private void Start()
    {
        StartCoroutine(MakeTurretDrop());
        GetComponentInChildren<ParticleSystem>().Play();
    }
    IEnumerator MakeTurretDrop()
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(turrets[(int)turretChoice], transform.position + new Vector3(0, 250, 0), Quaternion.identity);
    }
}

[System.Serializable]
public enum TurretChoice
{
    Basic = 0,
    Sniper = 1,
    Machine_Gun = 2,
    Missile = 3,
    Support = 4
}
