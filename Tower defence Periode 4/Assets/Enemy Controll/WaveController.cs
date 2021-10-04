using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WaveController : MonoBehaviour
{
    public GameObject player;
    public Transform spawnLocation;
    public Vector2 spawnDeviation;
    public Wave[] waves;
    public Transform[] pathWaypoints;

    void Start()
    {
        StartCoroutine(StartWave());
    }
    IEnumerator StartWave()
    {
        yield return new WaitForSeconds(5f);
        for (int w = 0; w < waves.Length; w++)
        {
            for (int e = 0; e < waves[w].enemySpawner.Length; e++)
            {
                Vector3 actualDeviation = new Vector4(Random.Range(-spawnDeviation.x, spawnDeviation.x), 0, Random.Range(-spawnDeviation.y, spawnDeviation.y));
                GameObject spawnedEnemy = Instantiate(waves[w].enemySpawner[e].enemyToSpawn, spawnLocation.position + actualDeviation + transform.up * waves[w].enemySpawner[e].enemyToSpawn.GetComponent<EnemyPathfinding>().height, Quaternion.identity);
                spawnedEnemy.GetComponent<EnemyBehaviour>().playerGold = player.GetComponent<PlayerControll>();
                spawnedEnemy.GetComponent<EnemyPathfinding>().FindPath(pathWaypoints);
                spawnedEnemy.transform.name = "enemy" + e.ToString();
                yield return new WaitForSeconds(waves[w].enemySpawner[e].spawnDelay);
            }
            yield return new WaitForSeconds(10);
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