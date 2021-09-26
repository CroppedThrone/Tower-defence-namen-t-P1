using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public ParticleSystem test;
    public void OnCollisionEnter(Collision collision)
    {
        test.Play();
    }
}
