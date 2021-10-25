using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialControl : MonoBehaviour
{
    public GameObject[] tutorialImages;
    public int tutStage;
    public Animator containerDoors;
    public PlayerControll playerControll;
    public GameObject[] exampleWave;
    public WaveController waveController;
    public GameObject showWave;
    public WaveController waveManager;
    bool tutWaveActive;
    int moveAmount;
    int dead;

    void OnSkip()
    {
        if (tutStage < 4 || tutStage == 5 || tutStage > 6)
        {
            if (tutStage == 1)
            {
                containerDoors.SetTrigger("Open Door");
            }
            if (tutStage >= 0)
            {
                ProgressTutorial();
            }
        }
    }
    private void Start()
    {
        playerControll = GetComponent<PlayerControll>();
        tutorialImages[tutStage].SetActive(true);
    }
    private void Update()
    {
        if (tutStage == 2)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 6);
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.GetComponentInParent<TurretController>())
                {
                    ProgressTutorial();
                    break;
                }
            }
        }
        else if(tutStage == 6)
        {
            if (tutWaveActive == false)
            {
                StartCoroutine(TutWave());
                tutWaveActive = true;
            }
            else if (playerControll.enemiesKilled >= exampleWave.Length)
            {
                ProgressTutorial();
            }
        }
        else if (tutStage == 11)
        {
            if (playerControll.turretsBought > 0)
            {
                ProgressTutorial();
            }
        }
        else if (tutStage == 12)
        {
            StartCoroutine(EndTutorial());
            tutStage = -1;
        }
    }
    void ProgressTutorial()
    {
        tutorialImages[tutStage].SetActive(false);
        tutStage++;
        tutorialImages[tutStage].SetActive(true);
    }
    void OnMove()
    {
        if (tutStage == 0)
        {
            if (moveAmount < 7)
            {
                moveAmount++;
            }
            else
            {
                ProgressTutorial();
            }
        }
    }
    void OnFire()
    {
        if (tutStage == 1)
        {
            if (playerControll.canGatherAmmo == true)
            {
                StartCoroutine(AmmoGathering());
            }
        }
        else if (tutStage == 4)
        {
            if (Physics.Raycast(playerControll.playerCamera.position, playerControll.playerCamera.forward, out RaycastHit hit, 6))
            {
                if (hit.collider.GetComponentInParent<AttackTurretController>())
                {
                    StartCoroutine(Reloadin());
                }
            }
        }
    }
    IEnumerator AmmoGathering()
    {
        yield return new WaitForSeconds(2);
        ProgressTutorial();
        containerDoors.SetTrigger("Open Door");
    }
    IEnumerator Reloadin()
    {
        yield return new WaitForSeconds(1);
        ProgressTutorial();
    }
    void OnOpenMenu()
    {
        if (tutStage == 8)
        {
            ProgressTutorial();
        }
    }
    IEnumerator EndTutorial()
    {
        showWave.SetActive(true);
        StartCoroutine(waveController.StartWave());
        yield return new WaitForSeconds(5f);
        tutorialImages[12].SetActive(false);
        this.enabled = false;
    }
    IEnumerator TutWave()
    {
        for (int i = 0; i < exampleWave.Length; i++)
        {
            GameObject spawnedEnemy = Instantiate(exampleWave[i].gameObject, waveManager.spawnLocation.position + transform.up * exampleWave[i].GetComponent<EnemyPathfinding>().height, Quaternion.identity);
            spawnedEnemy.GetComponent<EnemyBehaviour>().playerGold = playerControll;
            spawnedEnemy.GetComponent<EnemyPathfinding>().FindPath(waveManager.pathWaypoints, waveManager.spawnDeviation);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
