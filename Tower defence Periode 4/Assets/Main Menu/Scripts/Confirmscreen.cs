using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Confirmscreen : MonoBehaviour
{
    public GameObject conff;
    public GameObject player;
    public int cost;
    public TurretChoice choice;
    public GameObject noMoney;
    
    public void conf()
    {
        if (player.GetComponent<PlayerControll>().gold < cost)
        {
            print("not enough moneys");
            noMoney.SetActive(true);
            StartCoroutine(NoMonie());
        }
        else
        {
            print("you've got moneys");
            conff.GetComponent<Buttonsconfirm>().choice = choice;
            conff.GetComponent<Buttonsconfirm>().toPay = cost;
            conff.SetActive(true);
          

        }

      

        



    }
    public IEnumerator NoMonie()
    {
        yield return new WaitForSeconds(2f);
        noMoney.SetActive(false);
 
        ;
    }
        

}
