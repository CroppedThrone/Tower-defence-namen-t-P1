using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class LevelSel : MonoBehaviour
{
    public ProgressTracker tracker;
    public Text level2;

    void OnDevKey()
    {
        if (tracker.levelsUnlocked == 0)
        {
            tracker.levelsUnlocked++;
            level2.text = "LEVEL 2";
        }
    }

    private void Start()
    {
        if (tracker.levelsUnlocked < 1)
        {
            level2.text = "LOCKED";
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
