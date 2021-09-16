using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonsconfirm : MonoBehaviour
{
    public GameObject conf;
    public GameObject shop;
  
    public void Yes()
    {
        conf.SetActive(false);
        shop.SetActive(false);
      
    }

    
    public void No()
    {
        conf.SetActive(false);
 

    }


}
