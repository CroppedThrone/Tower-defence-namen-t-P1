using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    Animator animator;
    GameObject target;
    Vector3 targetPos;
    int damage;
    public float speed;
    public float explosionRadius;
    bool isInFlight;
    int detectRadius = 5;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (target == null && isInFlight == true)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, detectRadius);
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.tag == "Enemy")
                {
                    target = collider.gameObject;
                    detectRadius = 5;
                    return;
                }
            }
            detectRadius++;
            if (detectRadius > 100)
            {
                Destroy(gameObject);
            }
        }
        else if (isInFlight == true)
        {
            targetPos = target.transform.position;
        }
    }
    public void Launch(GameObject targetEnemy, int turretDamage)
    {
        target = targetEnemy;
        damage = turretDamage;
        transform.SetParent(null, true);
        StartCoroutine(InAir());

    }
    IEnumerator InAir()
    {
        for (int i = 0; i < 5; i++)
        {
            transform.position += transform.forward * speed * Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
            speed += i;
        }
        isInFlight = true;
        animator.SetTrigger("Fly");
        for (; ;)
        {
            transform.LookAt(targetPos, Vector3.up);
            transform.position += transform.forward * speed * Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isInFlight == true)
        {
            Collider[] colliders = Physics.OverlapSphere(targetPos, explosionRadius);
            foreach (Collider collider in colliders)
            {
                if (collider.GetComponent<EnemyBehaviour>())
                {
                    collider.gameObject.GetComponent<EnemyBehaviour>().OnTakeDamage(damage);
                }
            }
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject.transform.parent.gameObject);
    }
}
