using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuClickHandler : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuPanel;

    private bool _panelActive = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _panelActive == false)
        {
            OpenPanel();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && _panelActive == true)
        {
            ClosePanel();
        }
    }

    public void OnButtonClickResume()
    {
        ClosePanel();
    }

    public void OnButtonClickQuit()
    {
        Application.Quit();
    }

    private void OpenPanel()
    {
        Time.timeScale = 0;
        _panelActive = true;
        _pauseMenuPanel.SetActive(_panelActive);
    }

    private void ClosePanel()
    {
        _panelActive = false;
        _pauseMenuPanel.SetActive(_panelActive);
        Time.timeScale = 1;
    }
}
