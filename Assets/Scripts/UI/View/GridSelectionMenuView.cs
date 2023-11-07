using CardMatchingGame.Model;
using CardMatchingGame.Presentation;
using UnityEngine;
using UnityEngine.UI;

namespace CardMatchingGame.UI.View
{
    public class GridSelectionMenuView : GameUIBase
    {
        [SerializeField] private Button _2x2Button;
        [SerializeField] private Button _2x3Button;
        [SerializeField] private Button _5x6Button;
        [SerializeField] private Button _backButton;
        [SerializeField] private GridHandlerView _gridHandler;
        //[SerializeField] private LevelRequestView _levelRequestView;

        private int _2x2LayoutAmount = 4;
        private int _2x3LayoutAmount = 6;
        private int _5x6LayoutAmount = 30;

        /*private void Awake()
        {
            _2x2Button.onClick.AddListener(TwoByTwoButtonClicked);
            _2x3Button.onClick.AddListener(ThreeByTwoButtonClicked);
            _5x6Button.onClick.AddListener(FiveBySixButtonClicked);
            _backButton.onClick.AddListener(BackButtonClicked);
        }*/

        internal void Init()
        {
            _2x2Button.onClick.AddListener(TwoByTwoButtonClicked);
            _2x3Button.onClick.AddListener(ThreeByTwoButtonClicked);
            _5x6Button.onClick.AddListener(FiveBySixButtonClicked);
            _backButton.onClick.AddListener(BackButtonClicked);
        }

        private void BackButtonClicked()
        {
            MenuToggle(false);
            UISceneReferenceHolder.GridHandlerView.MenuToggle(false);
            UISceneReferenceHolder.MainMenuView.MenuToggle(true);
        }

        private void TwoByTwoButtonClicked()
        {
            // create a 4 cards layout
            PresentationSceneReferenceHolder.GridHandlerPresentation.SetGrid(_2x2LayoutAmount);
            GameRules.Rule = _2x2LayoutAmount;
            UISceneReferenceHolder.LevelRequestView.MenuToggle(true);
            MenuToggle(false);
        }

        private void ThreeByTwoButtonClicked()
        {
            // create a 6 cards layout
            PresentationSceneReferenceHolder.GridHandlerPresentation.SetGrid(_2x3LayoutAmount);
            GameRules.Rule = _2x3LayoutAmount;
            UISceneReferenceHolder.LevelRequestView.MenuToggle(true);
            MenuToggle(false);
        }

        private void FiveBySixButtonClicked()
        {
            // create a 30 cards layout
            PresentationSceneReferenceHolder.GridHandlerPresentation.SetGrid(_5x6LayoutAmount);
            GameRules.Rule = _5x6LayoutAmount;
            UISceneReferenceHolder.LevelRequestView.MenuToggle(true);
            MenuToggle(false);
        }
    }
}
