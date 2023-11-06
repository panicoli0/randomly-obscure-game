using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CardMatchingGame.UI.View
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

        public delegate void CardTurnHandler(CardView card, int move);
        public event CardTurnHandler CardMoveChanged;

        [SerializeField] private State _carCurrentState;
        [SerializeField] private string _cardId;
        [SerializeField] private int _cardPoint;
        [SerializeField] private Image _cardVisual;
        [SerializeField] private TMP_Text _cardText;
        [SerializeField] private Button _cardButton;
        [SerializeField] private AudioSource _audioSource;

        private bool _cardStatus;
        private float flipDuration = 0.15f;
        private Vector3 flipScale = new(0, 1, 1);
        private Vector3 faceUpScale = new(1, 1, 1);
        private bool isFlipping = false;
        int move = 1;

        private void Awake()
        {
            _cardId = System.Guid.NewGuid().ToString();
            _cardButton.onClick.AddListener(OnSelected);
        }

        private void OnSelected()
        {
            Debug.Log(number + " wasClicked");
            CardMoveChanged?.Invoke(this, move);
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
            }
            else if (_carCurrentState == State.FaceUp)
            {
                FlipFx(State.FaceDown);
            }
        }

        public void FlipFx(State state)
        {
            if (!isFlipping && gameObject.activeInHierarchy)
            {
                isFlipping = true;
                StartCoroutine(FlipCoroutine(state));
            }
            else
            {
                StopCoroutine(FlipCoroutine(state));
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
            if (gameObject.activeInHierarchy) _audioSource.PlayOneShot(_audioSource.clip);
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
