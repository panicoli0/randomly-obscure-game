using CardMatchingGame.DataPersistance.Interfaces;
using CardMatchingGame.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CardMatchingGame.Presentation
{
    public class CardsListener : GamePresentationBase, IDataPersistence
    {
        [SerializeField] private List<CardView> _cards = new();
        [SerializeField] private MatchingCardsGame _matchingCardsGame;
        [SerializeField] private GridHandler _gridHandler;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private List<AudioClip> _clips;
        [SerializeField] private List<string> _cardsIDs = new();
        [SerializeField] private List<bool> _cardsStatus = new();

        private bool startAssigningValues;
        private CardView _firstCard;
        private CardView _secondCard;

        private void OnDisable() => StopCoroutine(AssignValue(null));

        public void AddCard(CardView card)
        {
            _cards.Add(card);
            card.CardStateChanged += OnCardStateChanged;
        }

        private void OnCardStateChanged(CardView card, CardView.State newState)
        {
            // If the card has been flipped face up, check if it matches the first card
            if (newState == CardView.State.FaceUp)
            {
                if (_firstCard == null)
                {
                    _firstCard = card;
                }
                else
                {
                    _secondCard = card;

                    // If the two cards match, mark them as matched
                    if (_firstCard.CurrentState == CardView.State.FaceUp && _secondCard.CurrentState == CardView.State.FaceUp && _firstCard != _secondCard)
                    {
                        if (_firstCard.number != _secondCard.number)
                        {
                            Debug.Log("NOT A MATCH!");
                            _audioSource.PlayOneShot(_clips[0]); //Possible refactor: Aclass.audioSource.PlayOneShot(Aclass.clips.notamatch);
                            _firstCard.Flip();
                            _secondCard.Flip();
                        }
                        else
                        {
                            _firstCard.Match();
                            _secondCard.Match();
                            _audioSource.PlayOneShot(_clips[1]); //Possible refactor: Aclass.audioSource.PlayOneShot(Aclass.clips.notamatch);
                            _matchingCardsGame.AddMatchedCards(_firstCard, _secondCard);
                        }
                    }
                    else
                    {
                        Debug.Log(_firstCard.CurrentState);
                        Debug.Log(_secondCard.CurrentState);
                    }

                    // Reset the first and second cards
                    _firstCard = null;
                    _secondCard = null;
                }
            }
        }

        public void LoadData(GameData data)
        {
            _gridHandler.Size = data.cardsStatus.Count;
            _gridHandler.Init();

            for (int i = 0; i < data.cardsStatus.Count; i++)
            {
                KeyValuePair<string, bool> kvp = data.cardsStatus.ElementAt(i);

                _cardsIDs.Add(kvp.Key);
                _cardsStatus.Add(kvp.Value);
                if (i >= data.cardsStatus.Count - 1)
                {
                    startAssigningValues = true;
                    break;
                }
            }
            StartCoroutine(AssignValue(data));
        }

        private IEnumerator AssignValue(GameData gameData)
        {
            while (startAssigningValues && gameData != null)
            {
                for (int j = 0; j < _cards.Count; j++)
                {
                    _cards[j].id = _cardsIDs[j];
                    _cards[j].status = _cardsStatus[j];
                    _cards[j].UpdateCards();
                    if (j >= _cards.Count - 1)
                    {
                        _matchingCardsGame.WinLevelCont = gameData.winLevelCont;
                        startAssigningValues = false;
                        yield break;
                    }
                }
            }
        }

        public void SaveData(GameData data)
        {
            data.gridStatus = _cards;
            foreach (var card in _cards)
            {
                if (data.cardsStatus.ContainsKey(card.id))
                {
                    data.cardsStatus.Remove(card.id);
                }
                if (card != null)
                {
                    data.cardsStatus.Add(card.id, card.visual.gameObject.activeSelf);
                    data.winLevelCont = _matchingCardsGame.WinLevelCont;
                }
            }
        }
    }
}
