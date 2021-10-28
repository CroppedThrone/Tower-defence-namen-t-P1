using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextBrr : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Text theText;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        theText.color = Color.white;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        theText.color = new Color32(173, 173, 173, 255);
    }


}









