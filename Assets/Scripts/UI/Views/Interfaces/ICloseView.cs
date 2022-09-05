using System;

namespace UI.Views.Interfaces
{
    public interface ICloseView
    {
        public event Action OnCloseButtonClicked;
    }
}