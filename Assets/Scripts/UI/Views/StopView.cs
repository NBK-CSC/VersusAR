using System;
using UI.Views.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class StopView : MonoBehaviour, IStopView
    {
        [SerializeField] private Button _stopButton;
        
        public event Action OnStopButtonClicked;

        private void OnEnable()
        {
            _stopButton.onClick.AddListener(ClickClose);
        }

        private void OnDisable()
        {
            _stopButton.onClick.RemoveListener(ClickClose);
        }

        private void ClickClose()
        {   
            OnStopButtonClicked?.Invoke();
        }

    }
}