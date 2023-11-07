using CardMatchingGame.UI;

public class UIManager : GameUIBase
{
    private void Start()
    {
        UISceneReferenceHolder.MainMenuView.Init();
        UISceneReferenceHolder.GridSelectionMenuView.Init();
    }
}
