using System;
using Scenes;
using UI.Presenters;
using UI.Views;
using UnityEngine;

public class UIMenuManager:MonoBehaviour
{
    [Header("Views")]
    [SerializeField] private MenuView _menuView;
    [SerializeField] private OptionView _optionView;
    [Header("Presenters")]
    [SerializeField] private MenuPresenter _menuPresenter;
    [SerializeField] private OptionPresenter _optionPresenter;

    private ScenesLoader _scenesLoader;
    
    private void Awake()
    {
        _scenesLoader = new ScenesLoader();
        _menuPresenter.Init(_menuView, _scenesLoader);
        _optionPresenter.Init(_optionView);
    }
    
    private void OnEnable()
    {
        _menuPresenter.Enable();
        _optionPresenter.Enable();
    }

    private void OnDisable()
    {
        _menuPresenter.Disable();
        _optionPresenter.Disable();
    }
}
