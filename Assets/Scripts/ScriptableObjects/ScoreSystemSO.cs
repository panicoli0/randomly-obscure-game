using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ScoreSystemScritableObject", menuName = "ScriptableObjects/ScoreSystem")]
public class ScoreSystemSO : ScriptableObject, IDataPersistence
{
    public int score=0;

    [SerializeField] private int totalScore=0;

    [System.NonSerialized]
    public UnityEvent<int> scoreChangeEvent;

    private void OnEnable()
    {
        score = totalScore;
        if (scoreChangeEvent == null)
        {
            scoreChangeEvent = new UnityEvent<int>();
        }
    }

    public void AddScore(int amount)
    {
        totalScore += amount;
        scoreChangeEvent.Invoke(score);
    }

    public void LoadData(GameData data)
    {
        totalScore = data.score;
    }

    public void SaveData(GameData data)
    {
        data.score = totalScore;
    }
}
