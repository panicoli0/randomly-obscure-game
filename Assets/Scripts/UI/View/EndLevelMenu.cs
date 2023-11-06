using CardMatchingGame.Model.DataPersistance;
using CardMatchingGame.Presentation;
using UnityEngine;
using UnityEngine.UI;

namespace CardMatchingGame.UI.View
{
    internal class EndLevelMenu : GameUIBase
    {
        [SerializeField] private Button _restart;
        [SerializeField] private Button _newGame;

        //[SerializeField] private GridSelectionMenuView _gridSelectionMenu;
        //[SerializeField] private GridHandlerView _gridHandler;
        [SerializeField] private CardsListener _cardListener;
        [SerializeField] private LevelRequestView _levelRequestView;
        [SerializeField] private GameOverView _gameOverView;
        [SerializeField] private MovesCounterView _movesCounterView;

        private void Awake()
        {
            _restart.onClick.AddListener(RestartButton);
            _newGame.onClick.AddListener(NewGameButton);

        }

        private void OnDisable()
        {
            _levelRequestView.MenuToggle(false);
            _movesCounterView.MenuToggle(false);
        }

        private void NewGameButton()
        {
            MenuToggle(false);
            _gameOverView.MenuToggle(false);
            //PresentationSceneReferenceHolder.GridHandlerPresentation.Init();

            UISceneReferenceHolder.GridSelectionMenuView.MenuToggle(true);
        }

        private void RestartButton()
        {
            DataPersistenceManager.instance.NewGame();
            //PresentationSceneReferenceHolder.GridHandlerPresentation.CleanGrid();
            
            MenuToggle(false);
            _gameOverView.MenuToggle(false);
            _levelRequestView.MenuToggle(true);

            PresentationSceneReferenceHolder.GridHandlerPresentation.Init();
        }
    }
}
