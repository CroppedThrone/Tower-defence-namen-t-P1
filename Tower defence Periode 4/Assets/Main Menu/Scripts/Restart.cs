using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Restart : MonoBehaviour
{
 

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        
    }
    public void ButtonRestart()
    {
        SceneManager.LoadScene(1);
        
    }
}
