using CardMatchingGame.Model.DataPersistance.Data;
using CardMatchingGame.Presentation.Systems;
using CardMatchingGame.UI;
using CardMatchingGame.UI.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardMatchingGame.Presentation
{
    public class GridHandlerPresentation : MonoBehaviour
    {
        public int Size { get => _size; set => _size = value; }

        [SerializeField] private CardView _cardPrefab;
        [SerializeField] private Transform _container;
        [SerializeField] private Transform _oldGrid;
        [SerializeField] private CardsListener _cardsListener;
        [SerializeField] private MatchingCardsSystem _matchingCardsGame;
        [SerializeField] private MatchChecker _matchChecker;

        private List<CardView> _grid = new();
        private int _size;
        private bool result = true;
        private int index = 0;

        public void Init()
        {
            CleanGrid();
            if (_size != 0) SetGrid(_size);
        }

        private void OnDisable()
        {
            StopCoroutine(CreateGrid(0, false));
            StopCoroutine(RebuildGrid(false, null));
        }

        internal void SetGrid(int amount)
        {
            CleanGrid();
            UISceneReferenceHolder.GridHandlerView.MenuToggle(true);

            _size = amount;
            PlayerPrefs.SetInt("GridSize", _size);
            _matchChecker.WinLevelCont = 0;

            StartCoroutine(CreateGrid(amount, true));
            
            if (result == false)
            {
                Debug.Log("CreateGrid routine finish");
                var cards = _cardsListener.GetComponentsInChildren<CardView>();
                foreach (CardView card in cards) _cardsListener.AddCard(card);
            }
        }

        private IEnumerator CreateGrid(int amount, bool start)
        {
            while (start)
            {
                // Create the grid
                for (int i = 0; i < amount; i++)
                {
                    CardView cardView = Instantiate(_cardPrefab, _container);

                    _grid.Add(cardView);
                    foreach (CardView card in _grid) card.number = GetNextValue(amount);
                    if (i >= amount / 2) result = start = false;
                }

                yield return start;
            }
        }

        internal IEnumerator RebuildGrid(bool start, GameData data)
        {
            while (start && data.gridStatus.Count != 0)
            {
                for (int i = 0; i < data.gridStatus.Count; i++)
                {
                    CardView cardView = Instantiate(_cardPrefab, _container);
                    _grid.Add(cardView);
                    if (i >= data.gridStatus.Count) result = start = false;
                }
            }
            yield return start;
        }

        public int GetNextValue(int cardsAmount)
        {
            if (cardsAmount == 4)
            {
                int[] values = new int[] { 1, 2, 1, 2 };
                index = (index + 1) % values.Length;
                return values[index];
            }
            else if (cardsAmount == 6)
            {
                int[] values = new int[] { 1, 2, 3, 1, 2, 3 };
                index = (index + 1) % values.Length;
                return values[index];
            }
            else if (cardsAmount == 30)
            {
                int[] values = new int[] { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 };
                index = (index + 1) % values.Length;
                return values[index];
            }
            return 0;
        }

        internal void CleanGrid()
        {
            _grid.Clear();
            var grid = _container.GetComponentsInChildren<CardView>();
            if (grid.Length != 0)
            {
                for (int i = 0; i < grid.Length; i++)
                {
                    grid[i].transform.SetParent(_oldGrid);
                    var oldGrid = _oldGrid.GetComponentsInChildren<CardView>();
                    Destroy(oldGrid[i].gameObject);
                }
            }
        }
    }
}