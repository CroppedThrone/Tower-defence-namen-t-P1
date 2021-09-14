using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
   public GameObject dropdown;
    public GameObject button;

    // Update is called once per frame
    public void Dropdown()
    {
        dropdown.SetActive(true);
        button.SetActive(false);

    }
}
