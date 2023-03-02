using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProfileBoard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerText1, playerText2, playerText3, playerText4, playerText5;
    [SerializeField] TextMeshProUGUI scoreText1, scoreText2, scoreText3, scoreText4, scoreText5;

    private void OnEnable()
    {
        PlayerProfile playerProfiles1 = SaveManager.LoadPlayerProfile(1);
        PlayerProfile playerProfiles2 = SaveManager.LoadPlayerProfile(2);
        PlayerProfile playerProfiles3 = SaveManager.LoadPlayerProfile(3);
        PlayerProfile playerProfiles4 = SaveManager.LoadPlayerProfile(4);
        PlayerProfile playerProfiles5 = SaveManager.LoadPlayerProfile(5);
        Debug.Log("Player profile charged");
        if (playerProfiles1 != null)
        {
            playerText1.SetText(playerProfiles1.name);
            scoreText1.SetText(""+playerProfiles1.score);
        }
        if (playerProfiles2 != null)
        {
            playerText2.SetText(playerProfiles2.name);
            scoreText2.SetText(""+playerProfiles2.score);
        }
        if (playerProfiles3 != null)
        {
            playerText3.SetText(playerProfiles3.name);
            scoreText3.SetText(""+playerProfiles3.score);
        }
        if (playerProfiles4 != null)
        {
            playerText4.SetText(playerProfiles4.name);
            scoreText4.SetText(""+playerProfiles4.score);
        }
        if (playerProfiles5 != null)
        {
            playerText5.SetText(playerProfiles5.name);
            scoreText5.SetText(""+playerProfiles5.score);
        }
    }
    
}
