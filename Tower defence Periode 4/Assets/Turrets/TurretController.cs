using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public GameObject supplyBox;
    public ParticleSystem dropSmoke;
    public Animator animator;
    public Animator boxAnimator;
    public bool isActive;
    public bool canShoot;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            dropSmoke.Play();
            StartCoroutine(TurretSetup());
            print("setup");
        }
    }
    public virtual IEnumerator TurretSetup()
    {
        boxAnimator.SetTrigger("Open");
        yield return new WaitForSeconds(0.45f);
        animator.SetTrigger("Setup");
        yield return new WaitForSeconds(2f);
        Destroy(dropSmoke.gameObject);
        isActive = true;
        canShoot = true;
        yield return new WaitForSeconds(4f);
        Destroy(supplyBox);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject.transform.parent.gameObject);
    }
}
