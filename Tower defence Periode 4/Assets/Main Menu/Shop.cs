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
    public int lastPressed;
    GameObject currentSelected;
    public GameObject mapCanvas;
    public GameObject setting;
    public SettingsMenu settingsMenu;
    public MapButton mapButton;
    public void Drop()
    {
        

        

        lastPressed++;
        if (lastPressed == 1)
        {
            drop.SetActive(true);
            setting.SetActive(false);
            mapCanvas.SetActive(false);
            settingsMenu.lastPressed = 0;
            mapButton.lastPressed = 0;

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
        if (lastPressed == 1)
        {
            

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
            if (currentSelected.name == "Sniper Turret")
            {
                sniper.SetActive(true);
            }
            else
            {
                sniper.SetActive(false);
            }
            if (currentSelected.name == "Missile Turret")
            {
                missle.SetActive(true);
            }
            else
            {
                missle.SetActive(false);
            }
        }
        
        

    }











}
 
