using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelNotusme : MonoBehaviour
{
    public GameObject smokeBarrel;
    public Transform barrel;
    public AudioSource barrelRollSound;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Turret"))
        {
            barrelGone();
        }

        if (collision.gameObject.tag == ("Player"))
        {
            barrelRoll();
        }

        if (collision.gameObject.tag == ("Enemy"))
        {
            barrelGone();
        }

    }
    public void barrelGone()
    {
        Instantiate(smokeBarrel, barrel.position, barrel.rotation);
        Destroy(gameObject);
    }

    public void barrelRoll()
    {
        barrelRollSound.Play();
    }
}
