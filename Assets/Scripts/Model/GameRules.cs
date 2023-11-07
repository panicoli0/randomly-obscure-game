using System.Data;
using UnityEngine;

namespace CardMatchingGame.Model
{
    public static class GameRules
    {
        public static int Rule
        {
            get => _rule;
            set
            {
                _rule = value * 2;
            }
        }

        private static int _rule;
    }
}