using CardMatchingGame.Model.DataPersistance;
using CardMatchingGame.Presentation;
using UnityEngine;
using UnityEngine.UI;

namespace CardMatchingGame.UI.View
{
    public class MainMenuView : GameUIBase
    {
        //[SerializeField] private GridHandler _gridHandler;
        [SerializeField] private Button _newGame;
        [SerializeField] private Button _continue;
        [SerializeField] private Button _quit;

        public void Init()
        {
            _newGame.onClick.AddListener(NewGameClicked);
            _continue.onClick.AddListener(ContinueClicked);
            _quit.onClick.AddListener(QuitClicked);
        }

        private void QuitClicked() => Debug.Log("Implement QuitClicked");

        private void ContinueClicked()
        {
            UISceneReferenceHolder.GridSelectionMenuView.MenuToggle(false);
            MenuToggle(false);
            UISceneReferenceHolder.GridHandlerView.MenuToggle(true);
            DataPersistenceManager.instance.FakeOnSceneLoaded(true);
        }

        private void NewGameClicked()
        {
            DataPersistenceManager.instance.NewGame();
            UISceneReferenceHolder.GridSelectionMenuView.MenuToggle(true);
            MenuToggle(false);
        }
    }
}
