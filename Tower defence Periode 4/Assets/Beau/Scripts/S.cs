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

    public ProgressTracker tracker;
    // Start is called before the first frame update
    void Start()
    {
        money.text = tracker.goldEarned.ToString();
        kills.text = tracker.enemiesKilled.ToString();
        bought.text = tracker.turretsBought.ToString();
        waves.text = tracker.wavesSurvived.ToString();
    }


}
