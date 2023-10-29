using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CardMatchingGame.UI.View
{
    public class LevelRequestView : GameUIBase
    {
        public delegate void LevelRequestViewStateChangedHandler(int turnAmount);
        public event LevelRequestViewStateChangedHandler LevelRequestViewStateChanged;

        [SerializeField] private TMP_Text _levelRequestUI;

        /*private void Start()
        {
            LevelRequestViewStateChanged?.Invoke(0);
        }*/

        /*protected override void Start()
        {
            base.OnLevelStateChanged(turnsAmount);
            
        }*/

        private void Start()
        {
            LevelRequest(turnsAmount);

        }

        public void LevelRequest(int value)
        {
            MenuToggle(true);
            _levelRequestUI.SetText("This level must be completed in less than: " + value.ToString()+" turns");
        }
    }
}
