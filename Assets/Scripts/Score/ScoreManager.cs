using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instanceScore;
    public int score = 0;

    private void Awake()
    {
        if (instanceScore != null)
        {
            Destroy(this);
        }
        else
        {
            instanceScore = this;
            DontDestroyOnLoad(this);
        }
    }

    public void UpdateScore(int score)
    {
        this.score += score;
    }

    public void RestartScore()
    {
        this.score = 0;
    }
}
