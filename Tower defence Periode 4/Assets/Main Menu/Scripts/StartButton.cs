using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
    }
    public void ButtonStart()
    {
        SceneManager.LoadScene(1);
    }
}
