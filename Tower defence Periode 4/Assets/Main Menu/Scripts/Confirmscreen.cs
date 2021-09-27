using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confirmscreen : MonoBehaviour
{
    public GameObject conff;
    public GameObject player;
    public int cost;
    public TurretChoice choice;
    public void conf()
    {
        if (player.GetComponent<PlayerControll>().gold < cost)
        {
            print("not enough moneys");
        }
        else
        {
            print("you've got moneys");
            conff.GetComponent<Buttonsconfirm>().choice = choice;
            conff.GetComponent<Buttonsconfirm>().toPay = cost;
            conff.SetActive(true);
        }
    }


}
