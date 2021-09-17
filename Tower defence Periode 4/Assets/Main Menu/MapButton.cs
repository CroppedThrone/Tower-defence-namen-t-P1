using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButton : MonoBehaviour
{

    public GameObject mapCanvas;
    public int lastPressed = 0;
public void ButtonMap()
    {
        
        lastPressed++;
        if (lastPressed == 1)
        {
            mapCanvas.SetActive(true);
        }
        else
        {
            lastPressed = 0;
            mapCanvas.SetActive(false);
        }
    }
}
