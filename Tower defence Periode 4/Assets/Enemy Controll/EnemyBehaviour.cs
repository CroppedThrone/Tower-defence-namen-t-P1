using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public int maxHP;
    public float currentHP;
    public float moveSpeed;
    public int goldValue;
    public NavMeshAgent agent;
    public Transform target;
    public PlayerControll playerGold;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
        agent.SetDestination(target.position);
        currentHP = maxHP - 0.1f;
    }

    public void OnTakeDamage(int damageTaken)
    {
        currentHP -= damageTaken;
        if (currentHP <= 1)
        {
            OnDeath();
        }
    }
    private void OnDeath()
    {
        playerGold.gold += goldValue;
        Destroy(gameObject);
    }

    //void GiveGold()
    //{
    //    playerGold.gold += goldValue;
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }
}
