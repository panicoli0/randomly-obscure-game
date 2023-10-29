using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CardMatchingGame.UI
{
    public class CardView : GameUIBase
    {
        public int number { get; internal set; }
        public int point { get => _cardPoint; set => _cardPoint = value; }
        public State CurrentState { get => _carCurrentState; private set => _carCurrentState = value; }
        public string id { get => _cardId; set => _cardId = value; }
        public bool status { get => _cardStatus; set => _cardStatus = value; }
        public Image visual { get => _cardVisual; set => _cardVisual = value; }

        public delegate void CardStateChangedHandler(CardView card, State newState);
        public event CardStateChangedHandler CardStateChanged;

        [SerializeField] private State _carCurrentState;
        [SerializeField] private string _cardId;
        [SerializeField] private int _cardPoint;
        [SerializeField] private Image _cardVisual;
        [SerializeField] private bool _cardStatus;
        [SerializeField] private TMP_Text _cardText;
        [SerializeField] private Button _cardButton;
        [SerializeField] private AudioSource _audioSource;

        private float flipDuration = 0.25f;
        private Vector3 flipScale = new(0, 1, 1);
        private Vector3 faceUpScale = new(1, 1, 1);
        private bool isFlipping = false;

        private void Awake()
        {
            _cardId = System.Guid.NewGuid().ToString();
            _cardButton.onClick.AddListener(OnSelected);
        }

        private void OnSelected()
        {
            Debug.Log(number + " wasClicked");
            Flip();
        }

        private void Start()
        {
            _carCurrentState = State.FaceDown;
            _cardText.SetText(number.ToString());
            _cardStatus = true;
        }

        private void OnDisable() => StopCoroutine(FlipCoroutine(State.FaceDown));

        public enum State
        {
            FaceDown,
            FaceUp,
            Matched
        }

        public void Flip()
        {
            if (_carCurrentState == State.FaceDown)
            {
                FlipFx(State.FaceUp);

                _audioSource.PlayOneShot(_audioSource.clip);
            }
            else if (_carCurrentState == State.FaceUp)
            {
                FlipFx(State.FaceDown);

                _audioSource.PlayOneShot(_audioSource.clip);
            }
        }

        public void FlipFx(State state)
        {
            if (!isFlipping)
            {
                isFlipping = true;
                StartCoroutine(FlipCoroutine(state));
            }
        }

        private IEnumerator FlipCoroutine(State state)
        {
            float elapsedTime = 0f;
            _cardText.gameObject.SetActive(!_cardText.gameObject.activeInHierarchy);
            while (elapsedTime < flipDuration)
            {
                _cardVisual.transform.localScale = Vector3.Slerp(flipScale, faceUpScale, elapsedTime / flipDuration);
                elapsedTime += Time.deltaTime;

                yield return null;
            }
            isFlipping = false;
            _carCurrentState = state;
            Debug.Log("card: " + number + "state: " + _carCurrentState);
            CardStateChanged?.Invoke(this, _carCurrentState);
        }

        public void Match()
        {
            _carCurrentState = State.Matched;
            Debug.Log("card: " + number + "state: " + _carCurrentState);
            CardStateChanged?.Invoke(this, _carCurrentState);
        }

        internal void Matched()
        {
            _cardStatus = false;
            _cardVisual.gameObject.SetActive(_cardStatus);
        }

        public void UpdateCards() => visual.gameObject.SetActive(_cardStatus);
    }
}
