using CardMatchingGame.Model;
using TMPro;
using UnityEngine;

namespace CardMatchingGame.UI.View
{
    public class LevelRequestView : GameUIBase
    {
        [SerializeField] private TMP_Text _levelRequestUI;

        private void OnEnable()
        {
            LevelRequest(GameRules.Rule);
        }

        public void LevelRequest(int value)
        {
            _levelRequestUI.SetText("This level must be completed in less than: " + value.ToString() + " moves");
        }
    }
}
