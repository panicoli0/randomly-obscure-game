using CardMatchingGame.Presentation.Systems;
using CardMatchingGame.UI;
using CardMatchingGame.UI.View;
using System.Collections.Generic;
using UnityEngine;

namespace CardMatchingGame.Presentation
{
    public class MatchChecker : MonoBehaviour, IMatchGetter
    {
        public int WinLevelCont { get => winLevelCont; set => winLevelCont = value; }

        [SerializeField] private ScoreSystem _scoreSystem;
        [SerializeField] private CardsListener _cardListener;
        [SerializeField] private AudioSource _audioSource;

        private int winLevelCont = 0;

        public void CheckMatch(List<CardView> cards)
        {
            foreach (CardView card in cards)
            {
                if (card.CurrentState == CardView.State.Matched && card.isActiveAndEnabled)
                {
                    card.Matched();
                    _scoreSystem.AddScore(card.point);
                    winLevelCont++;
                }
            }
            // Check win
            int size;
            size = PlayerPrefs.GetInt("GridSize");
            if (winLevelCont >= size)
            {
                Debug.Log("You win the level!");
                _audioSource.PlayOneShot(_audioSource.clip);
                UISceneReferenceHolder.EndLevelMenu.MenuToggle(true);
                CleanUpSecuence();
            }
        }

        public void CleanUpSecuence()
        {
            _cardListener.Moves = 0;
            PresentationSceneReferenceHolder.GridHandlerPresentation.CleanGrid();
        }
    }
}
