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
    public Dropdown shop;
    public GameObject currentSelected;

    
    void Update()
    {


        currentSelected = EventSystem.current.currentSelectedGameObject;
        if(currentSelected.name == "Item 1: Starter Turret")
        {
                starter.SetActive(true);
        }
        else
        {
            starter.SetActive(false);
        }

        if (currentSelected.name == "Item 2: Elite Turret")
        {
            elite.SetActive(true);
        }
        else
        {
            elite.SetActive(false);
        }
        
        if (currentSelected.name == "Item 3: Sniper Turret")
        {
            sniper.SetActive(true);
        }
        else
        {
            sniper.SetActive(false);
        }


    }



    
        
        
      
        

    
    
         
    




}
