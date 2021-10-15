using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public GameObject supplyBox;
    public GameObject dropSmoke;
    public Animator animator;
    public Animator boxAnimator;
    public bool isActive;
    public bool canShoot;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            GameObject smoke = Instantiate(dropSmoke, transform.position + transform.up * 0.1f, Quaternion.identity);
            smoke.GetComponent<ParticleSystem>().Play();
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
