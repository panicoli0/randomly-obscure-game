using CardMatchingGame.UI.View;
using System.Collections.Generic;
using UnityEngine;

namespace CardMatchingGame.Presentation.Systems
{
    public class MatchingCardsSystem : MonoBehaviour
    {
        //public int WinLevelCont { get => winLevelCont; set => winLevelCont = value; }

        //[SerializeField] private ScoreSystem _scoreSystem;
        //[SerializeField] private EndLevelMenu _endLevelMenu;
        //[SerializeField] private CardsListener _cardListener;
        //[SerializeField] private GridHandler _gridHandler;

        /*[SerializeField] private AudioSource _audioSource;

        private int winLevelCont = 0;*/

        private IMatchGetter matchGetter = null;

        /*private void Start()
        {
            matchGetter = GetComponent<IMatchGetter>();

            if (matchGetter == null) { return; }

            *//*var targets = matchGetter.GetTargets(transform);

            foreach (Transform target in targets)
            {
                Debug.Log(target.name);
            }*//*
        }*/

        internal void AddMatchedCards(CardView firstCard, CardView secondCard)
        {
            matchGetter = GetComponent<IMatchGetter>();

            if (matchGetter == null) { return; }

            var matchedCards = new List<CardView>
            {
                firstCard,
                secondCard
            };
            matchGetter.CheckMatch(matchedCards);
            //var cardsMatched = matchGetter.CheckMatch(matchedCards);

        }

        /*internal void CheckMatch(List<CardView> cards)
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
                _endLevelMenu.MenuToggle(true);
                CleanUpSecuence();
            }
        }*/

        
    }
}