using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public int score = 0;

    public void UpdateScore(int score)
    {
        this.score += score;
        scoreText.SetText("Score: "+ this.score);
    }

    public void SaveScore()
    {
        SaveManager.SavePlayerProfile(CurrentProfile.instanceProfile.playerProfile.name,
                                      this.score, 
                                      CurrentProfile.instanceProfile.index);
    }
}
