using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _panelPauseMenu;
    [SerializeField] private bool _isPause;

    public void Pause()
    {
        _panelPauseMenu.SetActive(true);
        _isPause = true;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        _panelPauseMenu.SetActive(false);
        _isPause = false;
        Time.timeScale = 1f;
    }

}
