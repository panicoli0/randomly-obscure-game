using UnityEngine;
using UnityEngine.UI;

namespace CardMatchingGame.UI.View
{
    internal class EndLevelMenu : GameUIBase
    {
        [SerializeField] private Button _restart;
        [SerializeField] private Button _newGame;

        [SerializeField] private GridSelectionMenu _gridSelectionMenu;
        [SerializeField] private GridHandler _gridHandler;
        [SerializeField] private CardsListener _cardListener;

        private void Awake()
        {
            _restart.onClick.AddListener(RestartButton);
            _newGame.onClick.AddListener(NewGameButton);

        }

        private void NewGameButton()
        {
            MenuToggle(false);
            _gridSelectionMenu.MenuToggle(true);
        }

        private void RestartButton()
        {
            DataPersistenceManager.instance.NewGame();
            _gridHandler.Init();
            MenuToggle(false);
        }
    }
}
