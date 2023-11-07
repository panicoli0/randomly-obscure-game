using CardMatchingGame.UI.View;
using System.Collections.Generic;
using UnityEngine;

namespace CardMatchingGame.Presentation.Systems
{
    public class MatchingCardsSystem : MonoBehaviour
    {
        private IMatchGetter matchGetter = null;

        internal void AddMatchedCards(CardView firstCard, CardView secondCard)
        {
            if (!TryGetComponent(out matchGetter)) { return; }

            var matchedCards = new List<CardView>
            {
                firstCard,
                secondCard
            };
            matchGetter.CheckMatch(matchedCards);
        }
    }
}