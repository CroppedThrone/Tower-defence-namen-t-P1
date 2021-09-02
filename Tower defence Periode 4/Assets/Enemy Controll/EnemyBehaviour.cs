using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public int maxHP;
    public int currentHP;
    public float moveSpeed;
    public int goldValue;
    public NavMeshAgent agent;
    public Transform target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
        agent.SetDestination(target.position);
    }

    public void OnTakeDamage(int damageTaken)
    {
        currentHP -= damageTaken;
        if (currentHP <= 0)
        {
            OnDeath();
        }
    }
    private void OnDeath()
    {
        //give gold
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }
}
