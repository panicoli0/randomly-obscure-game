using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CardMatchingGame.UI.View
{
    public class GridSelectionMenu : GameUIBase
    {
        [SerializeField] private Button _2x2Button;
        [SerializeField] private Button _2x3Button;
        [SerializeField] private Button _5x6Button;
        [SerializeField] private Button _backButton;
        [SerializeField] private GridHandler _gridHandler;
        [SerializeField] private LevelRequestView _levelRequestView;

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
        }

        
        private void TwoByTwoButtonClicked()
        {
            // create a 4 cards layout
            _gridHandler.SetGrid(_2x2LayoutAmount);
            //_levelRequestView.LevelRequest(_2x2LayoutAmount);
            //potencial solucion:
            SetTurnsAmount(_2x2LayoutAmount);
            MenuToggle(false);
        }

        private void ThreeByTwoButtonClicked()
        {
            // create a 6 cards layout
            _gridHandler.SetGrid(_2x3LayoutAmount);
            MenuToggle(false);
        }

        private void FiveBySixButtonClicked()
        {
            // create a 30 cards layout
            _gridHandler.SetGrid(_5x6LayoutAmount);
            MenuToggle(false);
        }
    }
}
