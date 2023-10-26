using UnityEngine;
using UnityEngine.UI;

public class EndLevelMenu : MonoBehaviour
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

    internal void MenuToggle(bool display) => gameObject.SetActive(display);

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
