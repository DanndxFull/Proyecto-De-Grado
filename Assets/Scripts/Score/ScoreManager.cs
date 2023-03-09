using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
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
        scoreText.SetText("Score: "+ this.score);
    }

    public void SaveScore()
    {
        //SaveManager.SavePlayerProfile(CurrentProfile.instanceProfile.playerProfile.name,
        //                              this.score, 
        //                              CurrentProfile.instanceProfile.index);
    }
}
