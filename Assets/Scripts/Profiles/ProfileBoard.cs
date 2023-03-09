using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProfileBoard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI texts;

    private void OnEnable()
    {
        ProfilesManager.instance.LoadProfiles();
        PlayerProfiles profiles = ProfilesManager.instance.currentProfiles;

        List<PlayerProfile> loadedProfiles = profiles.GetProfiles();
        texts.text = "";
        foreach(PlayerProfile p in loadedProfiles)
        {
            texts.text += p.name + " " + p.score + "\n";
        }
    }
    
}
