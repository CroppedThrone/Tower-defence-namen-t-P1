using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextBrrButKey : MonoBehaviour, ISelectHandler
{

    public Text theText;
    
    public void OnselectEnter(PointerEventData eventData)
    {
        theText.color = Color.white;
    }
    public void OnselectExit(PointerEventData eventData)
    {
        theText.color = new Color32(74, 74, 73, 255);
    }


}










