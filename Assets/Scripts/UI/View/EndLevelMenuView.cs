using CardMatchingGame.Model.DataPersistance;
using CardMatchingGame.Presentation;
using UnityEngine;
using UnityEngine.UI;

namespace CardMatchingGame.UI.View
{
    internal class EndLevelMenuView : GameUIBase
    {
        [SerializeField] private Button _restart;
        [SerializeField] private Button _newGame;

        private void Awake()
        {
            _restart.onClick.AddListener(RestartButton);
            _newGame.onClick.AddListener(NewGameButton);
        }

        private void OnDisable()
        {
            UISceneReferenceHolder.LevelRequestView.MenuToggle(false);
            UISceneReferenceHolder.MovesCounterView.MenuToggle(false);
        }

        private void NewGameButton()
        {
            MenuToggle(false);
            UISceneReferenceHolder.GameOverView.MenuToggle(false);

            UISceneReferenceHolder.GridSelectionMenuView.MenuToggle(true);
        }

        private void RestartButton()
        {
            DataPersistenceManager.instance.NewGame();
            
            MenuToggle(false);
            UISceneReferenceHolder.GameOverView.MenuToggle(false);
            UISceneReferenceHolder.LevelRequestView.MenuToggle(true);

            PresentationSceneReferenceHolder.GridHandlerPresentation.Init();
        }
    }
}
