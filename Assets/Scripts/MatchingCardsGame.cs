using System.Collections.Generic;
using UnityEngine;

public class MatchingCardsGame : MonoBehaviour
{
    public int WinLevelCont { get => winLevelCont; set => winLevelCont = value; }
    public List<CardView> Cards { get => _matchedCards; set => _matchedCards = value; }

    [SerializeField] private List<CardView> _matchedCards = new();
    [SerializeField] private ScoreSystem _scoreSystem;
    [SerializeField] private EndLevelMenu _endLevelMenu;
    [SerializeField] private GridHandler _gridHandler;
    [SerializeField] private AudioSource _audioSource;

    int winLevelCont = 0;

    internal void AddMatchedCards(CardView firstCard, CardView secondCard)
    {
        var matchedCards = new List<CardView>
        {
            firstCard,
            secondCard
        };
        CheckMatch(matchedCards);
    }

    internal void CheckMatch(List<CardView> cards)
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
        int size = 0;
        size = PlayerPrefs.GetInt("GridSize");
        if (winLevelCont >= size)
        {
            Debug.Log("You win the level!");
            _audioSource.PlayOneShot(_audioSource.clip);
            _endLevelMenu.MenuToggle(true);
            _matchedCards.Clear();
            _gridHandler.CleanGrid();
        }
    }
}