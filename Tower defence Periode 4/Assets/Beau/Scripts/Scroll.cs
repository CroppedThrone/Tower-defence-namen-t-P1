using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class Scroll : MonoBehaviour
{
    RectTransform scrollRectTransform;
    RectTransform contentPanel;
    RectTransform selectedRectTransform;
    GameObject lastSelected;

    void Start()
    {
        scrollRectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (EventSystem.current)
        {
            //just incase content panel gets created in start.
            if (contentPanel == null) contentPanel = GetComponent<ScrollRect>().content;

            GameObject selected = EventSystem.current.currentSelectedGameObject;

            if (selected == null)
            {
                return;
            }
            if (selected.transform.parent != contentPanel.transform)
            {
                return;
            }
            if (selected == lastSelected)
            {
                return;
            }

            selectedRectTransform = selected.GetComponent<RectTransform>();
            contentPanel.anchoredPosition = new Vector2(contentPanel.anchoredPosition.x, -(selectedRectTransform.localPosition.y) - (selectedRectTransform.rect.height / 2));

            lastSelected = selected;
        }
       
    }
}