using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuClickHandler : MonoBehaviour
{
    public void OnButtonClickStart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void OnButtonClickExit()
    {
        Application.Quit();
    }
}
