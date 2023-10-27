using System;
using TMPro;
using UnityEngine;

namespace CardMatchingGame.UI
{
    public class GameUIBase : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreUI;
        [SerializeField] private ScoreSystemSO _scoreSystemSO;

        internal void MenuToggle(bool display) => gameObject.SetActive(display);

        private void Start()
        {
            ChangeScoreValue(_scoreSystemSO.score);
        }

        private void OnEnable()
        {
            _scoreSystemSO.scoreChangeEvent.AddListener(ChangeScoreValue);
        }

        private void OnDisable()
        {
            _scoreSystemSO.scoreChangeEvent.RemoveListener(ChangeScoreValue);

        }

        private void ChangeScoreValue(int amount)
        {
            _scoreUI.SetText(amount.ToString());
        }
    }
}