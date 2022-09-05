using Scenes;
using TimeControl;
using UI.Views.Interfaces;
using UnityEngine;

namespace UI.Presenters
{
    public class PausePresenter : MonoBehaviour
    {
        [SerializeField] private GameObject _optionPanel;
        [SerializeField] private GameObject _pausePanel;
        
        private IPauseView _pauseView;
        private IMenuLoader _menuLoader;
        private IResumeTime _resumeTime;

        public void Init(IPauseView pauseView, IMenuLoader menuLoader, IResumeTime resumeTime)
        {
            _pauseView = pauseView;
            _menuLoader = menuLoader;
            _resumeTime = resumeTime;
        }

        public void Enable()
        {
            _pauseView.OnResumeButtonClicked += Resume;
            _pauseView.OnOptionButtonClicked += OpenOption;
            _pauseView.OnExitButtonClicked += Exit;
        }

        public void Disable()
        {
            _pauseView.OnResumeButtonClicked -= Resume;
            _pauseView.OnOptionButtonClicked -= OpenOption;
            _pauseView.OnExitButtonClicked -= Exit;
        }

        private void Resume()
        {
            _pausePanel.SetActive(false);
            _resumeTime.Resume();
        }

        private void OpenOption()
        {
            _optionPanel.SetActive(true);
        }
        
        private void Exit()
        {
            _menuLoader.LoadMenuScene();
            _resumeTime.Resume();
        }
    }
}