using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Buttonsconfirm : MonoBehaviour
{
    public GameObject conf;
    public Shop shop;
    public EventSystem evt;
    public GameObject noo;
    public GameObject sshop;
    public bool myFunctionCalled = false;
    public bool myFunctionCalled1 = false;
    public bool myFunctionCalled2 = false;
    public GameObject player;
    public TurretChoice choice;
    public GameObject supplyBeacon;
    public int toPay;
    public GameObject turretIndicator;
    public SpawnChecker check;
    public AudioSource error;
    public AudioSource money;

    void Update()
    {
        
        if (conf == true)
        {
            if (myFunctionCalled == false)
            {
                myFunctionCalled = true;
                evt.SetSelectedGameObject(noo);
            }
            shop.enabled = false;
            
            
        }
       
        
    }

    

    public void Yes()
    {
        if (check.canSpawn==true)
        {
            GameObject spawnedBeacon = Instantiate(supplyBeacon, player.transform.position + player.transform.forward * 2.5f, Quaternion.identity);
            spawnedBeacon.GetComponent<DropTurret>().turretChoice = choice;
            player.GetComponent<PlayerControll>().GetMoney(-toPay);
        
            conf.SetActive(false);
        
            shop.enabled = true;
            money.Play();

        }
        else
        {
            conf.SetActive(false);
            error.Play();
        }

        
        turretIndicator.SetActive(false);
        if (myFunctionCalled1 == false)
        {
            myFunctionCalled = true;
            evt.SetSelectedGameObject(sshop);
        }
        myFunctionCalled = false;
    }

    
    public void No()
    {
        conf.SetActive(false);
        shop.enabled = true;
        turretIndicator.SetActive(false);
        if (myFunctionCalled2 == false)
        {
            myFunctionCalled = true;
            evt.SetSelectedGameObject(sshop);
        }
        myFunctionCalled = false;
    }


}
