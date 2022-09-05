using UI.Views.Interfaces;
using UnityEngine;

namespace UI.Presenters
{
    public class OptionPresenter : MonoBehaviour
    {
        [SerializeField] private GameObject _optionPanel;
        
        private ICloseView _closeView;

        public void Init(ICloseView closeView)
        {
            _closeView = closeView;
        }

        public void Enable()
        {
            _closeView.OnCloseButtonClicked += CloseOptions;
        }

        public void Disable()
        {
            _closeView.OnCloseButtonClicked -= CloseOptions;
        }

        private void CloseOptions()
        {
            _optionPanel.SetActive(false);
        }
    }
}