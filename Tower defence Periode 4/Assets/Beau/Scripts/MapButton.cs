using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButton : MonoBehaviour
{

    public GameObject mapCanvas;
    public int lastPressed;
    public GameObject drop;
    public GameObject setting;
    public SettingsMenu settingsMenu;
    public Shop shop;
public void ButtonMap()
    {
      
        lastPressed++;
        if (lastPressed == 1)
        {
            mapCanvas.SetActive(true);
            drop.SetActive(false);
            setting.SetActive(false);
            shop.lastPressed = 0;
            settingsMenu.lastPressed = 0;
        }
        else
        {
            lastPressed = 0;
            mapCanvas.SetActive(false);
        }
    }
}
