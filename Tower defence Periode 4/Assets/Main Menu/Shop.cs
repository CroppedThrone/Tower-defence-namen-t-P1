using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Shop : MonoBehaviour
{
    public GameObject starter;
    public GameObject elite;
    public GameObject sniper;
    public GameObject missle;
    public GameObject machine;
    public GameObject drop;
    public int lastPressed = 0;
    GameObject currentSelected;

    public void Drop()
    {
        lastPressed++;
        if (lastPressed == 1)
        {
            drop.SetActive(true);
        }
        else
        {
            lastPressed = 0;
            drop.SetActive(false);
        }
    }

    void Update()
    {
        currentSelected = EventSystem.current.currentSelectedGameObject;

        if (currentSelected.name == "Starter Turret")
        {
            starter.SetActive(true);
        }
        else
        {
            starter.SetActive(false);
        }
        if (currentSelected.name == "Elite Turret")
        {
            elite.SetActive(true);
        }
        else
        {
            elite.SetActive(false);
        }
        if (currentSelected.name == "Machine Gun Turret")
        {
            machine.SetActive(true);
        }
        else
        {
           machine.SetActive(false);
        }
        
    }











}
 
