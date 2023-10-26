using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GridSelectionMenu _gridSelectionMenu;
    [SerializeField] private GridHandler _gridHandler;
    [SerializeField] private Button _newGame;
    [SerializeField] private Button _continue;
    [SerializeField] private Button _loadGame;
    [SerializeField] private Button _quit;

    private void Awake()
    {
        _newGame.onClick.AddListener(NewGameClicked);
        _continue.onClick.AddListener(ContinueClicked);
        _loadGame.onClick.AddListener(LoadGameClicked);
        _quit.onClick.AddListener(QuitClicked);
    }

    private void QuitClicked() => Debug.Log("Implement QuitClicked");

    private void LoadGameClicked() => DataPersistenceManager.instance.LoadGame();

    private void ContinueClicked()
    {
        _gridSelectionMenu.MenuToggle(false);
        MenuToggle(false);
        _gridHandler.gameObject.SetActive(true);
        DataPersistenceManager.instance.FakeOnSceneLoaded(true);
    }

    private void NewGameClicked()
    {
        DataPersistenceManager.instance.NewGame();
        _gridSelectionMenu.MenuToggle(true);
        MenuToggle(false);
    }

    internal void MenuToggle(bool display) => gameObject.SetActive(display);
}
