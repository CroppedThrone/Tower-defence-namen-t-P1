using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveControllerLVL2 : WaveController
{
    public Transform spawnLocation2;
    public Wave[] waves2;
    public Transform[] pathWaypoints2;

    private void Start()
    {
        StartCoroutine(BeginWaves());
    }
    IEnumerator BeginWaves()
    {
        waveTimerText.gameObject.SetActive(true);
        for (int i = 99; i > 30; i--)
        {
            waveTimer.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        StartCoroutine(StartWave());
    }
    public override IEnumerator SecondWave(int wave)
    {
        for (int e = 0; e < waves2[wave].enemySpawner.Length; e++)
        {
            yield return new WaitForSeconds(waves2[wave].enemySpawner[e].spawnDelay);
            Vector3 actualDeviation = new Vector4(Random.Range(-spawnDeviation.x, spawnDeviation.x), 0, Random.Range(-spawnDeviation.y, spawnDeviation.y));
            GameObject spawnedEnemy = Instantiate(waves2[wave].enemySpawner[e].enemyToSpawn, spawnLocation2.position + actualDeviation + transform.up * waves2[wave].enemySpawner[e].enemyToSpawn.GetComponent<EnemyPathfinding>().height, Quaternion.identity);
            spawnedEnemy.GetComponent<EnemyBehaviour>().playerGold = player.GetComponent<PlayerControll>();
            spawnedEnemy.GetComponent<EnemyPathfinding>().FindPath(pathWaypoints2, spawnDeviation);
            spawnedEnemy.transform.name = "enemy2." + e.ToString();
        }
    }
}
