using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeathArowkey : MonoBehaviour
{
  
    public EventSystem evt;
    public GameObject noo;
    public GameObject ded;
    public bool myFunctionCalled;

    void Update()
    {

        if (ded == true)
        {
            if (myFunctionCalled == false)
            {
                myFunctionCalled = true;
                evt.SetSelectedGameObject(noo);
            }
          
           


        }


    }
}
