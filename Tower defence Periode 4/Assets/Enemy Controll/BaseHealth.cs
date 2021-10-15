using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    public int health = 100;
    public Image healthBar;
    public GameObject gameOverScreen;
    public GameObject hud;
    public Text killText;
    public Text moneyText;
    public Text waveText;
    public PlayerControll player;
    public WaveController wave;

    public void TakeBaseHealth(int damage)
    {
        health -= damage;
        healthBar.fillAmount = health / 100f;
        if (health <1)
        {
            OnGameOver();
        }
    }

    public void OnGameOver()
    {
        player.canAct = false;
        player.StopAllCoroutines();
        player.arm.SetBool("Screen On", false);
        hud.SetActive(false);
        gameOverScreen.SetActive(true);
        killText.text = player.enemiesKilled.ToString();
        moneyText.text = player.moneyEarned.ToString();
        waveText.text = wave.wave.ToString();
    }
}
