using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneNotusme : MonoBehaviour
{
    public GameObject smoke;
    public Transform stone;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Turret"))
        {
            StoneGone();
        }

        if (collision.gameObject.tag == ("Player"))
        {
            StoneGone();
        }

        if (collision.gameObject.tag == ("Enemy"))
        {
            StoneGone();
        }

    }
    public void StoneGone()
    {
        Instantiate(smoke, stone.position, stone.rotation);
        Destroy(gameObject);
    }
}
