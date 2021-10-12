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
    int moveAmount;
    int dead;

    private void Start()
    {
        playerControll = GetComponent<PlayerControll>();
    }
    private void Update()
    {
        if (tutStage == 2)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 6);
            foreach (Collider collider in colliders)
            {
                if (collider.GetComponent<TurretController>())
                {
                    ProgressTutorial();
                }
            }
        }
        else if(tutStage == 4)
        {
            if (exampleWave[0].gameObject.activeInHierarchy == false)
            {
                for (int i = 0; i < exampleWave.Length; i++)
                {
                    exampleWave[i].SetActive(true);
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
        if(tutStage == 1)
        {
            if (playerControll.canGatherAmmo == true)
            {
                StartCoroutine(AmmoGathering());
            }
        }
        else if(tutStage == 3)
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
        containerDoors.SetTrigger("Open");
    }
    IEnumerator Reloadin()
    {
        yield return new WaitForSeconds(1);
        ProgressTutorial();
    }
}
