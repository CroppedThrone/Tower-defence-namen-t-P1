using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamageTest : MonoBehaviour
{
    public int damage = 10;
    public float attackSpeed = 1;
    public float range = 30;
    public RaycastHit hit;

    void Start()
    {
        StartCoroutine(testAttack());
    }

    IEnumerator testAttack()
    {
        for (int i = 0; i > -1; i++)
        {
            print(i.ToString());
            Physics.Raycast(transform.position, transform.forward, out hit, range);
            if (hit.collider.gameObject.tag == "Enemy")
            {
                hit.collider.GetComponent<EnemyBehaviour>().OnTakeDamage(damage);
                print("enemy hit");
            }
            yield return new WaitForSeconds(1f / attackSpeed);
        }
    }
}
