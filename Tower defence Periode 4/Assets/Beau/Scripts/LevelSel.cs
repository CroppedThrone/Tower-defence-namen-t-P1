using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSel : MonoBehaviour
{
    public ProgressTracker tracker;
    public Text level2;

    private void Start()
    {
        if (tracker.levelsUnlocked < 1)
        {
            level2.text = "Locked";
        }
    }
    public void ButtonLevel1()
    {
        SceneManager.LoadScene(2);
    }
    public void ButtonLevel2()
    {
        if (tracker.levelsUnlocked > 0)
        {
            SceneManager.LoadScene(3);
        }
    }
}
