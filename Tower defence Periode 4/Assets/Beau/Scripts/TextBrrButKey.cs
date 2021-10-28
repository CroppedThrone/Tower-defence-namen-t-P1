using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextBrrButKey : MonoBehaviour, ISelectHandler, IDeselectHandler

{

    public Text theText;

    
 
     void ISelectHandler.OnSelect(BaseEventData eventData)
    {
        theText.color = Color.white;
    }

    void IDeselectHandler.OnDeselect(BaseEventData eventData)
    {
        theText.color = new Color32(173, 173, 173, 255);
    }
    

}











