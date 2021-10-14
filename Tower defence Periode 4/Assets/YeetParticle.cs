using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YeetParticle : MonoBehaviour
{
    public float duration;
    void Start()
    {
        StartCoroutine(Yeet());
    }
    IEnumerator Yeet()
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}
