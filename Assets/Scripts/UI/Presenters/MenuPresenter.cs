using Scenes;
using UI.Views.Interfaces;
using UnityEngine;

namespace UI.Presenters
{
    public class MenuPresenter : MonoBehaviour
    {
        [SerializeField] private GameObject _optionPanel;
        
        private IMenuView _menuView;
        private IGameLoader _gameLoader;

        public void Init(IMenuView menuView, IGameLoader gameLoader)
        {
            _menuView = menuView;
            _gameLoader = gameLoader;
        }

        public void Enable()
        {
            _menuView.OnOptionButtonClicked += OpenOptions;
            _menuView.OnPlayButtonClicked += LoadGame;
            _menuView.OnExitButtonClicked += Exit;
        }

        public void Disable()
        {
            _menuView.OnOptionButtonClicked -= OpenOptions;
            _menuView.OnPlayButtonClicked -= LoadGame;
            _menuView.OnExitButtonClicked -= Exit;
        }

        private void OpenOptions()
        {
            _optionPanel.SetActive(true);
        }

        private void LoadGame()
        {
            _gameLoader.LoadGameScene();
        }

        private void Exit()
        {
            Application.Quit();
        }
    }
}