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
    public GameObject explosion;
    public GameObject rocketSmoke;

    public AudioSource missileGo;
    public AudioSource missileLoop;
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
                if (collider.transform.parent)
                {
                    if (collider.transform.parent.GetComponent<EnemyBehaviour>())
                    {
                        target = collider.transform.parent.gameObject;
                        detectRadius = 5;
                        return;
                    }
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
        rocketSmoke.GetComponent<ParticleSystem>().Play(true);
        missileGo.Play();
        missileLoop.Play();
    }
    IEnumerator InAir()
    {
        for (int i = 0; i < 10; i++)
        {
            transform.position += transform.forward * speed * Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
            speed += i * 0.6f;
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
                if (collider.GetComponentInParent<EnemyBehaviour>())
                {
                    collider.gameObject.GetComponentInParent<EnemyBehaviour>().OnTakeDamage(damage);
                }
            }
            Instantiate(explosion, transform.position + transform.forward * 1.3f, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
