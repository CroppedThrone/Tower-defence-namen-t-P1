using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneDelWhen : MonoBehaviour
{
    public void start()
    {
        StartCoroutine(Holdup());
    }
    public IEnumerator Holdup()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}

