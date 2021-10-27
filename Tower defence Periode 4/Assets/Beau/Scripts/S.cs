using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class S : MonoBehaviour
{
    public Text money;
    public Text kills;
    public Text bought;
    public Text waves;

    public ProgressTracker Tracker;
    // Start is called before the first frame update
    void Start()
    {
        money.text = Tracker.goldEarned.ToString();
        kills.text = Tracker.enemiesKilled.ToString();
        bought.text = Tracker.turretsBought.ToString();
        waves.text = Tracker.wavesSurvived.ToString();

    }


}
