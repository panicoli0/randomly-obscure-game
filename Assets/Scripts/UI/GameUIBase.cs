using CardMatchingGame.UI.View;
using System;
using UnityEngine;
using CardMatchingGame.Actions;
using System.Collections;
using System.Collections.Generic;

namespace CardMatchingGame.UI
{
    public class GameUIBase : MonoBehaviour
    {
        public int turnsAmount;
        private LevelRequestView _levelRequestView;

        /*public delegate void onSelect(bool seleccet);
        public event onSelect OnSelect;*/

        public Action levelRequestAction;

        private void Awake()
        {
            _levelRequestView.LevelRequestViewStateChanged += OnLevelStateChanged;
        }

        private void OnEnable()
        {
            Actions.OnTurnsUpdated += OnLevelStateChanged;
        }

        private void OnDisable()
        {
            Actions.OnTurnsUpdated -= OnLevelStateChanged;
        }

        internal void OnLevelStateChanged(int value)
        {
            Debug.Log("OnLevelStateChanged: this is my value: " + value);
            turnsAmount = value;
            //levelRequestAction?.Invoke(value);
        }

        internal void SetTurnsAmount(int amount)
        {
            OnLevelStateChanged(amount);
            //_turnsAmount = amount;
            //_selecct?.Invoke();
            //LevelRequestViewStateChanged?.Invoke(amount);           //_levelRequestView.LevelRequestViewStateChanged += OnLevelRequestViewStateChanged;
        }

        /*private void OnLevelRequestViewStateChanged(int turnAmount)
        {
            _turnsAmount = turnAmount;
        }

        internal int GetTurnsAmount()
        {
            return _turnsAmount;
        }*/

        internal void MenuToggle(bool display) => gameObject.SetActive(display);
    }
}