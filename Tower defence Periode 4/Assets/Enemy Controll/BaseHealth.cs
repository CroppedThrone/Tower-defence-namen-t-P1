using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    public int health = 100;
    public Image healthBar;

    public void TakeBaseHealth(int damage)
    {
        health -= damage;
        healthBar.fillAmount = health / 100f;
    }
}
