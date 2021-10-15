using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{
    public GameObject player;
    public Transform spawnLocation;
    public Vector2 spawnDeviation;
    public Wave[] waves;
    public Transform[] pathWaypoints;
    public Text waveCounter;
    public Text waveTimer;
    public Text waveTimerText;
    public int wave;
    bool skip;

    void OnSkip()
    {
        if (skip == false)
        {
            skip = true;
            StartCoroutine(Skip());
        }
    }
    IEnumerator Skip()
    {
        yield return new WaitForSeconds(1f);
        skip = false;
    }
    public IEnumerator StartWave()
    {
        for (int w = 0; w < waves.Length; w++)
        {
            waveTimerText.gameObject.SetActive(true);
            for (int i = 30; i > 0; i--)
            {
                if (i > 9)
                {
                    waveTimer.text = i.ToString();
                }
                else
                {
                    waveTimer.text = "0" + i.ToString();
                }
                yield return new WaitForSeconds(1);
                if (skip == true)
                {
                    break;
                }
            }
            waveTimerText.gameObject.SetActive(false);
            waveCounter.text = (w + 1).ToString();
            for (int e = 0; e < waves[w].enemySpawner.Length; e++)
            {
                Vector3 actualDeviation = new Vector4(Random.Range(-spawnDeviation.x, spawnDeviation.x), 0, Random.Range(-spawnDeviation.y, spawnDeviation.y));
                GameObject spawnedEnemy = Instantiate(waves[w].enemySpawner[e].enemyToSpawn, spawnLocation.position + actualDeviation + transform.up * waves[w].enemySpawner[e].enemyToSpawn.GetComponent<EnemyPathfinding>().height, Quaternion.identity);
                spawnedEnemy.GetComponent<EnemyBehaviour>().playerGold = player.GetComponent<PlayerControll>();
                spawnedEnemy.GetComponent<EnemyPathfinding>().FindPath(pathWaypoints, spawnDeviation);
                spawnedEnemy.transform.name = "enemy" + e.ToString();
                yield return new WaitForSeconds(waves[w].enemySpawner[e].spawnDelay);
            }
            wave++;
        }
        print("done");
    }
}

[System.Serializable]
public class Wave
{
    public EnemySpawner[] enemySpawner;
}

[System.Serializable]
public class EnemySpawner
{
    public GameObject enemyToSpawn;
    public float spawnDelay;
}