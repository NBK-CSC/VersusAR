using System;
using UI.Views.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class PauseView : MonoBehaviour, IPauseView
    {
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _optionsButton;
        [SerializeField] private Button _exitButton;

        public event Action OnResumeButtonClicked; 
        public event Action OnOptionButtonClicked; 
        public event Action OnExitButtonClicked; 

        private void OnEnable()
        {
            _resumeButton.onClick.AddListener(ClickResume);
            _optionsButton.onClick.AddListener(ClickOptions);
            _exitButton.onClick.AddListener(ClickExit);
        }

        private void OnDisable()
        {
            _resumeButton.onClick.RemoveListener(ClickResume);
            _optionsButton.onClick.RemoveListener(ClickOptions);
            _exitButton.onClick.RemoveListener(ClickExit);
        }

        private void ClickResume()
        {   
            OnResumeButtonClicked?.Invoke();
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
