using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextBrrButKey : MonoBehaviour, ISelectHandler
{

    public Text theText;
    
    public void Onselect()
    {
        theText.color = Color.white;
    }
    

}









