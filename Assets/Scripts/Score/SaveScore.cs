using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveScore : MonoBehaviour
{
    [SerializeField] ScoreManager score;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SaveScoreProfile();
            SceneManager.LoadScene("Menu");
        }
    }

    public void SaveScoreProfile()
    {
        //SaveManager.SavePlayerProfile(CurrentProfile.instanceProfile.playerProfile.name, score.score,CurrentProfile.instanceProfile.index);
        Debug.Log(CurrentProfile.instanceProfile.name);
        Debug.Log(score.score);
        ProfilesManager.instance.UpdateProfile(CurrentProfile.instanceProfile.playerProfile.name, score.score);
    }
}
