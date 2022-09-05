using TimeControl;
using UI.Views.Interfaces;
using UnityEngine;

namespace UI.Presenters
{
    public class StopPresenter : MonoBehaviour
    {
        [SerializeField] private GameObject _pausePanel;
        
        private IStopView _stopView;
        private IStopTime _stopTime;

        public void Init(IStopView stopView, IStopTime stopTime)
        {
            _stopView = stopView;
            _stopTime = stopTime;
        }

        public void Enable()
        {
            _stopView.OnStopButtonClicked += Stop;
        }

        public void Disable()
        {
            _stopView.OnStopButtonClicked -= Stop;
        }

        private void Stop()
        {
            Debug.Log("Click");
            _pausePanel.SetActive(true);
            _stopTime.Stop();
        }
    }
}