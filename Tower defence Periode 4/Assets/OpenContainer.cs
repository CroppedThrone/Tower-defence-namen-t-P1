using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenContainer : MonoBehaviour
{
    
    public AudioSource containerClosing;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NotClosingContainer());
    }
    IEnumerator NotClosingContainer()
    {
        yield return new WaitForSeconds(1);
        GetComponent<Animator>().SetTrigger("Open Door");
        containerClosing.Play();
    }
}
