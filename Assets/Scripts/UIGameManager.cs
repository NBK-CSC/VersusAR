using System;
using Scenes;
using TimeControl;
using UI.Presenters;
using UI.Views;
using UnityEngine;

public class UIGameManager :MonoBehaviour
{
    [Header("Views")]
    [SerializeField] private PauseView _pauseView;
    [SerializeField] private OptionView _optionView;
    [SerializeField] private StopView _stopView;
    [Header("Presenters")]
    [SerializeField] private PausePresenter _pausePresenter;
    [SerializeField] private OptionPresenter _optionPresenter;
    [SerializeField] private StopPresenter _stopPresenter;

    private ScenesLoader _scenesLoader;
    private TimeController _timeController;
    
    private void Awake()
    {
        _scenesLoader = new ScenesLoader();
        _timeController = new TimeController();
        _stopPresenter.Init(_stopView,_timeController);
        _pausePresenter.Init(_pauseView, _scenesLoader,_timeController);
        _optionPresenter.Init(_optionView);
    }

    private void OnEnable()
    {
        _stopPresenter.Enable();
        _pausePresenter.Enable();
        _optionPresenter.Enable();
    }

    private void OnDisable()
    {
        _stopPresenter.Disable();
        _pausePresenter.Disable();
        _optionPresenter.Disable();
    }
}
