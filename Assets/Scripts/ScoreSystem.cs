using UnityEngine;

internal class ScoreSystem : MonoBehaviour, IDataPersistence
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