using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneDelWhen : MonoBehaviour
{
    public GameObject fuc;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("Turret"))
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
        Destroy(gameObject);
       
}
