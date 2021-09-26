using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenScreen : MonoBehaviour
{
    public GameObject canvas;
    bool menuActive;
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        menuActive = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnOpenMenu()
    {
        if (menuActive == false)
        {
            canvas.SetActive(true);
            menuActive = true;
        }
        else
        {
            canvas.SetActive(false);
            menuActive = false;
        }
 
    }
}
