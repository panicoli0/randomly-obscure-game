using CardMatchingGame.UI;
using CardMatchingGame.UI.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : GameUIBase
{
    //[SerializeField] private MainMenuView _mainMenuView;
    //[SerializeField] private GridSelectionMenuView _gridSelectionMenuView;
    [SerializeField] private LevelRequestView _levelRequestView;
    [SerializeField] private MovesCounterView _movesCounterView;

    private void OnEnable()
    {
        UISceneReferenceHolder.MainMenuView.Init();
        UISceneReferenceHolder.GridSelectionMenuView.Init();
    }
}
