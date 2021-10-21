using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSel : MonoBehaviour
{
    public void ButtonLevel1()
    {
        SceneManager.LoadScene(2);
    }
    public void ButtonLevel2()
    {
        SceneManager.LoadScene(3);
    }
}
