using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public int maxHP;
    public float currentHP;
    public int goldValue;
    public PlayerControll playerGold;
    public int damageToBase;

    void Start()
    {
        currentHP = maxHP - 0.1f;
    }

    public void OnTakeDamage(int damageTaken)
    {
        currentHP -= damageTaken;
        if (currentHP <= 1)
        {
            print("die");
            OnDeath();
        }
    }
    private void OnDeath()
    {
        playerGold.GetMoney(goldValue);
        print("ded");
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
