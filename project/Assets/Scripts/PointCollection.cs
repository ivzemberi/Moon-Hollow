using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PointCollection 
{
    public int Score { get; private set; }
    public int startingScore = 0;

    // Event to notify when the score changes
    public event Action<int> OnScoreChanged;

    public PointCollection()
    {
        Score = startingScore;
    }

    public void AddPoints(int _points)
    {
        Score += _points;
        Debug.Log($"Score updated! Current Score: {Score}");
        OnScoreChanged?.Invoke(Score); // Trigger the event
    }

    public void ResetScore()
    {
        Score = startingScore;
        Debug.Log("Score reset!");
        OnScoreChanged?.Invoke(Score); // Trigger the event
    }
}
