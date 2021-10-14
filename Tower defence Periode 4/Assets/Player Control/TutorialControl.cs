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
    bool stageDelay;
    int moveAmount;
    int dead;

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
        else if (tutStage == 3||tutStage == 5||tutStage == 7||tutStage == 9||tutStage == 10)
        {
            if (stageDelay == false)
            {
                StartCoroutine(WaitForNextStage());
                stageDelay = true;
            }
        }
        else if(tutStage == 6)
        {
            if (exampleWave[0].gameObject)
            {
                for (int i = 0; i < exampleWave.Length; i++)
                {
                    exampleWave[i].SetActive(true);
                    StartCoroutine(exampleWave[i].GetComponent<EnemyPathfinding>().StartMoving());
                    exampleWave[i].GetComponent<EnemyPathfinding>().deviation = new Vector2(1, 1);
                }
            }
            else
            {
                dead = 0;
                for (int i = 0; i < exampleWave.Length; i++)
                {
                    if (exampleWave[i] == null)
                    {
                        dead++;
                    }
                }
                if (dead == exampleWave.Length)
                {
                    ProgressTutorial();
                }
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
        if (playerControll.canAct == true)
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
    IEnumerator WaitForNextStage()
    {
        yield return new WaitForSeconds(4);
        ProgressTutorial();
        stageDelay = false;
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
}
