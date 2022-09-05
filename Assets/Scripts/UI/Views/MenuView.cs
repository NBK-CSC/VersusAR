using System;
using UI.Views.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class MenuView : MonoBehaviour, IMenuView
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _optionsButton;
        [SerializeField] private Button _exitButton;

        public event Action OnPlayButtonClicked; 
        public event Action OnOptionButtonClicked; 
        public event Action OnExitButtonClicked; 

        private void OnEnable()
        {
            _playButton.onClick.AddListener(ClickPlay);
            _optionsButton.onClick.AddListener(ClickOptions);
            _exitButton.onClick.AddListener(ClickExit);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(ClickPlay);
            _optionsButton.onClick.RemoveListener(ClickOptions);
            _exitButton.onClick.RemoveListener(ClickExit);
        }

        private void ClickPlay()
        {   
            OnPlayButtonClicked?.Invoke();
        }
        
        private void ClickOptions()
        {   
            OnOptionButtonClicked?.Invoke();
        }
        
        private void ClickExit()
        {   
            OnExitButtonClicked?.Invoke();
        }
        
    }
}
