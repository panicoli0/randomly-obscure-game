using CardMatchingGame.Presentation;
using CardMatchingGame.UI.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardMatchingGame.UI
{
    public class UISceneReferenceHolder : MonoBehaviour
    {
        internal static MainMenuView MainMenuView;
        internal static GridSelectionMenuView GridSelectionMenuView;
        internal static GridHandlerView GridHandlerView;
        internal static MovesCounterView MovesCounterView;
        [SerializeField] private MainMenuView _mainMenuView;
        [SerializeField] private GridSelectionMenuView _gridSelectionMenuView;
        [SerializeField] private GridHandlerView _gridHandlerView;

        [SerializeField] private LevelRequestView _levelRequestView;
        [SerializeField] private MovesCounterView _movesCounterView;

        private void Awake()
        {
            MainMenuView = _mainMenuView;
            GridSelectionMenuView = _gridSelectionMenuView;
            GridHandlerView = _gridHandlerView;
            MovesCounterView = _movesCounterView;
        }
    }
}
