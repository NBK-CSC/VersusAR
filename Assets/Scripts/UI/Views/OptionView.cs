using System;
using UI.Views.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class OptionView : MonoBehaviour, ICloseView
    {
        [SerializeField] private Button _closeButton;
        
        public event Action OnCloseButtonClicked;
        
        private void OnEnable()
        {
            _closeButton.onClick.AddListener(ClickClose);
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(ClickClose);
        }

        private void ClickClose()
        {   
            OnCloseButtonClicked?.Invoke();
        }
    }
}