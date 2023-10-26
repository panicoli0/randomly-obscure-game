using System;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    private void QuitClicked()
    {
        throw new NotImplementedException();
    }

    private void LoadGameClicked()
    {
        DataPersistenceManager.instance.LoadGame();
        // va a tener que abrir otro menu mas
    }

    private void ContinueClicked()
    {
        //cargar la data del ultimo estado
        //DisableMenuButtons();
        // save the game anytime before loading a new scene
        _gridSelectionMenu.MenuToggle(false);
        MenuToggle(false);
        _gridHandler.gameObject.SetActive(true);
        // CARGAR EL GAME LAYOUT
        DataPersistenceManager.instance.FakeOnSceneLoaded(true);
        //DataPersistenceManager.instance.SaveGame();
        // load the next scene - which will in turn load the game because of 
        // OnSceneLoaded() in the DataPersistenceManager
        //SceneManager.LoadSceneAsync("main");

    }

    private void NewGameClicked()
    {
        // comenzar un new game
        DataPersistenceManager.instance.NewGame();
        _gridSelectionMenu.MenuToggle(true);
        MenuToggle(false);
        
        //SceneManager.LoadSceneAsync("main");
        //MenuToggle(false);
        //_gridSelectionMenu.MenuToggle(true);
    }

    internal void MenuToggle(bool display)
    {
        gameObject.SetActive(display);
    }
}
