using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Shop : MonoBehaviour
{
    public GameObject starter;
    public GameObject dakka;
    public GameObject sniper;
    public GameObject missle;
    public GameObject hacker;
    public GameObject drop;
    public int lastPressed;
    public GameObject currentSelected;
    
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

            settingsMenu.lastPressed = 0;

            

        }
        else
        {
            lastPressed = 0;
            drop.SetActive(false);
            
        }
    }

    void Update()
    {
        if (EventSystem.current)
        {
            currentSelected = EventSystem.current.currentSelectedGameObject;
            if (drop == true)
            {
                if (currentSelected.name == "Basic Turret")
                {
                    starter.SetActive(true);
                }
                else
                {
                    starter.SetActive(false);
                }
                if (currentSelected.name == "Sniper Turret")
                {
                    sniper.SetActive(true);
                }
                else
                {
                    sniper.SetActive(false);
                }
                if (currentSelected.name == "Hacker Turret")
                {
                    hacker.SetActive(true);
                }
                else
                {
                    hacker.SetActive(false);
                }
                if (currentSelected.name == "Machine Gun Turret")
                {
                    dakka.SetActive(true);
                }
                else
                {
                    dakka.SetActive(false);
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















}
 
