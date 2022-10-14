using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMethod : MonoBehaviour
{
    public void ButtonMethod(int num)
    {
        switch(num)
        {
            case 0:
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Time.timeScale = 1;
                break;
            case 1:
                Application.Quit();
                break;
            default:
                break;
        }
    }
}

