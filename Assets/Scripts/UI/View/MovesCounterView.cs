using TMPro;
using UnityEngine;

namespace CardMatchingGame.UI.View
{
    public class MovesCounterView : GameUIBase
    {
        [SerializeField] private TMP_Text _counter;

        private int _initialValue = 0;

        private void OnEnable()
        {
            _counter.SetText(_initialValue.ToString());
        }

        public void UpdateMovesCounter(int moves)
        {
            if (!gameObject.activeInHierarchy) MenuToggle(true);
            _counter.SetText("Moves: " + moves);
        }
    }
}
