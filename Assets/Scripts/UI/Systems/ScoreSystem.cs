using UnityEngine;
using UnityEngine.Playables;
using CardMatchingGame.DataPersistance.Interfaces;

namespace CardMatchingGame.UI.Systems
{
    internal class ScoreSystem : GameUIBase, IDataPersistence
    {
        [SerializeField] int totalScore;

        public void LoadData(GameData data)
        {
            totalScore = data.score;
        }

        public void SaveData(GameData data)
        {
            data.score = totalScore;
        }

        internal void AddScore(int amount)
        {
            totalScore += amount;
        }
    }
}