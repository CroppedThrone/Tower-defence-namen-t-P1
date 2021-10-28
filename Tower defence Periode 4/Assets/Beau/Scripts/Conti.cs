using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Conti : MonoBehaviour
{
    public ProgressTracker tracker;

    private void Start()
    {
        if (tracker.levelsUnlocked == 0)
        {
            tracker.levelsUnlocked++;
        }
    }
    public void ButtonConti()
    {
        SceneManager.LoadScene(3);
    }
}
