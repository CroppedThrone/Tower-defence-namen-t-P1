using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public int maxHP;
    public int currentHP;
    public int goldValue;
    public PlayerControll playerGold;
    public int damageToBase;
    public bool isStunned;
    public GameObject deathExplosion;
    bool canTakeDamage = true;
    public GameObject targetingCenter;

    private void Start()
    {
        currentHP = maxHP;
    }
    public IEnumerator Stun(float duration)
    {
        isStunned = true;
        print("Is Being Hacked");
        float speed = GetComponent<EnemyPathfinding>().movespeed;
        for (int i = 0; i < 10; i++)
        {
            GetComponent<EnemyPathfinding>().movespeed -= speed * 0.1f;
            yield return new WaitForFixedUpdate();
        }
        GetComponent<Animator>().enabled = false;
        yield return new WaitForSeconds(duration);
        GetComponent<Animator>().enabled = true;
        for (int i = 0; i < 10; i++)
        {
            GetComponent<EnemyPathfinding>().movespeed += speed * 0.1f;
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(0.5f);
        isStunned = false;
    }
    public void OnTakeDamage(int damageTaken)
    {
        if (canTakeDamage == true)
        {
            currentHP -= damageTaken;
            if (currentHP < 1)
            {
                print("die");
                OnDeath();
            }
            canTakeDamage = false;
            StartCoroutine(Invultimer());
        }
    }
    IEnumerator Invultimer()
    {
        yield return null;
        canTakeDamage = true;
    }
    private void OnDeath()
    {
        Instantiate(deathExplosion, transform.position, Quaternion.identity);
        playerGold.GetMoney(goldValue);
        print("ded");
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            collision.gameObject.GetComponent<BaseHealth>().TakeBaseHealth(damageToBase);
            Destroy(gameObject);
        }
    }
}
