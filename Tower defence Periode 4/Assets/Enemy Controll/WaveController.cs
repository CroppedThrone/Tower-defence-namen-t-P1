using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public Transform target;
    public Vector3 spawnLocation;
    public Vector2 spawnDeviation;
    public Wave[] waves;

    void OnFire()
    {
        print("start wave");
        StartCoroutine(StartWave());
    }
    IEnumerator StartWave()
    {
        for (int w = 0; w < waves.Length; w++)
        {
            for (int e = 0; e < waves[w].enemySpawner.Length; e++)
            {
                Vector3 actualDeviation = new Vector4(Random.Range(-spawnDeviation.x, spawnDeviation.x), 0, Random.Range(-spawnDeviation.y, spawnDeviation.y));
                GameObject spawnedEnemy = Instantiate(waves[w].enemySpawner[e].enemyToSpawn, spawnLocation + actualDeviation, Quaternion.identity);
                spawnedEnemy.GetComponent<EnemyBehaviour>().target = target;
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