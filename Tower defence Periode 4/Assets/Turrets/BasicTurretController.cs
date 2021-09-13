using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTurretController : MonoBehaviour
{
    public GameObject supplyBox;
    public Animator animator;
    public Animator boxAnimator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(TurretSetup());
        print("setup");
    }
    IEnumerator TurretSetup()
    {
        boxAnimator.SetTrigger("open");
        yield return new WaitForSeconds(0.45f);
        animator.SetTrigger("setup");
        yield return new WaitForSeconds(5f);
        Destroy(supplyBox);
    }
}
