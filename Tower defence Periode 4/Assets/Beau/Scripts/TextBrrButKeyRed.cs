using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextBrrButKeyRed : MonoBehaviour, ISelectHandler, IDeselectHandler

{

    public Text theText;

    
 
     void ISelectHandler.OnSelect(BaseEventData eventData)
    {
        theText.color = new Color32(228, 31, 23, 255);
    }

    void IDeselectHandler.OnDeselect(BaseEventData eventData)
    {
        theText.color = new Color32(115,42,14,255);
    }
    

}











