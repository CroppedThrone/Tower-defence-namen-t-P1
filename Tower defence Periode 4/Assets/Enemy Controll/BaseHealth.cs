using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaseHealth : MonoBehaviour
{
    public int health = 100;
    public Image healthBar;
    public PlayerControll player;
    public WaveController wave;
    public int victorySceneNumber;
    public ProgressTracker tracker;

    private void Update()
    {
        if (wave.wavesFinished == true)
        {
            int enemiesLeft = 0;
            Collider[] colliders = Physics.OverlapSphere(transform.position, 1000);
            foreach (Collider collider in colliders)
            {
                if (collider.GetComponentInParent<EnemyBehaviour>())
                {
                    enemiesLeft++;
                }
            }
            if (enemiesLeft == 0)
            {
                SceneManager.LoadScene(victorySceneNumber);
            }
        }
    }

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
        tracker.enemiesKilled = player.enemiesKilled;
        tracker.goldEarned = player.moneyEarned;
        tracker.turretsBought = player.turretsBought;
        tracker.wavesSurvived = wave.wave;
        tracker.totalEnemiesKilled += player.enemiesKilled;
        tracker.totalGoldEarned += player.moneyEarned;
        tracker.totalTurretsBought += player.turretsBought;
        tracker.totalWavesSurvived += wave.wave;
        SceneManager.LoadScene(6);
    }
}
