using CardMatchingGame.UI.View;
using UnityEngine;

namespace CardMatchingGame.UI
{
    public class UISceneReferenceHolder : MonoBehaviour
    {
        internal static MainMenuView MainMenuView;
        internal static GridSelectionMenuView GridSelectionMenuView;
        internal static GridHandlerView GridHandlerView;
        internal static MovesCounterView MovesCounterView;
        internal static LevelRequestView LevelRequestView;
        internal static GameOverView GameOverView;
        internal static EndLevelMenuView EndLevelMenu;

        [SerializeField] private MainMenuView _mainMenuView;
        [SerializeField] private GridSelectionMenuView _gridSelectionMenuView;
        [SerializeField] private GridHandlerView _gridHandlerView;
        [SerializeField] private MovesCounterView _movesCounterView;
        [SerializeField] private LevelRequestView _levelRequestView;
        [SerializeField] private GameOverView _gameOverView;
        [SerializeField] private EndLevelMenuView _endLevelMenu;
        

        private void Awake()
        {
            MainMenuView = _mainMenuView;
            GridSelectionMenuView = _gridSelectionMenuView;
            GridHandlerView = _gridHandlerView;
            MovesCounterView = _movesCounterView;
            LevelRequestView = _levelRequestView;
            GameOverView = _gameOverView;
            EndLevelMenu = _endLevelMenu;
        }
    }
}
