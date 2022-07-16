using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
