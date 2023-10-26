using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSelectionMenu : MonoBehaviour
{
    [SerializeField] private Button _2x2Button;
    [SerializeField] private Button _2x3Button;
    [SerializeField] private Button _5x6Button;
    [SerializeField] private Button _backButton;

    //[SerializeField] private MainMenu _mainMenu;
    [SerializeField] private GridHandler _gridHandler;

    private int _2x2LayoutAmount = 4;
    private int _2x3LayoutAmount = 6;
    private int _5x6LayoutAmount = 30;

    private void Awake()
    {
        _2x2Button.onClick.AddListener(TwoByTwoButtonClicked);
        _2x3Button.onClick.AddListener(ThreeByTwoButtonClicked);
        _5x6Button.onClick.AddListener(FiveBySixButtonClicked);
        _backButton.onClick.AddListener(BackButtonClicked);
        
    }

    private void BackButtonClicked()
    {
        MenuToggle(false);
        _gridHandler.GridToggle(false);
        //_mainMenu.MenuToggle(true);
    }

    public void MenuToggle(bool show)
    {
        gameObject.SetActive(show);
    }

    private void TwoByTwoButtonClicked()
    {
        // create a 4 cards layout
        //_gridHandler.CreateGrid(_2x2LayoutAmount);
        _gridHandler.SetGrid(_2x2LayoutAmount);
        MenuToggle(false);
    }

    private void ThreeByTwoButtonClicked()
    {
        // create a 6 cards layout
        //_gridHandler.CreateGrid(_2x3LayoutAmount);
        _gridHandler.SetGrid(_2x3LayoutAmount);
        MenuToggle(false);
    }

    private void FiveBySixButtonClicked()
    {
        // create a 30 cards layout
        //_gridHandler.CreateGrid(_5x6LayoutAmount);
        _gridHandler.SetGrid(_5x6LayoutAmount);
        MenuToggle(false);
    }
}
